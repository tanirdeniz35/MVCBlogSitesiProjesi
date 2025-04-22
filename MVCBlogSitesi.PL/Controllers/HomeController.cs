using AutoMapper;
using BlogSitesi.BL.DTO;
using BlogSitesi.BL.Managers.Abstract;
using BlogSitesi.PL.Controllers;
using BlogSitesi.PL.Models;
using Microsoft.AspNetCore.Mvc;
using MVCBlogSitesi.PL.Models;
using System.Diagnostics;

namespace MVCBlogSitesi.PL.Controllers
{
    public class HomeController : ControllerMain
    {
        private readonly ILogger<HomeController> _logger;
       
        private readonly IMapper _mapper;
        private readonly IArticleManager _articleManager;

        public HomeController(ILogger<HomeController> logger, ICategoryManager categoryManager,  IMapper mapper, IArticleManager articleManager) :base(categoryManager, mapper)
        {
            _logger = logger;
        
           _mapper = mapper;
            _articleManager = articleManager;
        }

        public IActionResult Index()
        {
            List<ArticleViewModel> list = new List<ArticleViewModel>();
            list =_mapper.Map<List<ArticleViewModel>>( _articleManager.GetAll().OrderByDescending(x=>x.Id));
            return View(list);
        }

        public IActionResult MostRead()
        {
            List<ArticleViewModel> list = new List<ArticleViewModel>();
            list = _mapper.Map<List<ArticleViewModel>>(_articleManager.GetAll().OrderByDescending(x => x.ReadCount));
            return View("Index", list);
        }

        public IActionResult ReadMore(int id)
        {
            ArticleViewModel  article = new  ArticleViewModel ();
            article = _mapper.Map< ArticleViewModel >(_articleManager.GetById(id));
            article.ReadCount++;
            article.Category = null;
            article.MVCBlogSitesiProjesiUser = null;
            _articleManager.Update(_mapper.Map<ArticleDTOModel>( article));
            article = new ArticleViewModel();
            article = _mapper.Map<ArticleViewModel>(_articleManager.GetById(id));
            return View(article);
        }
        public IActionResult Author(string id)
        {
            List<ArticleViewModel> article = new List<ArticleViewModel>();
            article = _mapper.Map<List<ArticleViewModel>>(_articleManager.GetWhere(x=>x.MVCBlogSitesiProjesiUserId== id).OrderByDescending(x => x.Id));
            return View( article );
        }
        public IActionResult Category(int id)
        {
            List<ArticleViewModel> article = new List<ArticleViewModel>();
            article = _mapper.Map<List<ArticleViewModel>>(_articleManager.GetWhere(x => x.CategoryId == id).OrderByDescending(x => x.Id));
            return View("Index", article);
        }


        public IActionResult Search(string q="")
        {
           
            List<ArticleViewModel> article = new List<ArticleViewModel>();
            article = _mapper.Map<List<ArticleViewModel>>(_articleManager.GetWhere(x => x.Category.Name.Contains(q) || x.Content.Contains(q) || x.Title.Contains(q) || x.MVCBlogSitesiProjesiUser.UserName.Contains(q)).OrderByDescending(x => x.Id));
            return View("Index", article);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
