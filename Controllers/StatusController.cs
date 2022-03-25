using EmployeeMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net;
// Blivit inspererade av https://stackoverflow.com/questions/5378429/check-if-a-url-is-reachable-help-in-optimizing-a-class

namespace StatusController.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index(int id)
        {
            return CheckAPI(id);

            IActionResult CheckAPI(int id)
            {
                if (id > 0)
                {
                    if (id == 1)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.71/GroupOne_WebApi/swagger/index.html"); // Använder sig av klassen HttpWebRequest, klassen försöker anropa en webrequest för att få kontakt med API:et
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) // Metoden GetResponse används för att få ett response ifrån WebbAdressen/API
                            {
                                if (response.StatusCode == HttpStatusCode.OK) // Om anslutning är Okej så kommer länken bli grön. 
                                {
                                    ViewBag.Color1 = "Green";
                                }
                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color1 = "Red"; // Om det blir Exception så fångar den i denna catchen och bli röd. 
                            return View();
                        }
                    }
                    if (id == 2)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.72/LocalScheduleServiceAPI/swagger/index.html");
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    ViewBag.Color2 = "Green";
                                }

                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color2 = "Red";
                            return View();
                        }
                    }
                    if (id == 3)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.73/HostAPI/swagger/index.html");
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    ViewBag.Color3 = "Green";
                                }

                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color3 = "Red";
                            return View();
                        }
                    }
                    if (id == 4)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.74/EventAPI1/swagger/index.html");
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    ViewBag.Color4 = "Green";
                                }

                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color4 = "Red";
                            return View();
                        }
                    }
                    if (id == 5)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.75/LoginAPI/swagger/index.html");
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    ViewBag.Color5 = "Green";
                                }

                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color5 = "Red";
                            return View();
                        }
                    }
                    if (id == 6)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://193.10.202.76/SponsorsAPI/swagger/index.html");
                        request.Timeout = 15000;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    ViewBag.Color6 = "Green";
                                }

                                return View();
                            }
                        }
                        catch (WebException)
                        {
                            ViewBag.Color6 = "Red";
                            return View();
                        }
                    }
                }
                return View();
            }
        }
    }
}
