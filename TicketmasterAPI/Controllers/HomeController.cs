using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketmasterAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TicketmasterAPI.Controllers
{
    public class HomeController : Controller
    {
        public string CallEventAPI()
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?size=1&apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }
        public string CallEventDetailsAPI()
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events/G5diZfkn0B-bh.json?apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;

        }
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
