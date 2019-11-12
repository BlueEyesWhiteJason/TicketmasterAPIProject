using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class DBModelContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<FavEvents> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.\\SQLExpress;Database=TicketDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DBModelContext(DbContextOptions<DBModelContext> options)
    : base(options)
        { }
    }
}
