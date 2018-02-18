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
    public class IndustriesController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Industries
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Industries.ToList());
        }

        // GET: Industries/Details/5
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
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // GET: Industries/Create
        public ActionResult Create()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "industries_id,industries_title,industries_content,industries_url")] Industry industry, HttpPostedFileBase industries_img)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                Random rand = new Random();
                string photo_name = rand.Next(11111, 99999).ToString() + Path.GetExtension(industries_img.FileName);
                string photo_path = Path.Combine(Server.MapPath("/Uploads"), photo_name);
                industries_img.SaveAs(photo_path);

                industry.industries_img = photo_name;
                db.Industries.Add(industry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("File not chosen!");
        }

        // GET: Industries/Edit/5
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
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "industries_id,industries_title,industries_content,industries_img,industries_url")] Industry industry)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(industry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(industry);
        }

        // GET: Industries/Delete/5
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
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Industry industry = db.Industries.Find(id);
            db.Industries.Remove(industry);
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
