using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFindsBlog.Models
{
    [Table("Users")] // Table name
    public class User
    {
        [Key] // Primary key
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserLevel { get; set; }
    }
}
