using EmployeeManager.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.API.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public ActionResult Error(int statusCode)
        {
            return new ObjectResult(new ResponseAPI(statusCode)); 
           
        }
    }
}
