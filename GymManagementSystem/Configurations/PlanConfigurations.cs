using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;

namespace GymManagementSystem.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(P => P.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_DurationDaysConstraints",
                    "DurationDays Between 1 and 365")
                );
        }
    }
}