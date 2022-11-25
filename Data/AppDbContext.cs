using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class AppDbContext : DbContext 
    {
        public DbSet<TodoModel> Todos { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }