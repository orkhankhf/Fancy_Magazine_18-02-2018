using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.Controllers.Adminpanel
{
    public class Project_AreaController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Project_Area
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Project_Area.ToList());
        }

        // GET: Project_Area/Details/5
        public ActionResult Details(int? id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Area project_Area = db.Project_Area.Find(id);
            if (project_Area == null)
            {
                return HttpNotFound();
            }
            return View(project_Area);
        }

        // GET: Project_Area/Create
        public ActionResult Create()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        // POST: Project_Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "project_area_id,project_area_title,project_area_content,project_area_url")] Project_Area project_Area)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Project_Area.Add(project_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project_Area);
        }

        // GET: Project_Area/Edit/5
        public ActionResult Edit(int? id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Area project_Area = db.Project_Area.Find(id);
            if (project_Area == null)
            {
                return HttpNotFound();
            }
            return View(project_Area);
        }

        // POST: Project_Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "project_area_id,project_area_title,project_area_content,project_area_url")] Project_Area project_Area)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(project_Area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project_Area);
        }

        // GET: Project_Area/Delete/5
        public ActionResult Delete(int? id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Area project_Area = db.Project_Area.Find(id);
            if (project_Area == null)
            {
                return HttpNotFound();
            }
            return View(project_Area);
        }

        // POST: Project_Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Project_Area project_Area = db.Project_Area.Find(id);
            db.Project_Area.Remove(project_Area);
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
