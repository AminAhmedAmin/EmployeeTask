using employeeTask.DTO;
using employeeTask.Models;
using employeeTask.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace employeeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeservice _employeeservice;

        public EmployeeController(IEmployeeservice employeeservice)
        {
            this._employeeservice = employeeservice;
        }




        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 2)
        {
            var employees =await  _employeeservice.Readall(page, pageSize);
            return Ok(employees);


        }
         


        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =await  _employeeservice.create(employeeDTO);
            if (result > 0)
            {
                return StatusCode(200);
            }
            else
            {
                return BadRequest();
            }

          
        }


        [HttpGet]
        [Route("GetEmployee")] // <- Updated route template
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeservice.Readbyid(id);

            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(employee);

        }

        


      
        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO employeeDTO)
        {
          

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _employeeservice.Update(employeeDTO);

            if (result == -1)
            {
                return BadRequest();
            }

        

            return Ok(result);
        }



        [HttpDelete("deleteEmployee")]
        public async Task<IActionResult> deleteEmployee(int id)
        {


            var result = await _employeeservice.delete(id);

            if (result >0)
            {

                return Ok();
                
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
