﻿using prjNorthwindCustomer.Models;

namespace prjNorthwindCustomer.Interface
{
    public interface ICustomersHelper
    {
        IEnumerable<Customers> selectCustomersInfo(Customers input = null);
        void deleteCustomer(string customerID);
        void updateCustomer(string customerID,Customers input);
        void createNewCustomer(Customers input);
    }
}
