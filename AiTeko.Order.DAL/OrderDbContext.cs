using AiTeko.Order.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiTeko.Order.DAL
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderProductsEntity> OrderProducts { get; set; }
    }
}
