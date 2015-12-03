﻿using System;
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
        public ActionResult CreatePostPost(BlogPostVM blogPostVM)
        {
            //blogPostVM.blogPost.PostDate = DateTime.Today;
            // blogPost.Status = 1;
            _ops = new MVCBlogOps();

            var blogPost = new BlogPost();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            blogPost.User.UserID = user.Id;


            blogPost.Title = blogPostVM.blogPost.Title;
            foreach (var item in blogPostVM.tags)
            {
                HashTag hashTag =  new HashTag();
                hashTag.HashName = item;
                blogPost.HashTags.Add(hashTag);
            }

            blogPost.Mce.Body = blogPostVM.blogPost.Mce.Body;
            blogPost.Category.CategoryID = blogPostVM.category.CategoryID;
          
            _ops.SaveBlogPostToRepo(blogPost);

            return RedirectToAction("Index");
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