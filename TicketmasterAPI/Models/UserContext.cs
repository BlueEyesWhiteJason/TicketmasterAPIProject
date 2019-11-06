using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data Source =DESKTOP-0M7F4MC\SQLEXPRESS;Initial Catalog=TicketmasterAPI;Trusted_Connection=True;");
            //Note! I havent run migrations and created this db yet bc I'm unsure if we are going to use the same db for the whole project and just have different tables -sam
        }
    }
}
