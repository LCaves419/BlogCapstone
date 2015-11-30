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
        //private SqlConnection _cn;

        //public MVCBlogRepo()
        //{
        //    _cn = new SqlConnection(Settings.ConnectionString);
        //}


        public List<BlogPost> GetAllBlogPosts()
        {
            List<BlogPost> posts = new List<BlogPost>();

            using (var _cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = _cn.CreateCommand();
                cmd.CommandText = "GetAllBlogPostsOrderByCategory";
                cmd.CommandType = CommandType.StoredProcedure;

                _cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    BlogPost post = null;
                    while (dr.Read())
                    {
                        post = new BlogPost();
                        post.BlogPostID = dr.GetInt32(0);
                        post.Title = dr.GetString(1);
                        post.Body = dr.GetString(2);
                        post.PostDate = dr.GetDateTime(3);
                        post.User.UserID = dr.GetInt32(4);
                        post.User.UserLevel.UserLevelID = dr.GetInt32(5);
                        post.User.UserName = dr.GetString(6);
                        post.Category.CategoryID = dr.GetInt32(7);
                        post.Category.CategoryName = dr.GetString(8);
                        //post.HashTag.HashTagID = dr.GetInt32(9);
                        //post.HashTag.HashName = dr.GetString(10);

                        posts.Add(post);

                    }
                }


            }
            return posts;
        }

    }
}
