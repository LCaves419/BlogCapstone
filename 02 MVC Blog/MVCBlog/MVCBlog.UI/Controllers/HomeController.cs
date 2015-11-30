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
            //List<BlogPost> blogPosts  = new List<BlogPost>();
            
            _res = _ops.GetAllBlogPostFromRepo();
            //blogPosts = _res.BlogPosts;
            
            return View(_res);
        }

        //Displays TinyMCE Editor
        public ActionResult CreatePostGet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePostPost(TinyMceClass model)
        {
            return View(model);
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