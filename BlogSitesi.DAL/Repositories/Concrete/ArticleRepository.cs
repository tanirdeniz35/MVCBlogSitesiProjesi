 
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Repositories.Abstract;
using MVCBlogSitesiProjesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.DAL.Repositories.Concrete
{
    public class ArticleRepository : Repository<Article>,IArticleRepository
    {
        public ArticleRepository(MVCBlogSitesiPLContext BlogSitesiDbContext) : base(BlogSitesiDbContext)
        {
        }
    }
}
