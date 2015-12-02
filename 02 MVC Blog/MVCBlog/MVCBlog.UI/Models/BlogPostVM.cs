using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.BLL;
using MVCBlog.Models;

namespace MVCBlog.UI.Models
{
    public class BlogPostVM
    {
        public BlogPost blogPost { get; set; }
        public Category category { get; set; }
        public List<SelectListItem> categories { get; set; }

        public void CreateCategoriesList(List<Category> categoriesList)
        {
            List<Category> listOfCategories = new List<Category>();

            listOfCategories = categoriesList;

            categories = new List<SelectListItem>();

            foreach (Category category in listOfCategories)
            {
                var newItem = new SelectListItem();

                newItem.Text = category.CategoryName;
                newItem.Value = category.CategoryID.ToString();

                categories.Add(newItem);
            }
        }
       
    }
}