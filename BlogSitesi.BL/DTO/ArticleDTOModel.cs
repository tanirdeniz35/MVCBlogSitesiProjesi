

using BlogSitesi.DAL.Data;
using BlogSitesi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.DTO
{
    public class ArticleDTOModel:BaseDTOModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadCount { get; set; }
        public int CategoryId { get; set; }
        public   Category Category { get; set; }
        public string MVCBlogSitesiProjesiUserId { get; set; } 
        public MVCBlogSitesiPLUser MVCBlogSitesiProjesiUser { get; set; }
    }
}
