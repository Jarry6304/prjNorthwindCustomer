using Microsoft.AspNetCore.Mvc;
using prjNorthwindCustomer.Models;
using prjNorthwindCustomer.Interface;

namespace prjNorthwindCustomer.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomersHelper _customersHelper; 

        public CustomersController(ICustomersHelper customersHelper) 
        {
            _customersHelper = customersHelper;
        }

        [HttpGet("info")]
        public IActionResult getCustomersInfo([FromQuery] Customers searchCriteria)
        {
            var cInfo = _customersHelper.selectCustomersInfo(searchCriteria);
            return Ok(cInfo); 
        }
    }
}
