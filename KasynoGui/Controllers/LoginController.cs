using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.AspNetCore.Http;
using KasynoGui.Models;

namespace KasynoGui.Controllers
{
    [SessionState(SessionStateBehavior.Required)]
    public class LoginController : Controller
    {

        private readonly YourDbContext _dbContext;
        public LoginController()
        {
            // Inicjalizacja kontrolera, jeśli to konieczne
        }
        public LoginController(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Login data)
        {
            if(ModelState.IsValid)
            {
                if (data.Email != null && data.Password != null)
                {

                    using (var dbContext = new YourDbContext())
                    {
                        bool istniejeRekord = dbContext.Uzytkownik.Any(u => u.Email == data.Email && u.Password == data.Password);
                        // Możesz dodać inne warunki do sprawdzenia

                        if (istniejeRekord)
                        {
                            // Rekord spełnia warunek
                            HttpContext.Session["UserData"] = data.Email;

                            return RedirectToAction("Index", "Games");
                        }

                    }

                    return View("Login");
                }
                else
                {
                    return View("Login");
                }


            }
            else
            {
                // Jeśli dane są niepoprawne, wyświetl błąd
                ModelState.AddModelError("", "Invalid login attempt");
                return View(data);
            }
        }
                

        }
    }
