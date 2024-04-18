using eUseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserRegistration u = new UserRegistration();
            u.UserName = "Customer";
            u.Products = new List<string> { "Product #1", "Product #2" };
            return View(u);
        }
    }
}