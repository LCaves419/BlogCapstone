using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.Data.Config;
using MVCBlog.Models;
using Dapper;

namespace MVCBlog.Data
{
    public class MVCBlogRepo
    {
        private SqlConnection _cn;

        public MVCBlogRepo()
        {
            _cn = new SqlConnection(Settings.ConnectionString);
        }


        public List<BlogPost> GetAllBlogPosts()
        {
            return _cn.Query<BlogPost>("GetAllBlogPosts", CommandType.StoredProcedure).ToList();
        } 

    }
}
