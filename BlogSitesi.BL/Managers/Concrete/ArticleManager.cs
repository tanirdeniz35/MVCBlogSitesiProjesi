using BlogSitesi.BL.DTO;
using BlogSitesi.BL.Managers.Abstract;
 
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.Managers.Concrete
{
    public class ArticleManager : Manager<ArticleDTOModel, Article>, IArticleManager
    {
        public ArticleManager(Repository<Article> repository) : base(repository)
        {
        }
    }
}
