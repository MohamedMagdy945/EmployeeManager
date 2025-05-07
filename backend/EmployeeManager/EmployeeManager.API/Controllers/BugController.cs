using AutoMapper;
using EmployeeManager.API.Helper;
using EmployeeManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.API.Controllers
{
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("not-found")]
        public async Task<ActionResult> GetNotFound()
        {  
            var employee = await UnitOfWork.EmployeeRepository.GetByIdAsync(1000);
            if (employee == null) return NotFound();
            return Ok(employee);   
        }

        [HttpGet("server-error")]
        public async Task<ActionResult> GetServerError()
        {
            var employee = await UnitOfWork.EmployeeRepository.GetByIdAsync(1000);  
            employee.FirstName = "";
            return Ok(employee);
        }

        [HttpGet("bad-request/{id}")]
        public async Task<ActionResult> GetBadRequest(int id)
        {
            return Ok();
        }

        [HttpGet("bad-request/")]
        public async Task<ActionResult> GetBadRequest()
        {
            return BadRequest();
        }
    }
}
