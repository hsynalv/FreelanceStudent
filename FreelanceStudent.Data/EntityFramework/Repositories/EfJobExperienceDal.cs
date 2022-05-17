using FreelanceStudent.Data.Abstract;
using FreelanceStudent.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Data.EntityFramework.Repositories
{
    public class EfJobExperienceDal : RepositoryBase<JobExperience>, IJobExperienceDal
    {
        public EfJobExperienceDal(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
