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

namespace TicketmasterAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string eventName = CallDiscoveryAPI();
            JToken p = ParseJsonString(eventName);
            return View();
        }

        private JToken ParseJsonString(string eventName)
        {
            throw new NotImplementedException();
        }

        public string CallDiscoveryAPI()
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp($"https://app.ticketmaster.com/discovery/v2/events.json?apikey={key}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //This will convert the response to a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string APIText = rd.ReadToEnd();

            return APIText;
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
