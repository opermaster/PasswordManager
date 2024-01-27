using Microsoft.EntityFrameworkCore;
using PasswordManagerLogic.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordManagerLogic
{
    public class Context : DbContext
    {
        /// <summary>
        /// Table of services
        /// </summary>
        public DbSet<Service> Services { get; set; } = null!;
        /// <summary>
        /// Table of data
        /// </summary>
        public DbSet<Data> Data { get; set; } = null!;
        public Context() {
           Database.EnsureDeleted();
           Database.EnsureCreated();
        }
        /// <summary>
        /// Using sqlite for small local Db
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
