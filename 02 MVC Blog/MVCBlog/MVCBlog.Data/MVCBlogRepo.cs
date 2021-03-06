﻿using System;
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

        //public List<BlogPost> GetAllBlogPostsByCategory()
        //{
        //    var orderedList = GetAllBlogPosts().OrderBy(b => b.Category.CategoryID);
        //    return orderedList;
        //} 

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

        public List<BlogPost> GetAllBlogPostsByCategory(int id)
        {
            var posts = GetAllBlogPosts().Where(i => i.Category.CategoryID == id).ToList();

            return posts;

        }

        public List<HashTag> GetAllHashTags()
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<HashTag>("GetAllHashTags", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<BlogPost> GetAllBlogPostsByHashTag(int id)
        {
            var oldPosts = GetAllBlogPosts();
            var newPosts = new List<BlogPost>();

            foreach (var post in oldPosts)
            {
                foreach (var hashTag in post.HashTags)
                {
                    if (hashTag.HashTagID == id)
                    {
                        newPosts.Add(post);
                    }
                }

            }

            return newPosts;
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
        //-------------------------------------------------------------------------------------------------------

        public List<StaticPage> GetAllStaticPages()
        {
            List<StaticPage> pages = new List<StaticPage>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "GetAllStaticPages";
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                            StaticPage page = new StaticPage();
                            page.StaticPageID= dr.GetInt32(0);
                            page.Date = dr.GetDateTime(1);
                            page.Title = dr.GetString(2);
                            page.Mce.Body = dr.GetString(3);
                            page.Status = dr.GetInt32(4);
                            page.UserID = dr.GetString(5);
                            
                            pages.Add(page);
                    }
                }
            }
            return pages;
        }

        public void CreateStaticPageDB(StaticPage staticPage)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserID", staticPage.UserID);
                p.Add("@Title", staticPage.Title);
                p.Add("@Body", staticPage.Mce.Body);
                p.Add("@Date", DateTime.Today);
                p.Add("@Status", staticPage.Status);

                p.Add("@StaticPageID", DbType.Int32, direction: ParameterDirection.Output);
                cn.Execute("StaticPageInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public StaticPage GetStaticPageByID(int id)
        {
            return GetAllStaticPages().Where(i => i.StaticPageID == id).FirstOrDefault();
        }

        public void ApproveStaticPageDB(StaticPage staticPage)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@StaticPageID", staticPage.StaticPageID);

                cn.Execute("ApproveStaticPageByID", p, commandType: CommandType.StoredProcedure);
            }
        }


        public void UnapproveStaticPageDB(StaticPage staticPage)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@StaticPageID", staticPage.StaticPageID);

                cn.Execute("UnapproveStaticPageByID", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void ArchiveStaticPageDB(StaticPage staticPage)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@StaticPageID", staticPage.StaticPageID);

                cn.Execute("ArchiveStaticPageByID", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<StaticPage> GetAllApprovedStaticPages()
        {
            var pages = GetAllStaticPages().Where(i => i.Status == 1).ToList();
            return pages;
        }

        public List<StaticPage> GetAllUnapprovedStaticPages()
        {
            var pages = GetAllStaticPages().Where(i => i.Status == 2).ToList();
            return pages;
        }

        public List<StaticPage> GetAllArchivedStaticPages()
        {
            var pages = GetAllStaticPages().Where(i => i.Status == 3).ToList();
            return pages;
        }
    }
}



