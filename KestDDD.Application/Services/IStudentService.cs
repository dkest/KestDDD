using KestDDD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Application.Services
{
    public interface IStudentService : IDisposable
    {
        void Register(StudentViewModel studentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel studentViewModel);
        void Remove(Guid id);
    }
}
