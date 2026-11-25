using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GymManagementSystem.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(M => M.CreatedAt).HasDefaultValueSql("GetDate()");

            builder.Ignore(M => M.Status);
        }
    }
}
