using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BloggUppgift.Models;
using BloggUppgift.ViewModels;
using BloggUppgift.Models.Strategy;
using BloggUppgift.ViewModels;

namespace BloggUppgift.Controllers
{
    public class HomeController : Controller
    {
        private BloggContext _context;
        private DBRepository _repository = new DBRepository();
        private BloggViewModels _bloggViewModel = new BloggViewModels();
        private ArchiveBloggViewModel _archivedBloggViewModel = new ArchiveBloggViewModel();

        public HomeController(BloggContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            _bloggViewModel.BloggCategories = _context.BloggCategories.ToList();
            return View(_bloggViewModel);
        }
        [HttpPost]
        public IActionResult CreateBlogg(BloggViewModels model)
        {
            if(model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading != null && model.BloggInfo.BloggInput != null)
            {
                _repository.CreateNewBlogg(model.BloggInfo);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult ArchivedPosts()
        {
            _archivedBloggViewModel.BloggCategory.BloggInfo = _context.BloggInfo.OrderByDescending(r => r.Date).ToList();
            _archivedBloggViewModel.BloggCategories = _context.BloggCategories.ToList();

            return View(_archivedBloggViewModel);
        }
        [HttpGet]
        public IActionResult GetBySearch(ArchiveBloggViewModel model)
        {
            _archivedBloggViewModel.BloggCategory.BloggInfo = _repository.GetBloggs(model).OrderByDescending(r => r.Date).ToList();
            _archivedBloggViewModel.BloggCategories = _context.BloggCategories.ToList();
            return View(_archivedBloggViewModel);
        }
        public IActionResult ViewBloggPost(int id)
        {
            _archivedBloggViewModel.BloggInfo = _repository.GetBloggDetails(id);
            _archivedBloggViewModel.BloggCategories = _context.BloggCategories.ToList();
            return View(_archivedBloggViewModel);
        }

    }
}
