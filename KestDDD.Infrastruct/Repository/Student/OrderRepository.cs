using KestDDD.Domain.Interfaces;
using KestDDD.Domain.Models;
using KestDDD.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KestDDD.Infrastruct.Repository
{
    /// <summary>
    /// Student仓储，操作对象还是领域对象
    /// </summary>
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StudyContext context)
          : base(context)
        {

        }
        
        public Order GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
