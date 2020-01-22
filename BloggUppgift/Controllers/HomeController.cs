using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BloggUppgift.Models;
using BloggUppgift.ViewModels;

namespace BloggUppgift.Controllers
{
    public class HomeController : Controller
    {
        private BloggContext _context;

        public HomeController(BloggContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var model = new ViewModels.BloggViewModels();
            model.BloggCategories = _context.BloggCategories.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateBlogg(BloggViewModels model)
        {
            if(model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading != null && model.BloggInfo.BloggInput != null)
            {
                var repository = new Models.DBRepository();
                repository.CreateNewBlogg(model.BloggInfo);
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
            var model = new ViewModels.ArchiveBloggViewModel();
            model.BloggCategory.BloggInfo = _context.BloggInfo.OrderByDescending(r => r.Date).ToList();
            model.BloggCategories = _context.BloggCategories.ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult GetBySearch(ArchiveBloggViewModel model)
        {
            var repository = new Models.DBRepository();
            
            model.BloggCategory.BloggInfo = repository.GetBloggs(model).OrderByDescending(r => r.Date).ToList();
            model.BloggCategories = _context.BloggCategories.ToList();
            
            
            
            return View(model);
        }
        public IActionResult ViewBloggPost(int id)
        {
            var repository = new Models.DBRepository();
            var model = new ArchiveBloggViewModel();
            model.BloggInfo = repository.GetBloggDetails(id);
            model.BloggCategories = _context.BloggCategories.ToList();
            return View(model);
        }

    }
}
