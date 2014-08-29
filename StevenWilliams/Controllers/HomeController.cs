using StevenWilliams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StevenWilliams.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioModel db = new PortfolioModel();
        public ActionResult Index()
        {
            HomePageViewModel dvm = new HomePageViewModel();
            dvm.JobHistories = db.JobHistories.ToList();
            dvm.Skills = db.Skills.ToList();
            return View(dvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Info";

            return View();
        }
    }
}