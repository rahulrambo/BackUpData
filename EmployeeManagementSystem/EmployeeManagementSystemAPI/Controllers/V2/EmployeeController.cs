//using AutoMapper;
//using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
//using EmployeeManagementSystem.Core.Entities;
//using EmployeeManagementSystem.Infrastructure.Repositories;
//using EmployeeManagementSystemAPI.Extensions;
//using EmployeeManagementSystemAPI.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace EmployeeManagementSystemAPI.Controllers.V2
//{
//    [ApiVersion("2.0")]
//    [ApiConventionType(typeof(DefaultApiConventions))]
//    public class EmployeeController : ApiControllerBase
//    {
//        private readonly IMapper _mapper;
//        private readonly IEmployeeService _employeeService;
//        private readonly ILogger<EmployeeController> _logger;
//        private readonly IEmployeeRepository _employeeRepository;
//        private readonly IConfiguration _config;

//        public EmployeeController(IMapper mapper, IEmployeeService employeeService, IConfiguration configuration, ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
//        {
//            _mapper = mapper;
//            _employeeService = employeeService;
//            _config = configuration;
//            _logger = logger;
//            _employeeRepository = employeeRepository;
//        }

//        [Route("register")]
//        [HttpPost]
//        public async Task<ActionResult> Register(EmployeeVm employeeVm)
//        {
//            _logger.LogInformation("Inserting data to Employee entity with password.");
//            var passwordSalt = GenerateSalt();
//            employeeVm.Password += passwordSalt;
//            var passwordHash = GenerateHashPassword(employeeVm.Password);

//            Employee employee = _mapper.Map<EmployeeVm, Employee>(employeeVm);
//            var result = await _employeeService.CreateAsync(employee);
//            var employeeDto = _mapper.Map<Employee, EmployeeVm>(result);
//            return Ok(employeeDto);

//        }



//        private string GenerateHashPassword(string password)
//        {
//            string machineKey = _config["MachineKey"].ToString();
//            var hmac = new HMACSHA1()
//            {
//                Key = machineKey.HexToByte()
//            };
//            return Convert.ToBase64String(hmac.ComputeHash(password.GetByteArray()));
//        }

//        private static string GenerateSalt()
//        {
//            int saltLength = 8;
//            byte[] salt = new byte[saltLength];
//            using (var random = new RNGCryptoServiceProvider())
//            {
//                random.GetNonZeroBytes(salt);
//            }
//            return Convert.ToBase64String(salt);
//        }

//        private string GenerateToken(Employee employee)
//        {
//            var claims = new[]
//            {
//                new Claim("EmployeeId", employee.EmployeeId.ToString()),
//                new Claim("FirstName", employee.FirstName),
//                new Claim("LastName", employee.LastName),
//                new Claim("EmailId", employee.EmailId),
//                new Claim(ClaimTypes.Role,"admin")
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(
//                _config["Jwt:Issuer"],
//                _config["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddHours(3),
//                signingCredentials: signIn);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
