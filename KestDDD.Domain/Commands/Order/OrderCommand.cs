using KestDDD.Domain.Core.Commands;
using KestDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Domain.Commands
{
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}
