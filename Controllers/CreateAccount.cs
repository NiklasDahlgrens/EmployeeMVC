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
        string _baseURL = "193.10.202.75/api/Employee";

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

        // POST: CreateAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ModelView user)
        {

            try
            {
                Employee recievedUser = new Employee();
                Employee newUser  = new Employee();

                newUser.FirstName = user.FirstName;
                newUser.LastName = user.Password;
                newUser.SecNumber = user.SecNumber;
                newUser.TelephoneNr = user.TelephoneNr;
                newUser.Role = user.Role;



                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                
                 using (var reponse = await httpClient.PostAsync(_baseURL, content))
                    {
                        string ApiResponse = await reponse.Content.ReadAsStringAsync();
                        recievedUser = JsonConvert.DeserializeObject<Employee>(ApiResponse);

                    }

                    //Anropa API
                    LoginDetails newUserRegistration = new LoginDetails();
     
                    newUserRegistration.Username = user.Username;
                    newUserRegistration.Password = user.Password;
                    newUserRegistration.AccessLevel = user.AccessLevel;
                    newUserRegistration.UserId = recievedUser.Id;

                    //Call API

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

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
