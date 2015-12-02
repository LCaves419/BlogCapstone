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
        public List<BlogPost> GetAllBlogPosts()
        {
            List<BlogPost> posts = new List<BlogPost>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "GetAllBlogPostsOrderByCategory";
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                //BlogPost post = new BlogPost();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var hashTag = new HashTag();

                        hashTag.HashTagID = dr.GetInt32(6);
                        hashTag.HashName = dr.GetString(7);

                        var testPostID = dr.GetInt32(0);

                        var item = posts.Where(p => p.BlogPostID == testPostID).FirstOrDefault();

                        if (item == null)
                        {
                            BlogPost post = new BlogPost();
                            post.BlogPostID = testPostID;
                            post.Title = dr.GetString(1);
                            post.Body = dr.GetString(2);
                            post.PostDate = dr.GetDateTime(3);
                            post.Category.CategoryID = dr.GetInt32(4);
                            post.Category.CategoryName = dr.GetString(5);
                            post.User.UserID = dr.GetString(8);
                            post.User.UserName = dr.GetString(9);

                            post.HashTags.Add(hashTag);

                            posts.Add(post);
                        }
                        else
                        {
                            item.HashTags.Add(hashTag);
                        }


                    }
                }
            }
            return posts;
        }

        public void CreateBlogPostDB(BlogPost blogPost)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var pnsm = new DynamicParameters();
                pnsm.Add("@Body", blogPost);








            }
        } 

    }
}
