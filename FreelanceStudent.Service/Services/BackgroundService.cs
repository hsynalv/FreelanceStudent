using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;
using FreelanceStudent.Service.Abstract;

namespace FreelanceStudent.Service.Services
{
    public class BackgroundService : GenericService<Background, BackgroundDto>, IBackgroundService
    {
        public BackgroundService(IBackgroundDal backgroundDal, IUnitOfWork unitOfWork) : base(backgroundDal, unitOfWork)
        {
        }
    }
}
