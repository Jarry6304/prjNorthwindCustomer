using Dapper;
using Microsoft.Data.SqlClient;
using prjNorthwindCustomer.Models;
using System;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        internal void updateCustomer(Customers data)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"
                    UPDATE Customers SET 
                        CompanyName = COALESCE(@CompanyName, CompanyName),
                        ContactName = COALESCE(@ContactName, ContactName),
                        ContactTitle = COALESCE(@ContactTitle, ContactTitle),
                        Address = COALESCE(@Address, Address),
                        City = COALESCE(@City, City),
                        Region = COALESCE(@Region, Region),
                        PostalCode = COALESCE(@PostalCode, PostalCode),
                        Country = COALESCE(@Country, Country),
                        Phone = COALESCE(@Phone, Phone),
                        Fax = COALESCE(@Fax, Fax)
                    WHERE 
                        CustomerID = @CustomerID";
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

        internal void deleteCustomer(string customerID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                connection.Execute(sqlQuery, new
                {
                    CustomerID = customerID
                }
                );
            }
        }

        internal IEnumerable<Customers> getCustomersInfo(Customers data)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"
                    SELECT * FROM Customers 
                    WHERE (@CustomerID IS NULL OR CustomerID = @CustomerID)
                    AND (@CompanyName IS NULL OR CompanyName LIKE '%' + @CompanyName + '%')";
                var result = connection.Query<Customers>(sqlQuery, new
                {
                    CustomerID = string.IsNullOrEmpty(data.CustomerID)?(string)null : data.CustomerID,
                    CompanyName = string.IsNullOrEmpty(data.CompanyName) ? (string)null : data.CompanyName
                }
                );
                return result;
            }
        }

        internal bool hasCustomer(string customerID) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
                var count = connection.ExecuteScalar<int>(sqlQuery, new { CustomerID = customerID });
                if (count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

