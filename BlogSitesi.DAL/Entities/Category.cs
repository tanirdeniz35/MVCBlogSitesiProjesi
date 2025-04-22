using BlogSitesi.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.DAL.Entities
{
    public class Category:BaseEntity
    {
         
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
