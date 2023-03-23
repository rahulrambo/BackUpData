﻿using EmployeeManagementSystem.Core.Contracts.Infrastructure.Respositories;
using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Core.Enum;
using EmployeeManagementSystem.Infrastructure.Repositories;
using System.Runtime;

namespace EmployeeManagementSystem.Infrastructure.Services
{
    public class LeaveApplicationServices : ILeaveApplicationService
    {
        private readonly ILeaveApplicationRepository _leaveApplicationRepository;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        public LeaveApplicationServices(ILeaveApplicationRepository leaveApplicationRepository, IAttendanceRepository attendanceRepository, ILeaveBalanceRepository leaveBalanceRepository)
        {
            _leaveApplicationRepository = leaveApplicationRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _attendanceRepository = attendanceRepository;
        }

        public async Task<LeaveApplication> CreateAsync(LeaveApplication leaveApplication)
        {
            var totalDays = GetBusinessDays (leaveApplication.StartDate, leaveApplication.EndDate);          
            leaveApplication.NoOfDays = (int)totalDays;
            leaveApplication.DateOfApplication = DateTime.UtcNow;
            leaveApplication.StatusId = (int)LeaveApprovalStatus.Pending;
            return await _leaveApplicationRepository.CreateAsync(leaveApplication);
        }

        public static double GetBusinessDays(DateTime startD,DateTime endD)
        {
            double calculateDays = 1+((endD-startD).TotalDays*5-(startD.DayOfWeek-endD.DayOfWeek)*2)/ 7;
            if (endD.DayOfWeek==DayOfWeek.Saturday || endD.DayOfWeek==DayOfWeek.Sunday)
            {
                return calculateDays;
            }
            return calculateDays;
        }

        public Task DeleteLeaveApplicationAsync(int leaveId)
        {
            return _leaveApplicationRepository.DeleteLeaveApplicationAsync(leaveId);
        }

        public Task<IEnumerable<LeaveApplicationDto>> GetLeaveApplicationAsync(int? LeaveApplicationId = null, int? EmployeeId = null)
        {
            return _leaveApplicationRepository.GetLeaveApplicationAsync(LeaveApplicationId, EmployeeId);
        }

        public Task<LeaveApplication> GetLeaveDataByIdAsync(int leaveId)
        {
            return _leaveApplicationRepository.GetLeaveDataByIdAsync(leaveId);
        }

        public async Task<bool> UpdateAsync(int leaveId, UpdateLeaveApplicationRequestDto leaveApplication)
        {
            if (leaveApplication.Status == LeaveApprovalStatus.Cancelled)
            {
                await _leaveApplicationRepository.UpdateAsync(leaveId, leaveApplication, new LeaveApplication());
                return false;
            }

            var leaveApplicationData = await _leaveApplicationRepository.GetLeaveDataByIdAsync(leaveId);
            var leaveBal = await _leaveBalanceRepository.GetRemainingLeavesByEmpId(leaveApplicationData.EmployeeId, leaveApplicationData.LeaveTypeId);

            if (leaveBal.Balance >= leaveApplicationData.NoOfDays)
            {

                leaveBal.Balance = leaveBal.Balance - leaveApplicationData.NoOfDays;
                await _leaveBalanceRepository.UpdateAsync(leaveId, leaveBal);
                await _leaveApplicationRepository.UpdateAsync(leaveId, leaveApplication, leaveApplicationData);

                List<Attendance> attendances = new();
                int loopCount = (int)(leaveApplicationData.EndDate - leaveApplicationData.StartDate).TotalDays;
                for (int i = 0; i < loopCount; i++)
                {
                    var dateofLog = leaveApplicationData.StartDate;
                    if (leaveApplicationData.StartDate.DayOfWeek == DayOfWeek.Saturday
                        || leaveApplicationData.StartDate.DayOfWeek == DayOfWeek.Sunday) 
                    {
                        continue;
                    }

                    var attendance = new Attendance
                    {
                        EmployeeId = leaveApplicationData.EmployeeId,
                        LeaveTypeId = leaveApplicationData.LeaveTypeId,
                        DateOfLog = dateofLog.AddDays(i),
                    };
                        attendances.Add(attendance);
                }
                await _attendanceRepository.CreateRangeAsync(attendances);
                return true;
            }
            return false;

        }

        public Task<IEnumerable<LeaveApplicationDto>> GetEmployeeLeaveRequest(int empId)
        {
            return _leaveApplicationRepository.GetEmployeeLeaveRequest(empId);
        }
        public async Task<IEnumerable<TotalLeavesOfEmployeeDto>> GetEmployeeLeavesData(int empId)
        {
            return await _leaveApplicationRepository.GetEmployeeLeavesData(empId);
        }
    }
}
