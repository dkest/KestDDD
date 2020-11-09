using AutoMapper;
using KestDDD.Application.ViewModels;
using KestDDD.Domain.Commands.Order;
using KestDDD.Domain.Core.Bus;
using KestDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KestDDD.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        // 用来进行DTO
        private readonly IMapper _mapper;
        // 中介者 总线
        private readonly IMediatorHandler _bus;

        public OrderService(IOrderRepository OrderRepository, IMapper mapper, IMediatorHandler bus)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            var orders = _OrderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_OrderRepository.GetById(id));
        }

        public void Register(OrderViewModel OrderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterOrderCommand>(OrderViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
