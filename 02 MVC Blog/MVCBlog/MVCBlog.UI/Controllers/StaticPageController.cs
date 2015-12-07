using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.BLL;
using MVCBlog.Models;

namespace MVCBlog.UI.Controllers
{
    public class StaticPageController : Controller
    {
        private Response _res;
        private MVCBlogOps _ops;


        // GET: StaticPage
        public ActionResult Index()
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.GetAllApprovedStaticPagesFromRepo();
            var pages = _res.StaticPages;
            return View(pages);
        }


    }
}