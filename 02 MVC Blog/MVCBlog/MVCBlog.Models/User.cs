﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Models
{
    public class User
    {
        public User()
        {
            UserLevel = new UserLevel();
        }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public UserLevel UserLevel { get; set; }
    }
}
