using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fancy_Magazine.Models
{
	public class AdminPanelMethods
	{
		public static bool CheckAdminLogin()
		{
			if(HttpContext.Current.Session["admin"] != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}