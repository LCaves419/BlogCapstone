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
        private List<HashTag> _hashTags;

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
                        hashTag.HashTagName = dr.GetString(8);

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

        public BlogPost GetBlogPostByID(int blogPostID)
        {
            return GetAllBlogPosts().Where(id => id.BlogPostID == blogPostID).FirstOrDefault();
        }

        public List<BlogPost> GetAllApprovedBlogPosts()
        {
            var posts = GetAllBlogPosts().Where(i => i.Status == 1).ToList();
            return posts;

        }

        public List<BlogPost> GetAllUnapprovedBlogPosts()
        {
            return GetAllBlogPosts().Where(i => i.Status == 2).ToList();
        }

        public List<BlogPost> GetAllArchivedBlogPosts()
        {
            return GetAllBlogPosts().Where(i => i.Status == 3).ToList();
        }

        public List<Category> GetAllCategories()
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Category>("GetAllCategories", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<HashTag> GetAllHashTags()
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<HashTag>("GetAllHashTags", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void ApproveBlogPostDB(BlogPost blogPost)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@BlogPostID", blogPost.BlogPostID);

                cn.Execute("ApproveBlogPostByID", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UnapproveBlogPostDB(BlogPost blogPost)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@BlogPostID", blogPost.BlogPostID);

                cn.Execute("UnapproveBlogPostByID", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void ArchiveBlogPostDB(BlogPost blogPost)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@BlogPostID", blogPost.BlogPostID);

                cn.Execute("ArchiveBlogPostByID", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateBlogPostDB(BlogPost blogPost)
        {

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserID", blogPost.User.UserID);
                p.Add("@Title", blogPost.Title);
                p.Add("@Body", blogPost.Mce.Body);
                p.Add("@CategoryID", blogPost.Category.CategoryID);
                p.Add("@PostDate", DateTime.Today);
                p.Add("@Status", blogPost.Status);

                p.Add("@BlogPostID", DbType.Int32, direction: ParameterDirection.Output);
                cn.Execute("BlogPostInsert", p, commandType: CommandType.StoredProcedure);

                var blogPostID = p.Get<int>("BlogPostID");

                _hashTags = GetAllHashTags();

                foreach (var hashTag in blogPost.HashTags) //new user hashtags
                {

                    var ht = _hashTags.FirstOrDefault(h => h.HashTagName == hashTag.HashTagName);
                    var hashTagID = 0;
                    if (ht == null)
                    {
                        var p2 = new DynamicParameters();
                        p2.Add("@HashTagName", hashTag.HashTagName);
                        p2.Add("@HashTagID", DbType.Int32, direction: ParameterDirection.Output);
                        cn.Execute("HashTagInsert", p2, commandType: CommandType.StoredProcedure);
                        hashTagID = p2.Get<int>("HashTagID");
                        _hashTags.Add(new HashTag() { HashTagID = hashTagID, HashTagName = hashTag.HashTagName });
                    }
                    else
                    {
                        hashTagID = ht.HashTagID;
                    }
                    var p4 = new DynamicParameters();

                    p4.Add("@HashTagID", hashTagID);
                    p4.Add("@BlogPostID", blogPostID);
                    cn.Execute("HashTagPostInsert", p4, commandType: CommandType.StoredProcedure);
                }

            }
        }
    }
}



