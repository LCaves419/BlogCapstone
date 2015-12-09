using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;


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

        [Required(ErrorMessage = "Please Enter a Title")]
        public string Title { get; set; }

        public string Body { get; set; }
        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "Please Enter a HashTag")]
        public HashTag HashTag { get; set; }

        public int Status { get; set; }
        public User User { get; set; }//has userlevel in it

        public Category Category { get; set; }
        public List<Category> Categories { get; set; } 
        public List<HashTag> HashTags { get; set; }
        public List<string> tags { get; set; }

        [Required(ErrorMessage = "Please Enter a Body")]
        public TinyMceClass Mce { get; set; }



    }
}
