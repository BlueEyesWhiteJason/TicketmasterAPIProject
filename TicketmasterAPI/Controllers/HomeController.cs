using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TicketmasterAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TicketmasterAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBModelContext _context;

        public HomeController(DBModelContext context)
        {
            _context = context;
        }
      
        public string CallEventAPI(string KeyWord)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1&keyword=" + KeyWord);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }

        public JToken Parseticketmaster(string text)
        {
            JToken output = JToken.Parse(text);
            return output;
        }

        public List<Event> EventSearch(JToken t)
        {
            //this.KeyWord = t["keyword"].ToString();
            List<Event> EventList = new List<Event>();
            try
            {
                List<JToken> events = t["_embedded"]["events"].ToList();
                foreach (JToken x in events)
                {
                    Event r = new Event();
                    r.Name = x["name"].ToString();
                    r.Url = x["url"].ToString();
                    r.City = x["_embedded"]["venues"][0]["city"]["name"].ToString();
                    r.State = x["_embedded"]["venues"][0]["state"]["stateCode"].ToString();
                    r.GenreName = x["classifications"][0]["genre"]["name"].ToString();
                    r.Date = x["dates"]["start"]["localDate"].ToString();

                    EventList.Add(r);
                }
            }
            catch (NullReferenceException e)
            {
                if(EventList.Count == 0)
                {
                    ViewBag.resultless = "Your search didn't return any results, please try again.";

                }

            }

            return EventList;
        }
        public IActionResult Index()
        {
        
            return View(); 
        }
        public IActionResult SearchResult()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchResult(string KeyWord)
        {
            string text = CallEventAPI(KeyWord);
            JToken t = Parseticketmaster(text);
            List<Event> Events = EventSearch(t);
            
            return View(Events);
        }

        public IActionResult addFavorite(string url)
        {

            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
