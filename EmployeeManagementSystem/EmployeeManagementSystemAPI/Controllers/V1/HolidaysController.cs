using AutoMapper;
using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystemAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementSystemAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Route("holiday")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class HolidaysController : ApiControllerBase
    {
        private IHolidaysService _holidayService;
        private readonly ILogger<HolidaysController> _logger;
        private readonly IMapper _mapper;
        public HolidaysController(ILogger<HolidaysController> logger, IMapper mapper, IHolidaysService holidayService)
        {
            _logger = logger;
            _mapper = mapper;
            _holidayService = holidayService;
        }

        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Holiday>> Post([FromBody] HolidayVm holiDayVm)
        {
            _logger.LogInformation("Inserting data to department entity.");
            var holiday = _mapper.Map<HolidayVm, Holiday>(holiDayVm);
            return Ok(await _holidayService.CreateAsync(holiday));
        }


        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<HolidaysDto>> get()
        {
            _logger.LogInformation("Getting list of all Public leaves");
            var result = await _holidayService.GetHolidaysAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
