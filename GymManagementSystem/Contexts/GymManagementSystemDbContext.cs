using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace GymManagementSystem.Contexts
{
    public class GymManagementSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = GymManagementSystem; Trusted_Connection = True; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}
