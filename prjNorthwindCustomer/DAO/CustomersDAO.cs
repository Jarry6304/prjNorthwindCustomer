using Dapper;
using Microsoft.Data.SqlClient;
using prjNorthwindCustomer.Models;
using System;
using static System.Collections.Specialized.BitVector32;

namespace prjNorthwindCustomer.DAO
{
    internal class CustomersDAO
    {
        private string _connectionString { get; set; }
        internal CustomersDAO(string connection)
        {
            _connectionString = connection;
        }

        internal void createNewCustomer(Customers data)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"
                    INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                    VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";
                connection.Execute(sqlQuery, new
                {
                    CustomerID = data.CustomerID,
                    CompanyName = data.CompanyName,
                    ContactName = data.ContactName,
                    ContactTitle = data.ContactTitle,
                    Address = data.Address,
                    City = data.City,
                    Region = data.Region,
                    PostalCode = data.PostalCode,
                    Country = data.Country,
                    Phone = data.Phone,
                    Fax = data.Fax
                }
                );
            }
        }
    }
}

