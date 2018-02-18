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
    public class MessagesController : Controller
    {
        private FancyMagazineEntities db = new FancyMagazineEntities();

        // GET: Messages
        public ActionResult Index()
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			return View(db.Messages.ToList());
        }

        // GET: Messages/Details/5
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
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "message_id,message_name,message_email,message_website_url,message_content")] Message message)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
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
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "message_id,message_name,message_email,message_website_url,message_content")] Message message)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
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
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!AdminPanelMethods.CheckAdminLogin())
			{
				return RedirectToAction("Index", "Login");
			}
			Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
