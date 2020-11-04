using AutoMapper;
using KestDDD.Application.ViewModels;
using KestDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Application
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 构造函数 用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(t => t.County, o => o.MapFrom(s => s.Address.County))
                .ForMember(t => t.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(t => t.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(t => t.Street, o => o.MapFrom(s => s.Address.Street));

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, OrderItem>();
        }
    }
}
