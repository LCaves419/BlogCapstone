using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
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

        [TestCase(true, 2, true)]
        [TestCase(true, 95, false)]
        public void GetBlogPostByID_Response_ReturnResponse(bool input, int n, bool expectedResult)
        {
            var ops = new MVCBlogOps();

            var result = ops.GetBlogPostByIDFromRepo(n);

            Assert.AreEqual(expectedResult, result.Success);
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
    }
}
