using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fancy_Magazine.Models;
using Fancy_Magazine.ViewModels;

namespace Fancy_Magazine.ViewModels
{
	public class ContactModel
	{
		public Partials Partials { get; set; }
		public List<Contact> Contact { get; set; }
	}
}