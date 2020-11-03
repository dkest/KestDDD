using KestDDD.Domain.Commands.Order;

namespace KestDDD.Domain.Validations
{
    /// <summary>
    /// 添加学生命令模型验证
    /// 继承 OrderValidation 基类
    /// </summary>
    public class RegisterOrderCommandValidation : OrderValidation<RegisterOrderCommand>
    {
        public RegisterOrderCommandValidation()
        {
            ValidateName();//验证姓名
        }
    }
}