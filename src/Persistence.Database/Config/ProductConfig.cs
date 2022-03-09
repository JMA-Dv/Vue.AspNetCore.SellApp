using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Description).IsRequired().HasMaxLength(150);
        }
    }
}
