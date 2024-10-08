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

        public void updateCustomer(string customerID,Customers input)
        {
            if (input == null) 
            {
            throw new ArgumentNullException("請輸入修改資料", nameof(input));
            }
            if (string.IsNullOrWhiteSpace(input.ContactName) || string.IsNullOrWhiteSpace(input.ContactTitle) ||
                string.IsNullOrWhiteSpace(input.Address) || string.IsNullOrWhiteSpace(input.City) || string.IsNullOrWhiteSpace(input.Region) ||
                string.IsNullOrWhiteSpace(input.PostalCode) || string.IsNullOrWhiteSpace(input.Country) || string.IsNullOrWhiteSpace(input.Phone) ||
                string.IsNullOrWhiteSpace(input.Fax)) 
            {
            throw new ArgumentException("除了公司名稱之外至少一個選項必須填寫");
            }
            _customersDAO.updateCustomer(input);
        }

    }
}
