using System;

using KestDDD.Domain.Core.Models;

namespace KestDDD.Domain.Models
{
    public class Student : Entity
    {
        protected Student()
        {
        }
        public Student(Guid id, string name, string email, string phone, DateTime birthDate, Address address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
    }
}
