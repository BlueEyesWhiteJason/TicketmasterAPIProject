using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    public class EventSearch
    { [Key]
        public int Id { get; set; }
        public string KeyWord { get; set; }


        public EventSearch()
        {

        }
        public EventSearch(JToken t)
        {
            List<EventDetails> evt = new List<EventDetails>();
            foreach (JToken item in t["_embedded"]["events"])
            {
                evt.Add(item["name"].ToString());

                
            }
            //this.Id = int.Parse(t["id"].ToString());
            //this.KeyWord = t["keyword"].ToString(); 
        }
    }
}
