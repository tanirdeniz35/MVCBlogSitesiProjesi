using AutoMapper;
using BlogSitesi.BL.Managers.Abstract;
using BlogSitesi.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogSitesi.PL.Controllers
{
    public class ControllerMain : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public ControllerMain( ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
            ViewData["Categories"] = _mapper.Map<List<CategoryViewModel>>( _categoryManager.GetAll());
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // Set ViewData["Categories"] for all views
            ViewData["Categories"] = _mapper.Map<List<CategoryViewModel>>(_categoryManager.GetAll());
        }

    }
}
