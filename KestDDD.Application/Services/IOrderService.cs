using KestDDD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Application.Services
{
    public interface IOrderService : IDisposable
    {
        void Register(OrderViewModel orderViewModel);
        IEnumerable<OrderViewModel> GetAll();
    }
}
