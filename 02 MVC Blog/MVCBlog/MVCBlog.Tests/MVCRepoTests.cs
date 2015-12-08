using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MVCBlog.BLL;
using MVCBlog.Data;
using MVCBlog.Data.Config;
using MVCBlog.Models;
using NUnit.Framework;

namespace MVCBlog.Tests
{
    [TestFixture]
    public class MVCRepoTests
    {
        [Test]
        public void CreateBlogPostDB()
        {
            var blogPost = new BlogPost()
            {
                BlogPostID = 0,
                Body = "",
                Categories = new List<Category>(),
                Category = new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Daily Picks"
                },
                HashTag = new HashTag()
                {
                    HashTagID = 1,
                    HashTagName = "#savings"
                },
                HashTags = new List<HashTag>(),
                Mce = new TinyMceClass()
                {
                    Body = "Unit Testing for CreateBlogPost"
                },
                PostDate = DateTime.Today,
                Status = 2,
                tags = new List<string>()
                {
                    "#goodfood",
                    "#bestdeals"
                }
            };

            var repo = new MVCBlogRepo();

            repo.CreateBlogPostDB(blogPost);

            var cn = new SqlConnection(Settings.ConnectionString);

            var expected = cn.Query<int>("SELECT COUNT(BlogPostID) FROM BlogPosts").FirstOrDefault();

            Assert.AreEqual(expected, 9);

        }

        [Test]
        public void GetAllBlogPosts_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(BlogPostID) FROM BlogPosts";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllBlogPosts().Count());
        }

        [Test]
        public void GetAllCategories_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(CategoryID) FROM Categories";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllCategories().Count());
        }

        [Test]
        public void GetAllHashTags_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(HashTagID) FROM HashTags";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllHashTags().Count());
        }

        [Test]
        public void GetAllApprovedBlogPosts_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(BlogPostID) FROM BlogPosts WHERE [Status] = 1";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllApprovedBlogPosts().Count());
        }

        [Test]
        public void GetAllUnapprovedBlogPosts_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(BlogPostID) FROM BlogPosts WHERE [Status] = 2";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllUnapprovedBlogPosts().Count());
        }

        [Test]
        public void GetAllArchivedBlogPosts_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(BlogPostID) FROM BlogPosts WHERE [Status] = 3";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllArchivedBlogPosts().Count());
        }

        [Test]
        public void CreateStaticPageDB()
        {
            
            var staticPage = new StaticPage()
            {
                Date = DateTime.Today,
                Mce = new TinyMceClass()
                {
                    Body = "Unit Test for CreateStaticPageDB method"
                },
                StaticPageID = 0,
                Status = 2,
                Title = "Testing",
                UserID = "2598e14d-88d0-46a7-ace9-f323ffe89181"
            };

            var repo = new MVCBlogRepo();
            repo.CreateStaticPageDB(staticPage);

            var cn = new SqlConnection(Settings.ConnectionString);

            var expected = cn.Query<int>("SELECT COUNT(StaticPageID) FROM StaticPages").FirstOrDefault();

            Assert.AreEqual(expected, 6);
        }

        [Test]
        public void GetAllApprovedStaticPages_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(StaticPageID) FROM StaticPages WHERE [Status] = 1";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllApprovedStaticPages().Count());
        }

        [Test]
        public void GetAllUnapprovedStaticPages_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(StaticPageID) FROM StaticPages WHERE [Status] = 2";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllUnapprovedStaticPages().Count());
        }

        [Test]
        public void GetAllArchivedStaticPages_CheckCount()
        {
            int expected;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(StaticPageID) FROM StaticPages WHERE [Status] = 3";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            var repo = new MVCBlogRepo();
            Assert.AreEqual(expected, repo.GetAllArchivedStaticPages().Count());
        }
    }
}
