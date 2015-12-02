using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.Data;
using MVCBlog.Data.Config;
using NUnit.Framework;

namespace MVCBlog.Tests
{
    [TestFixture]
    public class MVCRepoTests
    {
        [Test]
        public void GetAllBlogPosts_CheckCount()
        {
            int expected = 0;
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
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
    }
}
