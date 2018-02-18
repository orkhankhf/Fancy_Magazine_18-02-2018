using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fancy_Magazine.ViewModels;
using Fancy_Magazine.Models;

namespace Fancy_Magazine.ViewModels
{
	public class HomeModel
	{
		public Partials Partials { get; set; }
        public List<Slider> Slider { get; set; }
        public List<Feature_Boxes> FeaturesBoxes { get; set; }
        public List<Blog> Blog { get; set; }
        public List<Industry> Industry { get; set; }
        public List<Service_Area> Service_Area { get; set; }
        public List<Service_Area_Contents> Service_Area_Contents { get; set; }
        public List<Testimonials_Slider> Testimonials_Slider { get; set; }
        public List<Project_Area> Project_Area { get; set; }
        public List<Blog> LatestBlogs { get; set; }
    }
}