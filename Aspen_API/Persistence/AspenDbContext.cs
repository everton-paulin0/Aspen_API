using Aspen_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspen_API.Persistence
{
    public class AspenDbContext : DbContext
    {
        public AspenDbContext(DbContextOptions<AspenDbContext> options) :base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyComment> CompanyComments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasMany(u=> u.Companies)
                .WithOne(u=> u.FullName)
                .HasForeignKey(u=> u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CompanyComment>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(cc => cc.Company)
                .WithMany(cc => cc.Comments)                
                .HasForeignKey(cc => cc.IdCompany)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(cc => cc.User)
                .WithMany(cc => cc.Comments)
                .HasForeignKey(cc => cc.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Company>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(c => c.FullName)
                .WithMany(c=> c.Companies)
                .HasForeignKey(c=> c.IdContactPerson)
                .OnDelete(DeleteBehavior.Restrict);
            });



            base.OnModelCreating(modelBuilder);     
        }
    }
}
