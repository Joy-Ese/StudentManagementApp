using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;

namespace StudentManagement.Services.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
