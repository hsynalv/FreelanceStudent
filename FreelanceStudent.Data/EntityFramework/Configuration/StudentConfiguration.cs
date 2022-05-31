using FreelanceStudent.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Data.EntityFramework.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);
           
            //builder.Property(x => x.NationalityId)
            //    .IsRequired();
            
            //builder.Property(x => x.DateOfBirth)
            //    .IsRequired();
        }
    }
}
