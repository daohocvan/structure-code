using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Structure.Domain.Entities.Identity;
using Structure.Persistence.Constants;

namespace Structure.Persistence.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(TableNames.Permissions);

            builder.HasKey(x => new { x.RoleId, x.FunctionId, x.ActionId });
        }
    }
}