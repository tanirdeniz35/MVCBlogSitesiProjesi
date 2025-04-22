using BlogSitesi.BL.DTO;
 
using BlogSitesi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.Managers.Abstract
{
    public interface IArticleManager:IManager<ArticleDTOModel,Article>
    {
    }
}
