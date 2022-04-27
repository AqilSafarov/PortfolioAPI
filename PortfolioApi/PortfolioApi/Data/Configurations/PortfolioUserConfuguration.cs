using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Configurations
{
    public class PortfolioUserConfuguration : IEntityTypeConfiguration<PortfolioUser>
    {
        public void Configure(EntityTypeBuilder<PortfolioUser> builder)
        {

            builder.Property(x => x.Image).HasMaxLength(250);
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(25).IsRequired();
            builder.Property(x => x.DescAbut).HasMaxLength(500);
            builder.Property(x => x.Position).HasMaxLength(20);
            builder.Property(x => x.Age).HasColumnType("tinyint");
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Nationality).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.Freelance).HasColumnType("bit");
            builder.Property(x => x.ExperienceYear).HasColumnType("tinyint");
            builder.Property(x => x.ProjectCount);
        }
    }
}
