using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.Data;
using MVCBlog.Models;

namespace MVCBlog.BLL
{
    public class MVCBlogOps
    {
        private MVCBlogRepo _repo = new MVCBlogRepo();
        private Response _response;

        public Response GetAllBlogPostFromRepo()
        {
            _response = new Response();
            var posts = _repo.GetAllBlogPosts();

            if ( posts != null)
            {
                _response.Success = true;
                _response.BlogPosts = posts;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }

        public Response SaveBlogPostToRepo(BlogPost blogPost)
        {
            _repo.CreateBlogPostDB(blogPost);

            return _response;
        }

        public Response GetAllCategoriesFromRepo()
        {
            _response = new Response();

            var categories = _repo.GetAllCategories();

            if (categories != null)
            {
                _response.Success = true;
                _response.Categories = categories;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }

        public Response GetAllHashTagsFromRepo()
        {
            _response = new Response();

            var hashTags = _repo.GetAllHashTags();

            if (hashTags != null)
            {
                _response.Success = true;
                _response.HashTags = hashTags;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }



    }
}
