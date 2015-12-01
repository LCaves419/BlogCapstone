using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCBlog.Models
{
    //Class to store TinyMce values
    public class TinyMceClass
    {
        //Attribute allows HTML Content to be sent up.
        [AllowHtml]
        public string Body { get; set; }






        //public TinyMceClass()
        //{

        //}

    }
}
