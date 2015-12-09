using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MVCBlog.Models
{
    public class HashTag
    {
        public int HashTagID { get; set; }

        [Required(ErrorMessage = "Please Add Some Hash Tags.")]
        public string HashTagName { get; set; }

    }
}
