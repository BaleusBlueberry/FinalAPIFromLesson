using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Data
{
    public class DALContext(DbContextOptions<DALContext> options) : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
    {
        public DbSet<Demo> Demos { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasData([
                    new Category()
                    {
                        Id = 1,
                        Name = "Toys"
                    },new Category()
                    {
                        Id = 2,
                        Name = "Electronics"
                    },new Category()
                    {
                        Id = 3,
                        Name = "Games"
                    }
                ]);

            modelBuilder.Entity<Product>()
                .HasData([
                    new Product()
                    {
                        Id = 1,
                        Name = "MacBook Pro",
                        Description = "A Computer",
                        CategoryId = 2,
                        ImageUrl = "",
                        Price = 555.9M,
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Toy Car",
                        Description = "A Wooden Toy car",
                        CategoryId = 1,
                        ImageUrl = "",
                        Price = 10M,
                    }
                ]);
            modelBuilder.Entity<IdentityRole<int>>()
                .HasData(
                    new IdentityRole<int>()
                    {
                        Id = 1,
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>()
                .HasData(
                    new AppUser()
                    {
                        Id = 1,
                        Email = "baleus@baleus.com",
                        NormalizedEmail = "BALEUS@BALEUS.COM",
                        UserName = "Baleus",
                        NormalizedUserName = "BALEUS",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, "12345678")
                    });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData([
            
                new IdentityUserRole<int>()
                {
                    RoleId = 1,
                    UserId = 1,
                }
            ]);
        }
    }
}