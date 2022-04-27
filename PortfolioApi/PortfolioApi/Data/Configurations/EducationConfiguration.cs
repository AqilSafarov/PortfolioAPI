using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(x => x.StudtyArea).HasMaxLength(100);
            builder.Property(x => x.NameOfEdu).HasMaxLength(100);
            builder.Property(x => x.EduDesc).HasMaxLength(500);
            builder.Property(x => x.EduStartDate).HasColumnType("DateTime");
        }
    }
}
