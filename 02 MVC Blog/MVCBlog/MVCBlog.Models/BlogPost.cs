﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            Category = new Category();
            HashTags = new List<HashTag>();
            User = new User();
            Mce = new TinyMceClass();
        }
        public int BlogPostID { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public DateTime PostDate { get; set; }

        public HashTag HashTag { get; set; }
        public int Approved { get; set; }
        public User User { get; set; }//has userlevel in it
        public Category Category { get; set; }
        public List<HashTag> HashTags { get; set; }

        public TinyMceClass Mce { get; set; }



    }
}
