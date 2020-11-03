using KestDDD.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Domain.Events
{
    public class StudentRemovedEvent : Event
    {
        public StudentRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}