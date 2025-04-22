using BlogSitesi.DAL.Entities.Common;
using MVCBlogSitesiProjesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSitesi.DAL.Data;
namespace BlogSitesi.DAL.Entities
{
    public class Article:BaseEntity
    { 
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadCount { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string MVCBlogSitesiProjesiUserId { get; set; }
        public virtual MVCBlogSitesiPLUser MVCBlogSitesiProjesiUser { get; set; }
    }
}
