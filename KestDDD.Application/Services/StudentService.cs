using AutoMapper;
using KestDDD.Application.ViewModels;
using KestDDD.Domain.Commands;
using KestDDD.Domain.Core.Bus;
using KestDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Application.Services
{
    /// <summary>
    /// 作为调度者，协调领域层和基础层，
    /// 这里只是做一个面向用户用例的服务接口,不包含业务规则或者知识
    /// </summary>
    public class StudentService : IStudentService
    {
        // 注意这里是要IoC依赖注入的，还没有实现
        private readonly IStudentRepository _studentRepository;
        // 用来进行DTO
        private readonly IMapper _mapper;
        // 中介者 总线
        private readonly IMediatorHandler _bus;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IMediatorHandler bus)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public IEnumerable<StudentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel studentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterStudentCommand>(studentViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveStudentCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateStudentCommand>(studentViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
