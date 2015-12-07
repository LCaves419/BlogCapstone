using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
    public class StaticPage
    {
        public string StaticPageID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TinyMceClass Mce { get; set; }
        public int Status { get; set; }
        public int UserID { get; set; }
    }
}
