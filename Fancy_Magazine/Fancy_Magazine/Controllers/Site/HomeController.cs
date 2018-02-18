using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fancy_Magazine.ViewModels;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.Controllers.Site
{
    public class HomeController : BaseController
	{
		FancyMagazineEntities db = new FancyMagazineEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(new HomeModel {Partials = partialsVM, Slider = db.Sliders.ToList(), FeaturesBoxes = db.Feature_Boxes.ToList(), Blog = db.Blogs.OrderByDescending(b => b.blog_id).Take(1).ToList(), Industry = db.Industries.OrderByDescending(i => i.industries_id).Take(1).ToList(), Service_Area = db.Service_Area.OrderByDescending(s => s.service_id).Take(1).ToList(), Service_Area_Contents = db.Service_Area_Contents.ToList(), Testimonials_Slider = db.Testimonials_Slider.ToList(), Project_Area = db.Project_Area.OrderByDescending(p=>p.project_area_id).Take(1).ToList(), LatestBlogs = db.Blogs.OrderByDescending(n=>n.blog_id).Take(3).ToList()});
        }
        public ActionResult Blog(int? id)
        {
            return View(new BlogModel { Partials = partialsVM, SingleBlog = db.Blogs.Find(id), RecentBlogs = db.Blogs.OrderByDescending(b=>b.blog_id).Take(4).ToList(), Category = db.Categories.ToList()});
        }
		public ActionResult Contact()
		{
			return View(new ContactModel { Partials = partialsVM, Contact = db.Contacts.ToList()});
		}
		[HttpPost]
		public ActionResult Contact([Bind(Include = "message_name,message_email,message_website_url,message_content")] Message msg)
		{
			if (ModelState.IsValid)
			{
				db.Messages.Add(msg);
				db.SaveChanges();
				return RedirectToAction("Contact");
			}
			return View();
		}
	}
}