using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;
using FreelanceStudent.Service.Abstract;

namespace FreelanceStudent.Service.Services
{
    public class BackgroundService : GenericService<Background, BackgroundDto>, IBackgroundService
    {
        public BackgroundService(IBackgroundDal backgorundDal, IUnitOfWork unitOfWork) : base(backgorundDal, unitOfWork)
        {
        }
    }
}
