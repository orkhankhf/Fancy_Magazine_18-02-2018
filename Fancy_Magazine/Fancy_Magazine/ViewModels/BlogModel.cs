using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fancy_Magazine.ViewModels;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.ViewModels
{
    public class BlogModel
    {
        public Partials Partials { get; set; }
        public Blog SingleBlog { get; set; }
        public List<Blog> RecentBlogs {get; set;}
        public List<Category> Category { get; set; }
    }
}