using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketmasterAPI.Models
{
    namespace TicketmasterAPI.Models
    {
        public class EventSearch
        {
            //cut out Id bc it was giving me an exception. -Sam
            //[Key]
            //public int Id { get; set; }
            public string KeyWord { get; set; }
            public List<EventDetails> Events { get; set; }


            public EventSearch()
            {

            }
            public EventSearch(JToken t)
            {
                //this.KeyWord = t["keyword"].ToString();
                // Stole this list idea from Tommy's API break out. -Sam <3
                this.Events = new List<EventDetails>();
                List<JToken> gigs = t["events"].ToList();
                foreach (JToken x in gigs)
                {
                    EventDetails gig = new EventDetails(x);
                    Events.Add(gig);
                }
            }
        }
    }
}