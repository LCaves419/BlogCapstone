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

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var hashTag = new HashTag();

                        hashTag.HashTagID = dr.GetInt32(7);
                        hashTag.HashName = dr.GetString(8);

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
                            post.Status = dr.GetInt32(5);
                            post.Category.CategoryName = dr.GetString(6);
                            post.User.UserID = dr.GetString(9);
                            post.User.UserName = dr.GetString(10);

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

        public List<Category> GetAllCategories()
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Category>("GetAllCategories", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void CreateBlogPostDB(BlogPost blogPost)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Title", blogPost.Title);
                p.Add("@Mce", blogPost.Mce.Body);
                p.Add("@Category", blogPost.Category);

                p.Add("BlogPostID",DbType.Int32, direction: ParameterDirection.Output);
                cn.Execute("BlogPostInsert", p, commandType: CommandType.StoredProcedure);

                //var blogPostID = p.Get<int>("BlogPostID");

                foreach (var hashTag in blogPost.HashTags)
                {
                    var p2 = new DynamicParameters();
                    p2.Add("@HashTag", hashTag.HashName);
                    p2.Add("@HashTagID", hashTag.HashTagID);
                    cn.Execute("HashTagInsert", p2, commandType: CommandType.StoredProcedure);

                    var p3 = new DynamicParameters();
                    p3.Add("@HashTagID", hashTag.HashTagID);
                    cn.Execute("HashTagPostInsert", p3, commandType: CommandType.StoredProcedure);

                }

                    var p4 = new DynamicParameters();
                    p.Add("@BlogPostID", blogPost.BlogPostID );
                    cn.Execute("HashTagPostInsert", p4, commandType: CommandType.StoredProcedure);
               
            }
            

        }
    }
}



//  SqlCommand cmd = cn.CreateCommand();
//cmd.CommandText = "BlogPostInsert";
//                cmd.CommandType = CommandType.StoredProcedure;

//                cmd.CommandText = "HashTagInsert";
//                cmd.CommandType = CommandType.StoredProcedure;

//                cmd.CommandText = "HashTagPostInsert";
//                cmd.CommandType = CommandType.StoredProcedure;

//                cmd.Parameters.AddWithValue("@blogPost", blogPost);

//                cn.Open();