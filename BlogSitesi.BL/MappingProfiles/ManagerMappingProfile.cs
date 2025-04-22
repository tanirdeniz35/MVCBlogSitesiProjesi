using AutoMapper;
using BlogSitesi.BL.DTO;
using BlogSitesi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.MappingProfiles
{
    public class ManagerMappingProfile : Profile
    {
        public ManagerMappingProfile()
        {
            CreateMap<Article, ArticleDTOModel>().ReverseMap();
            CreateMap<Category, CategoryDTOModel>().ReverseMap(); 
        }
    }
}
