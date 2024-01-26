using Microsoft.EntityFrameworkCore;
using PasswordManagerLogic.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordManagerLogic
{
    public class Context : DbContext
    {
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Data> Data { get; set; } = null!;
        public Context() {
           Database.EnsureDeleted();
           Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
