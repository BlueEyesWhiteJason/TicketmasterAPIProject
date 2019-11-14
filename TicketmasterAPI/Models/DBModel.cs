using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class FavEvents
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DbId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string GenreName { get; set; }
        public string City { get; set; }
        public string State { get; set; } //use stateCode
        public string UserName { get; set; }
        public List<Users> UserEvents { get; set; }

    }
}
