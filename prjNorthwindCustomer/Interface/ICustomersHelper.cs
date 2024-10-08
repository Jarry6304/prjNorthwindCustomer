using prjNorthwindCustomer.Models;

namespace prjNorthwindCustomer.Interface
{
    public interface ICustomersHelper
    {
        IEnumerable<Customers> selectCustomersInfo(Customers input = null);
    }
}
