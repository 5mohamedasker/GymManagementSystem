using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Collections.Specialized.BitVector32;

namespace GymManagementSystem.Configurations
{
    public class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne(S => S.Trainer)
                .WithMany(T => T.Sessions)
                .HasForeignKey(S => S.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(S => S.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_CapacityConstraint",
                    "Capacity Between 1 and 25")
                );

            builder.ToTable(T => T.HasCheckConstraint
                (
                    "ck_StartEndDateConstraint",
                    "EndDate > StartDate")
                );

        }
    }
}