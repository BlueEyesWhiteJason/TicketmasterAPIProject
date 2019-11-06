using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data Source =DESKTOP-0M7F4MC\SQLEXPRESS;Initial Catalog=User;Trusted_Connection=True;");
            //NOTE! I haven't made migrations yet to build out the db. Unsure if we will use the same db for User and API data.
        }
    }
}
