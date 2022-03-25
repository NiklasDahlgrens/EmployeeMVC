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

namespace EmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        string _baseURL = "http://localhost:50733/api/Employee";
        public async Task<IActionResult> Index()
        {
            List<Employee> EmployeesList = new List<Employee>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseURL);
                    HttpResponseMessage response = await client.GetAsync("Employee");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        EmployeesList = JsonConvert.DeserializeObject<List<Employee>>(content);
                    }
                    else
                        ViewBag.Message = "Tyvärr gick något fel: " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Tyvärr gick något fel: " + ex.Message;
            }
            return View(EmployeesList);
        }
   


        public async Task<IActionResult> Loggain()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Loggain(string username, string password)
        {
            try
            {
               
                var url = "http://193.10.202.75/LoginAPI/"+ $"Authenticate?Username={username}&Password={password}";
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Login failed");
                    return View();
                }
                var content = await response.Content.ReadAsStringAsync();
                var recievedLogin = JsonConvert.DeserializeObject<LoginDetails>(content);
                Debug.WriteLine("Login successful");
                //göra inloggning

                // Allt stämmer, logga in användaren
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, recievedLogin.Username));



                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

                return View(recievedLogin);
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Login failed: " + e.StackTrace);
                return null;
            }
        }
      
            

    }



}