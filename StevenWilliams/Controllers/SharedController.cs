using StevenWilliams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StevenWilliams.Controllers
{
    public class SharedController : Controller
    {
        private PortfolioModel db = new PortfolioModel();
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobHistoryPartial()
        {
            return View(db.JobHistories.ToList());
        }
    }
}