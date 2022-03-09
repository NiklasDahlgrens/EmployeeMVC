using EmployeeMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVC.Controllers
{
    public class CreateAccount : Controller
    {
       
        // GET: CreateAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateAccount/Create
        public ActionResult Create()
        {
            return View();
        }
        
       // ------------------------------------------------------------------------------------------------------------------------------
       
        //Ändra till eran baseURL (sista siffran till eran server)
        string _baseURL = "http://193.10.202.75/";
       
        // POST: CreateAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModelView userViewModel) //Länka in eran egna ViewModel här
        {

           try
            { 
                //Ändra objektnamnet utefter vad ni har döpt ert objekt till (newUser i vårt fall kanske heter newHost eller dylikt)
                Employee recievedUser = new Employee();
                Employee newUser  = new Employee();

                newUser.FirstName = userViewModel.FirstName;
                newUser.LastName = userViewModel.LastName;
                newUser.SecNumber = userViewModel.SecNumber;
                newUser.TelephoneNr = userViewModel.TelephoneNr;
                newUser.Role = userViewModel.Role;



                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseURL);
                   
                    StringContent content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                   //Ändra länktext till eran respektive länk/fortsättning på baseURL (Employee/... ---> t.ex Host/api)
                    using (var reponse = await httpClient.PostAsync("EmployeeAPI/api/Employee", content))
                    {
                        string ApiResponse = await reponse.Content.ReadAsStringAsync();
                       // Ändra Employee till erat Modelnamn (Employee --> t.ex Host)
                        recievedUser = JsonConvert.DeserializeObject<Employee>(ApiResponse);
                    }

                }
                //--------------------------------------------------------------------------------------------------------------------------------------------
                //Behåll den här koden då det är den som skapar ett unikt konto på vår authenticationapi
                    //Anropa API
                    LoginDetails newUserRegistration = new LoginDetails();

                    
                
                newUserRegistration.Username = userViewModel.Username;
                newUserRegistration.Password = userViewModel.Password;
                newUserRegistration.AccessLevel = userViewModel.AccessLevel;
                newUserRegistration.UserId = recievedUser.Id;

                using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(newUserRegistration), Encoding.UTF8, "application/json");

                    //Ändra länkadressen till vår adress: "http://193.10.202.75/LoginAPI/api/LoginDetails"
                    httpClient.BaseAddress = new Uri(_baseURL);
                        using (var reponse = await httpClient.PostAsync("LoginAPI/api/LoginDetails", content))
                        {
                            string ApiResponse = await reponse.Content.ReadAsStringAsync();
                            LoginDetails RecievedLogin = JsonConvert.DeserializeObject<LoginDetails>(ApiResponse);
                        }
                    }
                }
             
            catch (Exception ex)
            {
                ViewBag.Message = "Tyvärr gick något fel: " + ex.Message;
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: CreateAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
