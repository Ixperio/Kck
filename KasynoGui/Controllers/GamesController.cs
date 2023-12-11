using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KasynoGui;
using KasynoGui.Models;

namespace KasynoGui.Controllers
{
   
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Roulette()
        {

            //List<string> myDataList = MyDataStorage.GetMyDataList();
            List<Ruletka> ruletkas = new List<Ruletka>();

            ruletkas.Add(new Ruletka() { Id = 1, date = DateTime.Now, number = 1, GameString = "ojfwefjwof" });
            ruletkas.Add(new Ruletka() { Id = 2, date = DateTime.Now, number = 0, GameString = "ojf3453f" });
            //pobierz pieniazki od gracza


            string userEmail = HttpContext.Session["UserData"] as string;
            string userName = "";
            string userSurname = "";
            decimal Money = 0;
            if (!string.IsNullOrEmpty(userEmail))
            {
                // Użyj DbContext do pobrania danych użytkownika z bazy danych
                using (var dbContext = new YourDbContext())
                {
                    var loggedUser = dbContext.Uzytkownik.FirstOrDefault(u => u.Email == userEmail);

                    if (loggedUser != null)
                    {
                        userName = loggedUser.Name;
                        userSurname = loggedUser.Surname;
                        Money = loggedUser.Money;
                    }
                    else
                    {
                        // Obsłuż sytuację, gdy użytkownik nie istnieje w bazie danych
                    }
                }
            }
            else
            {
                // Obsłuż sytuację, gdy brak danych użytkownika w sesji
                return RedirectToAction("Login", "Login");
            }



            var viewModel = new RuletkaViewModel
            {
                myDataLists = ruletkas,
                Name = userName,
                Surname = userSurname,
                MoneyAmount = Money
            };


            return View("Roulette", viewModel);
        }
        public ActionResult Blackjack()
        {
            return View("Blackjack");
        }
    }
}