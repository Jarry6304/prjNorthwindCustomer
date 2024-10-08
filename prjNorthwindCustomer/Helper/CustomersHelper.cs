using prjNorthwindCustomer.DAO;
using prjNorthwindCustomer.Interface;
using prjNorthwindCustomer.Models;

namespace prjNorthwindCustomer.Helper
{
    internal class CustomersHelper : ICustomersHelper
    {
        private readonly CustomersDAO _customersDAO;
        private readonly OrdersDAO _ordersDAO;

        public CustomersHelper(CustomersDAO customersDAO, OrdersDAO ordersDAO)
        {
            _customersDAO = customersDAO;
            _ordersDAO = ordersDAO;
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
            if (_ordersDAO.hasOrder(customerID))
            {
                throw new InvalidOperationException("該顧客有其他訂單紀錄，請先刪除訂單紀錄後才能刪除顧客。");
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

        public void createNewCustomer(Customers input) 
        {
            if (_customersDAO.hasCustomer(input.CustomerID))
            {
                throw new InvalidOperationException("顧客編號與其他人重複，請重新輸入新顧客編號");
            }
            if (string.IsNullOrWhiteSpace(input.CustomerID) && string.IsNullOrWhiteSpace(input.CompanyName))
            {
                throw new ArgumentException("請輸入顧客編號及公司名稱", nameof(input));
            }
            if (input.CustomerID.Length > 5)
            {
                throw new ArgumentException("顧客編號最多只能輸入5個字元", nameof(input.CustomerID));
            }      
            _customersDAO.createNewCustomer(input);
        }

    }
}
