using System;
using System.Collections.Generic;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Models;
using eUseControl.Domain.Entities.Vehicle;
using eUseControl.Web.Extension;
using AutoMapper;
using eUseControl.Web.Attribute;
using eUseControl.Domain.Entities.Review;
using eUseControl.Models;

namespace eUseControl.Web.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ISession _session;
        private readonly ISessionAdmin _session_admin;
        public HomeController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();   //session=SessionBL
            _session_admin = bl.GetSessionAdmin();
        }
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            //if(System.Web.HttpContext.Current.GetMySessionObject().Level==eUseControl.Domain.Enums.URole.Admin)
            //{
            //    return RedirectToAction("Admin", "Home");
            //}

            ViewBag.Role = System.Web.HttpContext.Current.GetMySessionObject().Level;
            ViewBag.UserName = System.Web.HttpContext.Current.GetMySessionObject().Username;
            ViewBag.index = "active";
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<VehicleData, Vehicle>());
            var Cardata = _session.GetCars();
            var Reviewdata = _session.GetReviews();

            IndexData indexdata = new IndexData();
            foreach (var car in Cardata)
            {
                indexdata.vehiclesData.vehicles.Add(Mapper.Map<VehicleData>(car));
            }

            Mapper.Reset();
            Mapper.Initialize(rfg => rfg.CreateMap<CustomerReview, UserReview>());
            foreach (var review in Reviewdata)
            {
                indexdata.customerReviews.Reviews.Add(Mapper.Map<CustomerReview>(review));
            }
            return View(indexdata);
        }
        public ActionResult AddReview()
        {
            CustomerReview Review = new CustomerReview
            {
                Message = Request.QueryString["r"],
                Name = System.Web.HttpContext.Current.GetMySessionObject().Username
            };
            Mapper.Reset();
            Mapper.Initialize(rfg => rfg.CreateMap<CustomerReview, UserReview>());
            _session.AddReview(Mapper.Map<UserReview>(Review));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(string btn)
        {
            return RedirectToAction("AddReview", "Home", new { @r = btn });
        }
        public ActionResult Contact()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.UserName = System.Web.HttpContext.Current.GetMySessionObject().Username;
            ViewBag.contact = "active";
            ViewBag.Info_h1 = "Contact Us";
            ViewBag.Info_p = "~ We are waiting for your suggestions! ~";
            return View();
        }
        public ActionResult Cars()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.UserName = System.Web.HttpContext.Current.GetMySessionObject().Username;
            ViewBag.cars = "active";
            ViewBag.Info_h1 = "Our For Rent Cars";
            ViewBag.Info_p = "~ You rent more than a car ~";
            return View();
        }

        [AdminMod]
        public ActionResult DeleteReview(string name)
        {
            _session_admin.DeleteReview(name);
            return RedirectToAction("Index");

        }
        [AdminMod]
        public ActionResult DeleteCar(string name)
        {
            _session_admin.DeleteCar(name);
            return RedirectToAction("Index");
        }

        [AdminMod]
        public ActionResult AddCar()
        {
            return View();
        }
        [AdminMod]
        [HttpPost]
        public ActionResult AddCar(VehicleData car)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<VehicleData, Vehicle>());
            var adding = _session_admin.AddCar(Mapper.Map<Vehicle>(car));
            if (adding.Status)
            {
                return RedirectToAction("SuccessfulOperation");
            }
            else
            {
                ModelState.AddModelError("", adding.StatusMsg);
                return View();
            }
        }
        [AdminMod]
        public ActionResult SuccessfulOperation()
        {
            return View();
        }
    }
}