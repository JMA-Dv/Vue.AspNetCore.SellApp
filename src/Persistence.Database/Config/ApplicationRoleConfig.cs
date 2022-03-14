using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();
        }
    }
}
