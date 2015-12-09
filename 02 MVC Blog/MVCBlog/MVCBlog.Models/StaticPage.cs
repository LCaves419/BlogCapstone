using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MVCBlog.Models
{
    public class StaticPage
    {
        public StaticPage()
        {
            Mce = new TinyMceClass();
        }
        public int StaticPageID { get; set; }
        [Required(ErrorMessage = "Please Enter A Title.") ]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TinyMceClass Mce { get; set; }
        public int Status { get; set; }
        public string UserID { get; set; }
    }
}
