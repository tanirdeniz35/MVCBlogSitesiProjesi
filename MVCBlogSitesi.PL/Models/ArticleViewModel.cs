

using BlogSitesi.DAL.Data;
using BlogSitesi.DAL.Entities;

namespace BlogSitesi.PL.Models
{
    public class ArticleViewModel: BaseViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int ReadCount { get; set; }
        public Category Category { get; set; }
 
        public string MVCBlogSitesiProjesiUserId { get; set; }
        public   MVCBlogSitesiPLUser MVCBlogSitesiProjesiUser { get; set; }
    }
}
