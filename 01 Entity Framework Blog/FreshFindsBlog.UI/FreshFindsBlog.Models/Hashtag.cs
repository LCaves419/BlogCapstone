using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFindsBlog.Models
{
    [Table("Hashtags")] // Table name
    public class Hashtag
    {
        [Key] // Primary key
        public int HashtagID { get; set; }

        public string HashtagName { get; set; }
    }
}
