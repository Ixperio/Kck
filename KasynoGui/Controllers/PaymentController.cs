using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KasynoGui.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Remove()
        {
            return View();
        }
    }
}