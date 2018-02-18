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
    public class Service_Area_ContentsController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Service_Area_Contents
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Service_Area_Contents.ToList());
        }

        // GET: Service_Area_Contents/Details/5
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
            Service_Area_Contents service_Area_Contents = db.Service_Area_Contents.Find(id);
            if (service_Area_Contents == null)
            {
                return HttpNotFound();
            }
            return View(service_Area_Contents);
        }

        // GET: Service_Area_Contents/Create
        public ActionResult Create()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        // POST: Service_Area_Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "service_contents_id,service_contents_title,service_contents_content,service_contents_icon")] Service_Area_Contents service_Area_Contents)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Service_Area_Contents.Add(service_Area_Contents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_Area_Contents);
        }

        // GET: Service_Area_Contents/Edit/5
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
            Service_Area_Contents service_Area_Contents = db.Service_Area_Contents.Find(id);
            if (service_Area_Contents == null)
            {
                return HttpNotFound();
            }
            return View(service_Area_Contents);
        }

        // POST: Service_Area_Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "service_contents_id,service_contents_title,service_contents_content,service_contents_icon")] Service_Area_Contents service_Area_Contents)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(service_Area_Contents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_Area_Contents);
        }

        // GET: Service_Area_Contents/Delete/5
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
            Service_Area_Contents service_Area_Contents = db.Service_Area_Contents.Find(id);
            if (service_Area_Contents == null)
            {
                return HttpNotFound();
            }
            return View(service_Area_Contents);
        }

        // POST: Service_Area_Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Service_Area_Contents service_Area_Contents = db.Service_Area_Contents.Find(id);
            db.Service_Area_Contents.Remove(service_Area_Contents);
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
