using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FreelanceStudent.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceStudent.Data.EntityFramework.Configuration
{
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.AdvertId);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x=>x.Detail).IsRequired();
            builder.Property(x=>x.Price).IsRequired().HasColumnType("Decimal(18,2)");
            builder.Property(x=>x.Deadline).IsRequired();
            builder.Property(x => x.CreatedTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsActivated).HasDefaultValue(true);

            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Adverts)
                .HasForeignKey(x=>x.CategoryId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Adverts)
                .HasForeignKey(x => x.UserId);

        }
    }
}
