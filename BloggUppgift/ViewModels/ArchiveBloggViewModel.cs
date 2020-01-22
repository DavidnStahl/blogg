using BloggUppgift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggUppgift.ViewModels
{
    public class ArchiveBloggViewModel
    {
        public ArchiveBloggViewModel()
        {
            BloggInfo = new BloggInfo();
            BloggCategory = new BloggCategories();
            BloggCategories = new List<BloggCategories>();
        }

        public BloggInfo BloggInfo { get; set; }
        public BloggCategories BloggCategory { get; set; }
        public List<BloggCategories> BloggCategories { get; set; }
    }
}
