using FluentValidation.Results;
using KestDDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Domain.Core.Commands
{
    /// <summary>
    /// 抽象命令基类
    /// </summary>
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
