using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFindsBlog.Models
{
    [Table("BlogPosts")] // Table name
    public class BlogPost
    {
        [Key] // Primary key
        public int BlogPostID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Hashtag")]
        public int HashtagID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
    }
}
