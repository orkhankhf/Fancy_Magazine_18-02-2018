//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fancy_Magazine.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int blog_id { get; set; }
        public string blog_title { get; set; }
        public string blog_content { get; set; }
        public string blog_img { get; set; }
        public Nullable<int> blog_category_id { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
