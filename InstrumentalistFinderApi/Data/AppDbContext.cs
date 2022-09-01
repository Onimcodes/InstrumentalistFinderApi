using InstrumentalistFinderApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstrumentalistFinderApi.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)       
        {

        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Message = "I need a church to play for. No fees " });
            modelBuilder.Entity<Post>().HasData(
    new Post { Id = 2, Message = "Im a professional drummer looking for a choir to grow with. No fees required" });
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 3, Message = "I'm available for programmes. Dm to discuss fees " });
            modelBuilder.Entity<Post>().HasData(
    new Post { Id = 4, Message = "On my way to a church programme " });
            modelBuilder.Entity<Post>().HasData(
    new Post { Id = 5, Message = "I need a church to play for. " });
        }
    }
}
