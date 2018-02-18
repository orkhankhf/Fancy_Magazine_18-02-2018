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
    public class Testimonials_SliderController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Testimonials_Slider
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Testimonials_Slider.ToList());
        }

        // GET: Testimonials_Slider/Details/5
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
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // GET: Testimonials_Slider/Create
        public ActionResult Create()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
        }

        // POST: Testimonials_Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testimonials_slider_id,testimonials_slider_icon,testimonials_slider_content,testimonials_slider_author,testimonials_slider_position")] Testimonials_Slider testimonials_Slider, HttpPostedFileBase testimonials_slider_img)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                Random rand = new Random();
                string photo_name = rand.Next(11111, 99999).ToString() + Path.GetExtension(testimonials_slider_img.FileName);
                string photo_path = Path.Combine(Server.MapPath("/Uploads"), photo_name);
                testimonials_slider_img.SaveAs(photo_path);

                testimonials_Slider.testimonials_slider_img = photo_name;
                db.Testimonials_Slider.Add(testimonials_Slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Content("File not chosen!");
        }

        // GET: Testimonials_Slider/Edit/5
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
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // POST: Testimonials_Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testimonials_slider_id,testimonials_slider_icon,testimonials_slider_content,testimonials_slider_author,testimonials_slider_position,testimonials_slider_img")] Testimonials_Slider testimonials_Slider)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(testimonials_Slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonials_Slider);
        }

        // GET: Testimonials_Slider/Delete/5
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
            Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            if (testimonials_Slider == null)
            {
                return HttpNotFound();
            }
            return View(testimonials_Slider);
        }

        // POST: Testimonials_Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Testimonials_Slider testimonials_Slider = db.Testimonials_Slider.Find(id);
            db.Testimonials_Slider.Remove(testimonials_Slider);
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
