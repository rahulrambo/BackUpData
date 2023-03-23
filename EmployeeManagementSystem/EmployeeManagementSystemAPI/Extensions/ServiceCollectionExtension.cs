﻿using EmployeeManagementSystem.Core.Contracts.Infrastructure.Respositories;
using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Core.Enum;
using EmployeeManagementSystem.Infrastructure.Repositories;
using EmployeeManagementSystem.Infrastructure.Repositories.EntityFramework;
using EmployeeManagementSystem.Infrastructure.Services;
using EmployeeManagementSystemAPI.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeeManagementSystemAPI.Extensions
{
    public static  class ServiceCollectionExtension
    {
        public static void RegisterSystemService(this IServiceCollection services, IConfiguration configuration)
        {
            #region Authentication 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.FromHours(2)
                    };
                });
            #endregion

            #region Swagger

            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Jwt Authentication"
                });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            #endregion
            services.AddControllers();
            services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddDataProtection();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

        }
        public static void RegisterApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EmployeemanagementDbContext>(data =>
            {
                data.UseSqlServer(configuration.GetConnectionString("EmployeeDbContext"));
            });

            // Dapper
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                                configuration.GetConnectionString("EmployeeDbContext")));

            // Repositories
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ILeaveApplicationRepository, LeaveApplicationRepository>();
            services.AddTransient<ILeaveBalanceRepository, LeaveBalanceRepository>();
            services.AddTransient<ILeaveRepository, LeaveRepository>();            
            services.AddTransient<ILeaveStatusRepository, LeaveStatusRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<IHolidayRepository, HolidayRepository>();

            // Services
            services.AddTransient<IDepartmentService, DepartmentServices>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ILeaveApplicationService, LeaveApplicationServices>();
            services.AddTransient<ILeaveBalanceService, LeaveBalanceServices>();
            services.AddTransient<ILeavesService, LeaveService>();
            services.AddTransient<ILeaveStatusService, LeaveStatusServices>();
            services.AddTransient<IRolesService, RoleService>();
            services.AddTransient<IAttendanceService, AttendanceServices>();
            services.AddTransient<IHolidaysService, HolidayServices>();

        }

    }
}
