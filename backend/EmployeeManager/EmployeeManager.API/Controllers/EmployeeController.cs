using AutoMapper;
using EmployeeManager.API.Helper;
using EmployeeManager.Core.DTO;
using EmployeeManager.Core.Entities.Employee;
using EmployeeManager.Core.Interfaces;
using EmployeeManager.Core.Sharing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.API.Controllers
{

    public class EmployeeController : BaseController
    {
        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork , mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]EmployeeParams employeeParams)
        {
            try
            {
                var employees = await UnitOfWork.EmployeeRepository.GetAllAsync(employeeParams);
                var emp = employees.Employees;
                if (employees == null)
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(new Pagination<ReturnEmployeeDTO>(employeeParams.PageNumber, employeeParams.PageSize, employees.TotalCount,emp));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getbyId(int id)
        {
            try
            {
                var employee = await UnitOfWork.EmployeeRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return BadRequest(new ResponseAPI(400 , $"Not Found Employee id= {id}"));
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> add([FromForm] EmployeeDTO employeeDTO)
        {
            try
            {

                await UnitOfWork.EmployeeRepository.AddAsync(employeeDTO);
                return Ok(new ResponseAPI(200, $"item Has been Added"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-employee")]
        public async Task<IActionResult> update([FromForm] UpdateEmployeeDTO employeeDTO)
        {
            try
            {
                await UnitOfWork.EmployeeRepository.UpdateAsync(employeeDTO);
                return Ok(new ResponseAPI(200, $"item Has been Updated"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var employee = await UnitOfWork.EmployeeRepository.GetByIdAsync(id);
                await UnitOfWork.EmployeeRepository.deleteAsync(employee);
                return Ok(new ResponseAPI(200, $"item Has been Deleted"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
    }
}
