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
        public ActionResult Create([Bind(Include = "ID,Company,YearsExperience,Description")] JobHistory jobHistory, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                
                db.JobHistories.Add(jobHistory);

                db.SaveChanges();

                Dictionary<int, bool> test = new Dictionary<int, bool>();

                var cbSkillArray = FixCheckBoxValue(collection["cbSkill"].Split(new char[] {','}));                

                var hfSkillIdArray = collection["item.ID"].Split(new char[] {','});

                for (int i = 0; i < cbSkillArray.Length; i++)
                {
                    test.Add(Convert.ToInt32(hfSkillIdArray[i]), Convert.ToBoolean(cbSkillArray[i]));
                }

                foreach (var selectedItems in test)
                {
                    if (selectedItems.Value)
                    {
                        db.JobSkillXRs.Add(new JobSkillXR { Skill = db.Skills.Where(x => x.ID == selectedItems.Key).First(), Job = jobHistory });
                    }
                }
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }


            

            return View(jobHistory);
        }

        private string[] FixCheckBoxValue(string[] values)
        {
            var list = new List<string>(values);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "true")
                {
                    list.RemoveAt(i + 1);
                }
            }
            return list.ToArray();
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
        public ActionResult Edit([Bind(Include = "ID,Company,YearsExperience,Description")] JobHistory jobHistory, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobHistory).State = EntityState.Modified;
                db.SaveChanges();

                var jobSkillsToDelete = db.JobSkillXRs.Where(x => x.Job.ID == jobHistory.ID).ToList();
                if (jobSkillsToDelete != null)
                {
                    db.JobSkillXRs.RemoveRange(jobSkillsToDelete);

                    db.SaveChanges();
                }


                if (collection["skills"] != null)
                {
                    var selectedSkills = collection["skills"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in selectedSkills)
                    {
                        int skillId = Convert.ToInt32(item);
                        db.JobSkillXRs.Add(new JobSkillXR { Skill = db.Skills.Where(x => x.ID == skillId).First(), Job = jobHistory });
                    }

                    db.SaveChanges();
                }
                

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


            db.JobSkillXRs.RemoveRange(jobHistory.History_ID);
            
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
