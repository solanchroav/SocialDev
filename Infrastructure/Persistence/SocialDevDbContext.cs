using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SocialDevDbContext : IdentityDbContext<UserAuth>
    {
      
        public SocialDevDbContext(DbContextOptions<SocialDevDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UserData());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAuth> UserAuth { get; set; }

    }
}
