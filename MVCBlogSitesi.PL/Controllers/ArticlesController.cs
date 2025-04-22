using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogSitesi.DAL.Entities;
using MVCBlogSitesiProjesi.Data;
using Microsoft.AspNetCore.Identity;
using BlogSitesi.DAL.Data;
using BlogSitesi.BL.Managers.Abstract;
using AutoMapper;
using BlogSitesi.PL.Models;
using BlogSitesi.BL.DTO;

namespace BlogSitesi.PL.Controllers
{
    public class ArticlesController : Controller
    {
  
        private readonly IArticleManager _articleManager;
        private readonly ICategoryManager _categoryManager;
        private readonly UserManager<MVCBlogSitesiPLUser> _userManager;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleManager articleManager, ICategoryManager categoryManager, UserManager<MVCBlogSitesiPLUser> userManager, IMapper mapper)
        {
         
            _articleManager = articleManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var mVCBlogSitesiPLContext = _mapper.Map<List<ArticleViewModel>>( _articleManager.GetWhere(x=>x.MVCBlogSitesiProjesiUserId== userId).OrderByDescending(x=>x.Id));
            return View(  mVCBlogSitesiPLContext);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article =_articleManager.GetById( (int) id);
            if (article == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ArticleViewModel>( article));
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewData["CategoryId"] = new SelectList(_mapper.Map<List<CategoryViewModel>>( _categoryManager.GetAll()), "Id", "Name");
            ViewData["MVCBlogSitesiProjesiUserId"] = userId;
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,PublishDate,CategoryId,MVCBlogSitesiProjesiUserId,Id,KayitTarihi,GuncellemeTarihi,SilmeTarihi,SilindiMi")] ArticleViewModel article)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
  
            ModelState.Remove("Category");
            ModelState.Remove("MVCBlogSitesiProjesiUser");
            ModelState.Remove("MVCBlogSitesiProjesiUserId");
            if (ModelState.IsValid)
            {
                article.MVCBlogSitesiProjesiUserId = userId;
                _articleManager.Add(_mapper.Map<ArticleDTOModel>( article));
 
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_mapper.Map<List<CategoryViewModel>>(_categoryManager.GetAll()), "Id", "Name", article.CategoryId);
            ViewData["MVCBlogSitesiProjesiUserId"] = userId;
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(HttpContext.User);

            var article =_mapper.Map<ArticleViewModel>( _articleManager.GetById((int)id));
            if (article == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_mapper.Map<List<CategoryViewModel>>(_categoryManager.GetAll()), "Id", "Name", article.CategoryId);
            ViewData["MVCBlogSitesiProjesiUserId"] = userId ;
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Content,PublishDate,CategoryId,MVCBlogSitesiProjesiUserId,Id,KayitTarihi,GuncellemeTarihi,SilmeTarihi,SilindiMi")] ArticleViewModel article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(HttpContext.User);

            ModelState.Remove("Category");
            ModelState.Remove("MVCBlogSitesiProjesiUser");
            ModelState.Remove("MVCBlogSitesiProjesiUserId");
            if (ModelState.IsValid)
            {
                try
                {
                    article.MVCBlogSitesiProjesiUserId = userId;
                    _articleManager.Update(_mapper.Map<ArticleDTOModel>( article)); 
                     
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_mapper.Map<List<CategoryViewModel>>(_categoryManager.GetAll()), "Id", "Name", article.CategoryId);
            ViewData["MVCBlogSitesiProjesiUserId"] = userId;
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articleManager.GetById((int)id);
             
            if (article == null)
            {
                return NotFound();
            }

            return View(_mapper.Map < ArticleViewModel >  (article));
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = _articleManager.GetById(id);
            article.Category = null;
            article.MVCBlogSitesiProjesiUser = null;
            
            if (article != null)
            {
                _articleManager.Remove(article);
            } 
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _articleManager.GetById(id) == null ? false : true;  
        }
    }
}
