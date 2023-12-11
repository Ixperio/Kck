using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using KasynoGui.Models;

namespace KasynoGui.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }


    }
}