using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class BlogComment
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Blog> Last3Blog { get; set; }
        public IEnumerable<Comment> Last3Comment { get; set; }
    }
}