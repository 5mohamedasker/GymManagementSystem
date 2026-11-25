using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class GymUserConfigurations<TUser> : IEntityTypeConfiguration<TUser> where TUser : GymUser
    {
        public void Configure(EntityTypeBuilder<TUser> builder)
        {
            builder.OwnsOne(U => U.Address);

            builder.Property(U => U.Name)
                .HasColumnType("varchar(50)");

            builder.Property(U => U.Email)
                .HasColumnType("varchar(100)");
            builder.HasIndex(U => U.Email).IsUnique();

            builder.ToTable(T => T.HasCheckConstraint
                (
                "CK_EmailConstraint",
                "Email Like '_%@_%._%' ")
                );

            builder.Property(U => U.Phone)
                .HasColumnType("varchar(11)");
            builder.HasIndex(U => U.Phone).IsUnique();


            builder.ToTable(T => T.HasCheckConstraint
                (
                "CK_PhoneConstraint",
                "Len(Phone) = 11 And (Phone Like '010%' or Phone Like '011%' or Phone Like '012%' or Phone Like '015%') ")
                );


        }
    }
}