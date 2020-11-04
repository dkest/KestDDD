using KestDDD.Domain.Interfaces;
using KestDDD.Domain.Models;
using KestDDD.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KestDDD.Infrastruct.Repository
{
    /// <summary>
    /// Student仓储，操作对象还是领域对象
    /// </summary>
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context)
          : base(context)
        {

        }
        //对特例接口进行实现
        public Student GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
