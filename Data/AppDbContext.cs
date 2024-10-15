
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ttcm_api.Models;

namespace ttcm_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/app.db");
        }
    }
}