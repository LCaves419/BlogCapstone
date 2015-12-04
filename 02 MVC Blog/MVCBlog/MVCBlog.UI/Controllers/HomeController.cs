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
    public class HomeController : Controller
    {
        private Response _res;
        private MVCBlogOps _ops;

        public ActionResult Index()
        {
            _res = new Response();
            _ops = new MVCBlogOps();
            _res = _ops.GetAllApprovedBlogPostsFromRepo();


            //if (User.IsInRole("Admin"))
            //{
            //    _res = _ops.GetAllBlogPostsFromRepo();
            //}
            //else
            //{
            //    _res = _ops.GetAllApprovedBlogPostsFromRepo();
            //}




            return View(_res);
        }

        //Displays TinyMCE Editor
        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles ="Public Relations")]
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
        public ActionResult CreatePostPost(BlogPostVM blogPostVM)
        {
            _ops = new MVCBlogOps();

            var blogPost = new BlogPost();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            if (User.IsInRole("Admin"))
            {
                // TODO: simplify this, inspect blogPost.Status
                blogPostVM.blogPost.Status = 1; // 1 is Approved
                blogPost.Status = blogPostVM.blogPost.Status;
            }
            else
            {
                blogPostVM.blogPost.Status = 2; // 2 is Unapproved
                blogPost.Status = blogPostVM.blogPost.Status;
            }

            blogPost.User.UserID = user.Id;
            blogPost.Title = blogPostVM.blogPost.Title;
            blogPost.Mce.Body = blogPostVM.blogPost.Mce.Body;
            blogPost.Category.CategoryID = blogPostVM.category.CategoryID;

            foreach (var item in blogPostVM.tags)
            {
                HashTag hashTag = new HashTag();
                hashTag.HashTagName = item;
                blogPost.HashTags.Add(hashTag);
            }
            _ops.SaveBlogPostToRepo(blogPost);

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult ApprovePostsGet()
        {
            _ops = new MVCBlogOps();
            _res = new Response();
            _res = _ops.GetAllUnapprovedBlogPostsFromRepo();

            return View(_res);
        }

        public ActionResult ViewPostGet(int id)
        {
            _res = new Response();
            _ops = new MVCBlogOps();

            _res = _ops.GetBlogPostByIDFromRepo(id);

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