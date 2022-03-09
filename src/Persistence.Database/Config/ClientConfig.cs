using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
