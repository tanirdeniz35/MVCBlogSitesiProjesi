using AutoMapper;
using BlogSitesi.BL.DTO;
using BlogSitesi.PL.Models;

namespace BlogSitesi.PL.MapperProfiles
{
    public class AutoMapperViewProfile : Profile
    {
        public AutoMapperViewProfile()
        {
            CreateMap<ArticleViewModel, ArticleDTOModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDTOModel>().ReverseMap(); 
        }
    }
}
