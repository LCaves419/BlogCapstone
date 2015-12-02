using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
   public class Response
    {
        public Response()
        {
            Category = new Category();
            Categories = new List<Category>();
            HashTag = new HashTag();
            HashTags = new List<HashTag>();
            User = new User();
            BlogPost = new BlogPost();
            BlogPosts = new List<BlogPost>();
            Mce = new TinyMceClass();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public BlogPost BlogPost { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public HashTag HashTag { get; set; }
        public List<HashTag> HashTags { get; set; } 
        public User User { get; set; }
        public UserLevel UserLevel { get; set; }
        public TinyMceClass Mce { get; set; }

    }
}
