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


namespace TicketmasterAPI.Controllers
{
    public class HomeController : Controller
    {
       // List<EventSearch> evt = new List<EventSearch>();
         public string CallEventAPI(string KeyWord)
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
            HttpWebRequest request = WebRequest.CreateHttp("https://app.ticketmaster.com/discovery/v2/events.json?size=10&apikey=dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1&keyword="+KeyWord);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }
        public string CallEventDetailsAPI(int Id)
        {
            string key = "dW7a1zq6RyK4otyVGzTtIQtg6iMU53N1";
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
        public List<EventSearch> FindEventSearch(JToken t)
         {
            List<EventSearch>  evt = new List<EventSearch>();
            foreach (JToken item in t["_embedded"]["events"])
            {
                evt.Add(new EventSearch()
                {
                   // KeyWord = item["keyword"].ToString(),
                    Id = item["id"].ToString(),
                    Name = item["name"].ToString(),
                    Url = item["url"].ToString()
                });

            }

            return evt;
            //this.Id = int.Parse(t["id"].ToString());
            //this.KeyWord = t["keyword"].ToString(); 
        }
    
    public IActionResult SearchResult(string KeyWord)
        {
          
          string text = CallEventAPI(KeyWord);
          JToken t = JToken.Parse(text);
         // var EventList = new List<EventSearch>();

          // EventSearch a = new EventSearch(t);
          //EventList.Add(a);
          //EventSearch b = new EventSearch(t);
          //EventList.Add(b);
           
            return View(FindEventSearch(t));
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult EvDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EvDetails(int Id)
        {
            
            string text = CallEventDetailsAPI(Id);
            JToken t = JToken.Parse(text);
            EventDetails d = new EventDetails(t);

            return View(d);
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
