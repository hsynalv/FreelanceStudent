using FreelanceStudent.Core.Repositories;
using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Service.Abstract;

namespace FreelanceStudent.Service.Services
{
    public class ProgrammingLanguageService : GenericService<ProgrammingLanguage, ProgrammingLanguageDto>, IProgrammingLanguageService
    {
        public ProgrammingLanguageService(IProgrammingLanguageDal programmingLanguageDal, IUnitOfWork unitOfWork) : base(programmingLanguageDal, unitOfWork)
        {
        }
    }
}
