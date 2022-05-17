using FreelanceStudent.Core.Repositories;
using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Service.Services
{
    public class ProgrammingLanguageService : GenericService<ProgrammingLanguage, ProgrammingLanguageDto>
    {
        public ProgrammingLanguageService(IRepositoryBase<ProgrammingLanguage> repositoryBase, IUnitOfWork unitOfWork) : base(repositoryBase, unitOfWork)
        {
        }
    }
}
