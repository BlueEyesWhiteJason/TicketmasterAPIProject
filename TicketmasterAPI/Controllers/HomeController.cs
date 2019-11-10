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
using TicketmasterAPI.Models.TicketmasterAPI.Models;

namespace TicketmasterAPI.Controllers
{
    public class HomeController : Controller
    {
        public string CallEventAPI(string KeyWord)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?size=1&apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1&keyword="+KeyWord);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }
        public string CallEventDetailsAPI(int Id)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1&id=" + Id);
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
        public IActionResult EvSearch()
        {
            return View();
        }
        [HttpPost]
        // changed the title of this Action from EvSearch to EvDetails -Sam
        public IActionResult EvDetail(string KeyWord)
        {
            string text = CallEventAPI(KeyWord);
            JToken t = JToken.Parse(text);
            EventSearch a = new EventSearch(t);
            return View(a);
        }
        //public IActionResult EvDetail()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult EvDetail(int Id)
        //{
            
        //    string text = CallEventDetailsAPI(Id);
        //    JToken t = JToken.Parse(text);
        //    EventDetails d = new EventDetails(t);

        //    return View(d);
        //}
        public IActionResult Index()
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
