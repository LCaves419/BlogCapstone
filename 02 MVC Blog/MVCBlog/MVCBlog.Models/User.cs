using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public UserLevel UserLevel { get; set; }
    }
}
