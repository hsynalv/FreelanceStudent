using System.Collections.Generic;
using FreelanceStudent.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceStudent.Data.EntityFramework.Configuration
{
    public class BackgroundConfiguration : IEntityTypeConfiguration<Background>
    {
        public void Configure(EntityTypeBuilder<Background> builder)
        {
            builder.HasKey(x => x.BackgroundId);

            builder.HasOne(x => x.Student)
                .WithOne(s => s.Background)
                .HasForeignKey<Student>(bg => bg.UserId);

            builder.HasData(new Background
            {
                BackgroundId = 1,
                Department = "Software Engineer",
            });
        }
    }
}