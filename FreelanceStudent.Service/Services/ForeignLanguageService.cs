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
    public class ForeignLanguageService : GenericService<ForeignLanguage, ForeignLanguageDto>, IForeignLanguageService
    {
        public ForeignLanguageService(IForeignLanguageDal foreignLanguageDal, IUnitOfWork unitOfWork) : base(foreignLanguageDal, unitOfWork)
        {
        }
    }
}
