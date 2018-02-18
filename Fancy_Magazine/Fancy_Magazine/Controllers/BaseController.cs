using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fancy_Magazine.Models;
using Fancy_Magazine.ViewModels;

namespace Fancy_Magazine.Controllers
{
    public class BaseController : Controller
    {
		FancyMagazineEntities db = new FancyMagazineEntities();
		public Partials partialsVM;
		public BaseController()
		{
			partialsVM = new Partials() { Category = db.Categories.ToList(), Contact = db.Contacts.ToList(), Menus = db.Menus.ToList() };
		}
	}
}