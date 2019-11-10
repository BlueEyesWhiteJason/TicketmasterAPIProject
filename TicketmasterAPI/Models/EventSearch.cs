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
                List<JToken> gigs = t["events"].ToList();
                this.Events = new List<EventDetails>();
                foreach(JToken x in gigs)
                {
                    EventDetails gig = new EventDetails(x);
                    //gig.Id = x["id"].ToString();
                    //gig.Name = x["name"].ToString();
                    //gig.Type = x["type"].ToString();
                    //gig.Distance = double.Parse(x["distance"].ToString());
                    this.Events.Add(gig);
                }


                //foreach(JToken j in t)
                //{
                //    EventDetails x = new EventDetails();
                //    x.Name = j["name"].ToString();
                //    x.Type = j["type"].ToString();
                //    x.Distance = double.Parse(t["distance"].ToString());
                //    this.Events.Add(x);
                //}
            }
        }
    }
}