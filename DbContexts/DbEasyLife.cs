using Microsoft.EntityFrameworkCore;
using Models;
using System.Configuration;

namespace DbContexts
{
    public class DbEasyLife : DbContext
    {
        public DbEasyLife() : base()
        {

        }

        public virtual DbSet<YouBikeSite> YouBikeSites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.DbEasyLife);
        }
    }
}
