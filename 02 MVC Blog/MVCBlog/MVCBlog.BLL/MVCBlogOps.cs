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
            _response.Message = "That is not vaild data";
            return _response;
        }






    }
}
