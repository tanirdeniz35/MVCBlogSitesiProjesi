 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.DTO
{
    public class CategoryDTOModel:BaseDTOModel
    {
        public string Name { get; set; }
        public ICollection<ArticleDTOModel> Articles { get; set; }
    }
}
