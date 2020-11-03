using KestDDD.Domain.Core.Commands;
using System;

namespace KestDDD.Domain.Commands
{
    public abstract class StudentCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Phone { get; protected set; }

        public string Province { get; protected set; }
        public string City { get; protected set; }
        public string County { get; protected set; }
        public string Street { get; protected set; }
    }
}
