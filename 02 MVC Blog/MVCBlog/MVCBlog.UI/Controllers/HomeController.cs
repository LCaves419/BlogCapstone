using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.BLL;
using MVCBlog.Models;
using MVCBlog.UI.Models;

namespace MVCBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private Response _res;
        private MVCBlogOps _ops; 

        public ActionResult Index()
        {
            _res = new Response();
            _ops = new MVCBlogOps();
            
            _res = _ops.GetAllBlogPostFromRepo();
            
            return View(_res);
        }

        //Displays TinyMCE Editor
        public ActionResult CreatePostGet()
        {
            _ops = new MVCBlogOps();
            BlogPostVM blogPostVM = new BlogPostVM();
            _res = new Response();

            _res = _ops.GetAllCategoriesFromRepo();
            blogPostVM.CreateCategoriesList(_res.Categories);

            return View(blogPostVM);
        }

        [HttpPost]
        public ActionResult CreatePostPost(BlogPost blogPost)
        {
            _res = new Response();
            blogPost.PostDate = DateTime.Today;
            // blogPost.Status = 1;
            _res = _ops.SaveBlogPostToRepo(blogPost);
            return View(_res);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}