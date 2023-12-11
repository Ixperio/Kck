using KasynoGui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.WebPages;

namespace KasynoGui.Controllers
{
    [SessionState(SessionStateBehavior.Required)]
    public class RegisterController : Controller
    {

            private readonly YourDbContext _dbContext;
            public RegisterController()
            {
                // Inicjalizacja kontrolera, jeśli to konieczne
            }
            public RegisterController(YourDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public ActionResult Register()
            {

                return View("Register");
            }

            [HttpPost]
            public ActionResult Register(RegisterViewModel data)
            {
                if (ModelState.IsValid && data.Password == data.ConfirmPassword && data.Email == data.ConfirmEmail)
                {
                        using (var dbContext = new YourDbContext())
                        {
                            UserModel user = new UserModel()
                            {
                                Name = data.Name,
                                Surname = data.Surname,
                                Email = data.Email,
                                Password = data.Password,
                                Birthday = data.Birthday.AsDateTime(),
                                Phone = data.Phone
                            };

                        dbContext.Uzytkownik.Add(user);
                    
                        dbContext.SaveChanges();

                                // Rekord spełnia warunek
                                HttpContext.Session["UserData"] = data.Email;

                                return RedirectToAction("Index", "Games");
                            }

                }

                        return View("Register");
            }
               
            }
        }
