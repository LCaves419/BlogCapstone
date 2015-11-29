using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.BLL;
using MVCBlog.Models;

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