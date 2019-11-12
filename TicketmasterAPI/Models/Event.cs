using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string GenreName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Event()
        {

        }

        public Event(JToken t)
        {        
            //this.Id = int.Parse(t["id"].ToString());
            this.Name = t["name"].ToString();
            this.Url = t["url"].ToString();
            this.City = t["city"].ToString();
            this.State = t["state"].ToString();

        }
    }

}
