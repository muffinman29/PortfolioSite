using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StevenWilliams.Models;

namespace StevenWilliams.Controllers
{
    public class JobHistoriesController : Controller
    {
        private PortfolioModel db = new PortfolioModel();

        // GET: JobHistories
        public ActionResult Index()
        {
            return View(db.JobHistories.ToList());
        }

        // GET: JobHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);  

            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Company,YearsExperience,Description")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                
                db.JobHistories.Add(jobHistory);
                //db.SaveChanges();
                //foreach (var item in selectedSkills.SelectedValues)
                //{
                //    var skillID = Convert.ToInt32(item.ToString());

                //    var skill = db.Skills.Find(skillID);

                //    db.JobSkillXRs.Add(new JobSkillXR { Skill = skill, Job = jobHistory});



                //}

                db.SaveChanges();
                
                
                return RedirectToAction("Index");
            }


            

            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Company,YearsExperience,Description")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobHistory);
        }

        // GET: JobHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = db.JobHistories.Find(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobHistory jobHistory = db.JobHistories.Find(id);
            db.JobHistories.Remove(jobHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
