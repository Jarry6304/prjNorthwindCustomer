using prjNorthwindCustomer.DAO;
using prjNorthwindCustomer.Models;

namespace prjNorthwindCustomer.Helper
{
    internal class CustomersHelper
    {
        private readonly CustomersDAO _customersDAO;

        internal CustomersHelper(CustomersDAO customersDAO)
        {
            _customersDAO = customersDAO;
        }

        internal IEnumerable<Customers> selectCustomersInfo(Customers input = null) 
        {
            if (input == null) 
            {
            input = new Customers();
            }
            return _customersDAO.getCustomersInfo(input);
        }
    }
}
