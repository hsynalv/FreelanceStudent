using FreelanceStudent.Core.Repositories;
using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;
using FreelanceStudent.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Service.Services
{
    public class StudentService : GenericService<Student, StudentDto>, IStudentService
    {
        public StudentService(IStudentDal studentDal, IUnitOfWork unitOfWork) : base(studentDal, unitOfWork)
        {
        }
    }
}
