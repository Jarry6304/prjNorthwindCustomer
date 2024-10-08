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

        public void deleteCustomer(string customerID) 
        {
            if (string.IsNullOrWhiteSpace(customerID))
            {
                throw new ArgumentException("顧客編號不得為空", nameof(customerID));
            }

            if (!_customersDAO.hasCustomer(customerID))
            {
                throw new InvalidOperationException("查無此顧客");
            }
            _customersDAO.deleteCustomer(customerID); 
        }

    }
}
