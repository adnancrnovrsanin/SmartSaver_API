using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<RunPeriod> RunPeriods { get; set; }
        public DbSet<FieldRow> FieldRows { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}