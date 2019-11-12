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
        public string Id { get; set; }
        public string KeyWord { get; set; }
       public string Name { get; set; }
       public string Url { get; set; }

        public EventSearch()
        {

        }
       /* public EventSearch(JToken t)
        {
            List<EventSearch> evt = new List<EventSearch>();
            foreach (JToken item in t["_embedded"]["events"])
            {
                evt.Add(new EventSearch() {
                    Id = item["id"].ToString(),
                    name = item["name"].ToString(),
                    url = item["url"].ToString()
                });
                
            }
            //this.Id = int.Parse(t["id"].ToString());
            //this.KeyWord = t["keyword"].ToString(); 
        }*/
    }
}
