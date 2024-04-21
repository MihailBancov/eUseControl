using AutoMapper;
using CarRental.BusinessLogic;
using CarRental.BusinessLogic.Interfaces;
using CarRental.Domain.Entities.User;
using CarRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ISession _session;
        public RegistrationController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();   //session=SessionBL
        }
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegistration registrarion)
        {
            if (ModelState.IsValid)
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<UserRegistration, ULoginData>());
                var data = Mapper.Map<ULoginData>(registrarion);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userRegistration = _session.UserRegistration(data);
                if (userRegistration.Status)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", userRegistration.StatusMsg);
                    return View();
                }

            }
            return View();
        }
    }
}