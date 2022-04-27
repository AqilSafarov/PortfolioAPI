using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Configurations
{
    public class SocialConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.Property(x => x.Icon).HasMaxLength(250);
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Link).HasMaxLength(250);
        }
    }
}
