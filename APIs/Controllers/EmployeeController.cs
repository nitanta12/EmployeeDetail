using APIs.DTOs;
using APIs.Factory;
//using Domain.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace APIs.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServiceLayer _employeeService;
        private readonly IEmployeeFactory _employeeFactory;
        

        public EmployeesController(IEmployeeServiceLayer employeeService,
            IEmployeeFactory employeeFactory)
        {
            _employeeService = employeeService;
            _employeeFactory = employeeFactory;

        }

        
        [HttpGet]
        
        public async Task<ActionResult<List<GetAllSP>>> Index()
        {
            var data = await _employeeService.GetEmployeeDetailAsync();
            //var data = await _iemployeeService.GetEmployees();
            //var empDto = _employeeFactory.MapEntityToDto(data).ToList();
            return Ok(data);
        }

        [HttpPost]
        [Route("uploadfiles")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var result = await _employeeService.UploadFiles(file);
            return Ok(result);
        }

        [HttpPost]
        [Route("employees")]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeDto edt)
        {
            if (ModelState.IsValid)
            {
                var entity = _employeeFactory.MapDtoToEntity(edt, new EmployeeDetail());
                await _employeeService.AddEmployeeAsync(entity, edt.Files).ConfigureAwait(false);
                return Ok(edt);
            }
            return BadRequest();
        }

      
        [HttpPut]
        public async Task<ActionResult<EmployeeDetail>> UpdateEmployee([FromForm] EmployeeDto dto)
        {
            var old = await _employeeService.GetEmployeeByIdAsync(dto.Id.Value).ConfigureAwait(false);
            var entity = _employeeFactory.MapDtoToEntity(dto, old);
            if (ModelState.IsValid && dto.DateOfBirth < DateTime.Now)
            {
                await _employeeService.EditEmployeeAsync(entity);
                return Ok(dto);
            }
            return BadRequest("Not a valid condition.DateOfBirth is not valid");
        }


        [Route("employees/{id}")]
        [HttpGet]
        public async Task<ActionResult<GetAllSP>> Details(int id)
        {
            var res = await _employeeService.DetailByIdAsync(id).ConfigureAwait(false);
            return Ok(res);
        }


       
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDetail>> DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var data = await _employeeService.DeleteEmployeeAsync(id.Value);
            return Ok(data);

        }
    }
}
