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

        [HttpDelete("{customerID}")]
        public IActionResult deleteCustomer(string customerID) 
        {
            try
            {
                _customersHelper.deleteCustomer(customerID);
                return NoContent(); 
            }
            catch (ArgumentException aE)
            {
                return BadRequest(aE.Message); 
            }
            catch (InvalidOperationException iOE)
            {
                return NotFound(iOE.Message); 
            }
        }

        [HttpPost("{customerID}")]
        public IActionResult updateCustomer(string customerID, [FromBody] Customers input) 
        {
             _customersHelper.updateCustomer(customerID,input);
            return Ok("已成功修改");
        }
    }
}
