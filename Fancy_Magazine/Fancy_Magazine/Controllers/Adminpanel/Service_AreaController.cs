using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.Controllers.Adminpanel
{
    public class Service_AreaController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Service_Area
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Service_Area.ToList());
        }

        // GET: Service_Area/Details/5
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
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // GET: Service_Area/Create
        public ActionResult Create()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        // POST: Service_Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "service_id,service_title,service_content,service_content_url")] Service_Area service_Area, HttpPostedFileBase service_img)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                Random rand = new Random();
                string photo_name = rand.Next(11111, 99999).ToString() + Path.GetExtension(service_img.FileName);
                string photo_path = Path.Combine(Server.MapPath("/Uploads"), photo_name);
                service_img.SaveAs(photo_path);

                service_Area.service_img = photo_name;
                db.Service_Area.Add(service_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Content("File not chosen!");
        }

        // GET: Service_Area/Edit/5
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
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // POST: Service_Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "service_id,service_img,service_title,service_content,service_content_url")] Service_Area service_Area)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(service_Area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_Area);
        }

        // GET: Service_Area/Delete/5
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
            Service_Area service_Area = db.Service_Area.Find(id);
            if (service_Area == null)
            {
                return HttpNotFound();
            }
            return View(service_Area);
        }

        // POST: Service_Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Service_Area service_Area = db.Service_Area.Find(id);
            db.Service_Area.Remove(service_Area);
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
