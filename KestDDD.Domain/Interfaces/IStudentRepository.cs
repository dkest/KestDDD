using KestDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestDDD.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        //一些特有的接口
        Student GetByEmail(string email);
    }
}
