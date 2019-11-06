using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class EventDetails
    {   [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public EventDetails()
        {

        }
        public EventDetails(JToken t)
        {
            this.Id = int.Parse(t["id"].ToString());
            this.Name = t["name"].ToString();
            this.Type = t["type"].ToString();
            this.Distance = double.Parse(t["distance"].ToString());

        }
    }
}
