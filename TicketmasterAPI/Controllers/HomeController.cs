﻿using System;
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
        public string CallEventAPI(string City)
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?size=1&apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }
        public string CallEventDetailsAPI(int Id)
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events/G5diZfkn0B-bh.json?apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1");
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
        public IActionResult EvSearch(string City)
        {
            string text = CallEventAPI(City);
            JToken t = JToken.Parse(text);
            EventSearch a = new EventSearch(t);

            return View(a);
        }
        public IActionResult EvDetail(int Id)
        {
            string text = CallEventDetailsAPI(Id);
            JToken t = JToken.Parse(text);
            EventDetails d = new EventDetails(t);

            return View(d);
        }
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
