using Microsoft.AspNetCore.Mvc;
using prjNorthwindCustomer.Helper;

namespace prjNorthwindCustomer.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersHelper _customersHelper;

        internal CustomersController(CustomersHelper customersHelper) 
        {
            _customersHelper = customersHelper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
