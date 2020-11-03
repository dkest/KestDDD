using KestDDD.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Domain.Commands
{
    public class UpdateStudentCommand : StudentCommand
    {
        public UpdateStudentCommand(Guid id, string name, string email, DateTime birthDate, string phone, string province, string city, string county, string street)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
