using KestDDD.Domain.Models;

namespace KestDDD.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByName(string name);
    }
}
