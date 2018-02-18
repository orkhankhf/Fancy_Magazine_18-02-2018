using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.ViewModels
{
	public class Partials
	{
		public List<Contact> Contact { get; set; }
		public List<Category> Category { get; set; }
		public List<Menu> Menus { get; set; }
	}
}