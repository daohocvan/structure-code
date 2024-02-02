using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Structure.Domain.Entities.Identity;
using Structure.Persistence.Constants;

namespace Structure.Persistence.Configurations
{
    public class ActionInFunctionConfiguration : IEntityTypeConfiguration<ActionInFunction>
    {
        public void Configure(EntityTypeBuilder<ActionInFunction> builder)
        {
            builder.ToTable(TableNames.ActionInFunctions);

            builder.HasKey(x => new { x.ActionId, x.FunctionId });
        }
    }
}