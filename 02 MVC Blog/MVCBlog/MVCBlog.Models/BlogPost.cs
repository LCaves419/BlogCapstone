using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public HashTag HashTag { get; set; }
        public int Approved { get; set; }
        public User User { get; set; }//has userlevel in it
        public Category Category { get; set; }
        

    }
}
