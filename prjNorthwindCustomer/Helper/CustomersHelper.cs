using prjNorthwindCustomer.DAO;
using prjNorthwindCustomer.Interface;
using prjNorthwindCustomer.Models;

namespace prjNorthwindCustomer.Helper
{
    internal class CustomersHelper : ICustomersHelper
    {
        private readonly CustomersDAO _customersDAO;

        public CustomersHelper(CustomersDAO customersDAO)
        {
            _customersDAO = customersDAO;
        }

        public IEnumerable<Customers> selectCustomersInfo(Customers input = null) 
        {
            if (input == null) 
            {
            input = new Customers();
            }
            return _customersDAO.getCustomersInfo(input);
        }
    }
}
