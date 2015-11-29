using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCBlog.Models;

namespace MVCBlog.UI.Models
{
    public class BlogPostVM
    {
        public BlogPostVM()
        {
            Category = new Category();
            Categories = new List<Category>();
            HashTag = new HashTag();
            HashTags = new List<HashTag>();
            User = new User();
            BlogPosts = new List<BlogPost>();
        }
        public int BlogPostID { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public DateTime PostDate { get; set; }

        public HashTag HashTag { get; set; }
        public int Approved { get; set; }
        public User User { get; set; }//has userlevel in it
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<HashTag> HashTags { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
       
    }
}