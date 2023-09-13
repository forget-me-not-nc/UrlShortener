using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbSettings
{
    public class UrlShortenerDbContext : DbContext, IUrlShortenerDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Role> Roles { get; set; }

        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UrlConfig());
        }
    }
}
