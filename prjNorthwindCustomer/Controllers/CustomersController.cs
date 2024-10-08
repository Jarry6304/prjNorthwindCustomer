using Microsoft.AspNetCore.Mvc;
using prjNorthwindCustomer.Models;
using prjNorthwindCustomer.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

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

        [HttpPut("{customerID}")]
        public IActionResult updateCustomer(string customerID, [FromBody] Customers input) 
        {
             _customersHelper.updateCustomer(customerID,input);
            return Ok("已成功修改");
        }

        [HttpPost("Create")]
        public IActionResult createNewCustomer([FromBody] Customers input) 
        {
            try
            {
                _customersHelper.createNewCustomer(input);
                return Ok("已成功新增顧客");
            }
            catch (InvalidOperationException iOE)
            {
                return Conflict(iOE.Message); 
            }
            catch (ArgumentException aE)
            {
                return BadRequest(aE.Message); 
            }
        }
    }
}
