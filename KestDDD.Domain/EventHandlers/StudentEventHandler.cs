using System.Threading;
using System.Threading.Tasks;

using KestDDD.Domain.Events;
using MediatR;

namespace KestDDD.Domain.EventHandlers
{
    public class StudentEventHandler :
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentRemovedEvent>
    {
        // 学生被注册成功后的事件处理方法
        public Task Handle(StudentRegisteredEvent request, CancellationToken cancellationToken)
        {
            // 恭喜您，注册成功，欢迎加入我们。

            return Task.CompletedTask;
        }

        // 学生被修改成功后的事件处理方法
        public Task Handle(StudentUpdatedEvent request, CancellationToken cancellationToken)
        {
            // 恭喜您，更新成功，请牢记修改后的信息。

            return Task.CompletedTask;
        }

        // 学习被删除后的事件处理方法
        public Task Handle(StudentRemovedEvent request, CancellationToken cancellationToken)
        {
            // 您已经删除成功啦，记得以后常来看看。

            return Task.CompletedTask;
        }
    }
}