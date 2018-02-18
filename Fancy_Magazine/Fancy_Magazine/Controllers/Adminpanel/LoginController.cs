using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fancy_Magazine.Controllers.Adminpanel
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
			Session.Remove("admin");
            return View();
        }
		[HttpPost]
		public ActionResult Index(FormCollection form)
		{
			if (form["email"] == "samir@code.edu.az" && form["password"] == "123456")
			{
				Session["admin"] = "samir@code.edu.az";
				return RedirectToAction("Index", "Categories");
			}
			return View();
		}
	}
}