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

        public Response GetAllBlogPostsFromRepo()
        {
            _response = new Response();
            var posts = _repo.GetAllBlogPosts();

            if (posts != null)
            {
                _response.Success = true;
                _response.BlogPosts = posts;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }

        public Response GetAllApprovedBlogPostsFromRepo()
        {
            _response = new Response();
            var posts = _repo.GetAllApprovedBlogPosts();

            if (posts != null)
            {
                _response.Success = true;
                _response.BlogPosts = posts;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }

        public Response GetAllUnapprovedBlogPostsFromRepo()
        {
            _response = new Response();
            var posts = _repo.GetAllUnapprovedBlogPosts();

            if (posts != null)
            {
                _response.Success = true;
                _response.BlogPosts = posts;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;

        }

        public Response GetAllArchivedBlogPostsFromRepo()
        {
            _response = new Response();
            var posts = _repo.GetAllArchivedBlogPosts();

            if (posts != null)
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
            _response = new Response();

            _repo.CreateBlogPostDB(blogPost);

            _response.Success = true;
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

        public Response ApproveBlogPostToRepo(BlogPost blogPost)
        {
            _response = new Response();
            _repo.ApproveBlogPostDB(blogPost);

            _response.Success = true;
            return _response;
        }

        public Response UnapproveBlogPostToRepo(BlogPost blogPost)
        {
            _response = new Response();
            _repo.UnapproveBlogPostDB(blogPost);
            _response.Success = true;
            return _response;
        }

        public Response ArchiveBlogPostToRepo(BlogPost blogPost)
        {
            _response = new Response();
            _repo.ArchiveBlogPostDB(blogPost);
            _response.Success = true;
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


        public Response GetBlogPostByIDFromRepo(int id)
        {
            _response = new Response();

            var post = _repo.GetBlogPostByID(id);

            if (post != null)
            {
                _response.Success = true;
                _response.BlogPost = post;
                return _response;
            }

            _response.Success = false;
            _response.Message = "That is not valid data";
            return _response;
        }


    }
}
