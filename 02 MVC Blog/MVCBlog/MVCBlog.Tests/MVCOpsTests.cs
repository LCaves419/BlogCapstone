using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.BLL;
using NUnit.Framework;

namespace MVCBlog.Tests
{
    [TestFixture]
    public class MVCOpsTests
    {
        [TestCase(true, 2, true)]
        [TestCase(true, 95, false)]
        public void GetBlogPostByID_Response_ReturnResponse(bool condition, int id, bool expectedResult)
        {
            var ops = new MVCBlogOps();

            var result = ops.GetBlogPostByIDFromRepo(id);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [TestCase(true, 1, true)]
        [TestCase(true, 142, false)]
        public void GetStaticPageByID_Response_ReturnResponse(bool condition, int id, bool expectedResult)
        {
            var ops = new MVCBlogOps();

            var result = ops.GetStaticPageByIDFromRepo(id);

            Assert.AreEqual(expectedResult, result.Success);
        }
    }
}
