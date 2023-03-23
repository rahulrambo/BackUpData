﻿using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Infrastructure.Services
{
    public class LeaveService : ILeavesService
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public Task<Leaves> CreateAsync(Leaves leave)
        {
            return _leaveRepository.CreateAsync(leave);
        }

        public Task DeleteLeaveAsync(int leaveId)
        {
           return _leaveRepository.DeleteLeaveAsync(leaveId);
        }

        public  Task<Leaves> GetLeaveDataAsync(int leaveId)
        {
            return _leaveRepository.GetLeaveDataAsync(leaveId);
        }

        public Task<IEnumerable<LeaveDto>> GetLeavesAsync()
        {
            return _leaveRepository.GetLeavesAsync();
        }

        public Task<Leaves> UpdateAsync(int leaveId, Leaves leave)
        {
            return _leaveRepository.UpdateAsync(leaveId, leave);
        }
    }
}
