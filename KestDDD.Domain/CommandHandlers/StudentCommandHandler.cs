using KestDDD.Domain.Commands;
using KestDDD.Domain.Core.Bus;
using KestDDD.Domain.Core.Notifications;
using KestDDD.Domain.Events;
using KestDDD.Domain.Interfaces;
using KestDDD.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KestDDD.Domain.CommandHandlers
{
    /// <summary>
    /// Student命令处理程序
    /// 用来处理该Student下的所有命令
    /// 注意必须要继承接口IRequestHandler<,>，这样才能实现各个命令的Handle方法
    /// </summary>
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, bool>,
        IRequestHandler<UpdateStudentCommand, bool>,
        IRequestHandler<RemoveStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;

        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork uow,
                                      IMediatorHandler bus) : base(uow, bus)
        {
            _studentRepository = studentRepository;
            _uow = uow;
            _bus = bus;
        }

        // RegisterStudentCommand命令的处理程序
        // 整个命令处理程序的核心都在这里
        // 不仅包括命令验证的收集，持久化，还有领域事件和通知的添加
        public Task<bool> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                // 返回，结束当前线程
                return Task.FromResult(false);
            }
            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(request.Province, request.City, request.County, request.Street);
            var student = new Student(Guid.NewGuid(), request.Name, request.Email, request.Phone, request.BirthDate, address);

            // 判断邮箱是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_studentRepository.GetByEmail(student.Email) != null)
            {
                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(false);
            }

            // 持久化
            _studentRepository.Add(student);

            // 统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new StudentRegisteredEvent(student.Id, student.Name, student.Email, student.BirthDate, student.Phone));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var address = new Address(request.Province, request.City,
            request.County, request.Street);
            var student = new Student(request.Id, request.Name, request.Email, request.Phone, request.BirthDate, address);
            var existingStudent = _studentRepository.GetByEmail(student.Email);

            if (existingStudent != null && existingStudent.Id != student.Id)
            {
                if (!existingStudent.Equals(student))
                {
                    _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                    return Task.FromResult(false);
                }
            }

            _studentRepository.Update(student);

            if (Commit())
            {
                _bus.RaiseEvent(new StudentUpdatedEvent(student.Id, student.Name, student.Email, student.BirthDate, student.Phone));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            _studentRepository.Remove(request.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new StudentRemovedEvent(request.Id));
            }

            return Task.FromResult(true);
        }

        // 手动回收
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
