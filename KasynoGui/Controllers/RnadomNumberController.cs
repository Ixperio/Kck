using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using KasynoGui;
using KasynoGui.Models;
using Newtonsoft.Json;

namespace KasynoGui.Controllers
{
    public class RandomNumberController : Controller
    {
       
        // GET: Roulette
        public ActionResult Index()
        {
            int randomNumber;
            string res = "";
            if (HttpContext.Cache["RandomNumber"] == null)
            {
                Random random = new Random();
                randomNumber = random.Next(74, 111);
                HttpContext.Cache.Insert("RandomNumber", randomNumber, null, DateTime.Now.AddSeconds(45), Cache.NoSlidingExpiration);


                const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                StringBuilder result = new StringBuilder(22);

                for (int i = 0; i < 22; i++)
                {
                    result.Append(Chars[random.Next(Chars.Length)]);
                }

                int[] numbers = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };

                WhoWin(numbers[(randomNumber + 5 )% 37], result.ToString());
                res = result.ToString();
            }
            else
            {
                randomNumber = (int)HttpContext.Cache["RandomNumber"];
            }
                 var data = new { content = randomNumber, gs = res };

            return Json(data,JsonRequestBehavior.AllowGet);
        }
        private void WhoWin(int number, string gs)
        {

            //dodanie do bazy 
            using (var dbContext = new YourDbContext())
            {
                Ruletka gra = new Ruletka()
                {
                    GameString = gs,
                    date = DateTime.Now,
                    number = number
                };

                dbContext.Ruletka.Add(gra);

                dbContext.SaveChanges();

            }

            //updateuje wszystkim ktorzy wygrali

            using (var dbContext = new YourDbContext())
            {
              var userIds = dbContext.RuletkaBets
             .Where(bet => bet.number == number && bet.IdZakldu == 1)
             .Select(bet => bet.UserId)
             .Distinct()
             .ToList();

                foreach (var user in userIds)
                {
                    UserModel useradd = dbContext.Uzytkownik.Where(x => x.Id == user).FirstOrDefault();

                    if (useradd != null)
                    {
                        decimal money = dbContext.RuletkaBets.Where(x => x.UserId == user).FirstOrDefault().price;
                        useradd.Money += (money) * 35;
                    }

                    dbContext.SaveChanges();
                }

            }

            //na kolor
            using (var dbContext = new YourDbContext())
            {

                var userIds = dbContext.RuletkaBets
               .Where(bet => bet.IdZakldu == 2)
               .Select(bet => bet.UserId)
               .Distinct()
               .ToList();

                foreach (var user in userIds)
                {
                    UserModel useradd = dbContext.Uzytkownik.Where(x => x.Id == user).FirstOrDefault();

                    if (useradd != null)
                    {
                        decimal money = dbContext.RuletkaBets.Where(x => x.UserId == user).FirstOrDefault().price;
                        useradd.Money += (money) * 2;
                    }

                    dbContext.SaveChanges();
                }

            }

        }

        [HttpGet]
        public ActionResult LastBets()
        {

            int[] numbers = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };

            List<RuletkaView> data = new List<RuletkaView>();
            var latestRecords = new List<Ruletka>();

            using (var dbContext = new YourDbContext())
            {
                latestRecords = dbContext.Ruletka.OrderByDescending(e => e.date).Take(10).ToList();
            }

            // Przekształć dane do formatu RuletkaView
            data = latestRecords.Select(record => new RuletkaView
            {
                number = record.number,
                date = record.date.ToString("yyyy-MM-dd HH:mm:ss"),
                GameString = getColor(record.number)
            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlaceBet(RuletkaBets bet)
        {

            if (ModelState.IsValid)
            {

                    using (var dbContext = new YourDbContext())
                    {

                    UserModel useradd = dbContext.Uzytkownik.Where(x => x.Id == 1).FirstOrDefault();

                    decimal p = useradd.Money;

                    if (p >= bet.price)
                    {
                        RuletkaBets newbet = new RuletkaBets()
                        {
                            IdZakldu = bet.IdZakldu,
                            number = bet.number,
                            price = bet.price,
                            UserId = 1
                        };

                        dbContext.RuletkaBets.Add(bet);
                        
                        useradd.Money = p-bet.price;

                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return null;
                    }

                }
               
            }
            return null;
        }

        private string getColor(int numb)
        {
            int[] reds = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 34, 36 };
       

            if (numb == 0)
            {
                // Jeśli numb wynosi 0, zwróć "green"
                return "#5AB52F";
            }
            else if (!reds.Contains(numb))
            {
                return "black";
            }
            else
            {
                return "#B52F2F";
      
            }
        }

    }

   

}