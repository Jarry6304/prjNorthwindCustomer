namespace prjNorthwindCustomer.DAO
{
    internal class CustomersDAO
    {
        private string _connectionString { get; set; }
        internal CustomersDAO(string connection)
        {
            _connectionString = connection;
        }
    }
}
