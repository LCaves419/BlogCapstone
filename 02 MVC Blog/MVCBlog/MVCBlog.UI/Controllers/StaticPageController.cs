using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCBlog.BLL;
using MVCBlog.Models;
using MVCBlog.UI.Models;

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

        public ActionResult CreateStaticPageGet()
        {
            _res = new Response();

            return View(_res);
        }

        [HttpPost]
        public ActionResult CreateStaticPagePost(Response response)
        {
            _ops = new MVCBlogOps();

            var staticPage = new StaticPage();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            if (User.IsInRole("Admin"))
            {
                // TODO: simplify this, inspect blogPost.Status
                staticPage.Status = 1; // 1 is Approved
            }
            else
            {
                staticPage.Status = 2; // 2 is Unapproved
            }

            staticPage.UserID = user.Id;
            staticPage.Title = response.StaticPage.Title;
            staticPage.Mce.Body = response.StaticPage.Mce.Body;

            _ops.SaveStaticPageToRepo(staticPage);

            return RedirectToAction("Index", "StaticPage");
        }

        public ActionResult EditStaticPageGet(int id)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.GetStaticPageByIDFromRepo(id);

            _ops.ArchiveStaticPageToRepo(_res.StaticPage);

            return View(_res);
        }


        [HttpPost]
        public ActionResult EditStaticPagePost(Response response)
        {
            _ops = new MVCBlogOps();

            var staticPage = new StaticPage();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            if (User.IsInRole("Admin"))
            {
                // TODO: simplify this, inspect blogPost.Status
                staticPage.Status = 1; // 1 is Approved
            }
            else
            {
                staticPage.Status = 2; // 2 is Unapproved
            }

            staticPage.UserID = user.Id;
            staticPage.Title = response.StaticPage.Title;
            staticPage.Mce.Body = response.StaticPage.Mce.Body;

            _ops.SaveStaticPageToRepo(staticPage);

            return RedirectToAction("Index", "StaticPage");
        }




        [Authorize(Roles = "Admin")]
        public ActionResult ApproveStaticPagesGet()
        {
            _ops = new MVCBlogOps();
            _res = new Response();
            _res = _ops.GetAllUnapprovedStaticPagesFromRepo();

            return View(_res);
        }

        public ActionResult ViewStaticPageGet(int id)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.GetStaticPageByIDFromRepo(id);

            return View(_res);
        }

        [HttpPost]
        public ActionResult ApproveStaticPage(StaticPage staticPage)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.ApproveStaticPageToRepo(staticPage);
            return RedirectToAction("Index", "StaticPage");
        }

        [HttpPost]
        public ActionResult UnapproveStaticPage(StaticPage staticPage)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.UnapproveStaticPageToRepo(staticPage);
            return RedirectToAction("Index", "StaticPage");
        }

        [HttpPost]
        public ActionResult ArchiveStaticPage(StaticPage staticPage)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.ArchiveStaticPageToRepo(staticPage);
            return RedirectToAction("Index", "StaticPage");
        }
    }
}