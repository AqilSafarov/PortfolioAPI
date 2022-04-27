using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Configurations
{
    public class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.Property(x => x.ExpArea).HasMaxLength(100);
            builder.Property(x => x.NameOfExp).HasMaxLength(100);
            builder.Property(x => x.Desc).HasMaxLength(500);
            builder.Property(x => x.StartDate).HasColumnType("DateTime");
        }
    }
}
