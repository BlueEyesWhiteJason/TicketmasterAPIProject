using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class EventDetails
    {   
        // changed Id to a string, also removed [key] not to sure how to deal with that yet -sam <3
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public EventDetails()
        {

        }
        public EventDetails(JToken t)
        {
            // Changed Id to a string instead of an int. It has charaters in it from the API. -Sam <3
            this.Id = t["id"].ToString();
            this.Name = t["name"].ToString();
            this.Type = t["type"].ToString();
            //this.Distance = double.Parse(t["distance"].ToString());
        }
    }
}
