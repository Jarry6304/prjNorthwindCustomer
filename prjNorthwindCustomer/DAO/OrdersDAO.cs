using Microsoft.Data.SqlClient;
using Dapper;

namespace prjNorthwindCustomer.DAO
{
    internal class OrdersDAO
    {
        private string _connectionString { get; set; }
        internal OrdersDAO(string connection)
        {
            _connectionString = connection;
        }
        internal bool hasOrder(string customerID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT COUNT(*) FROM Orders O JOIN Customers C ON O.CustomerID = C.CustomerID WHERE O.CustomerID = @CustomerID";
                var count = connection.ExecuteScalar<int>(sqlQuery, new { CustomerID = customerID });
                if (count < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
