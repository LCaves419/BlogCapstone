using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFindsBlog.Models
{
    [Table("Categories")] // Table name
    public class Category
    {
        [Key] // Primary key
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
