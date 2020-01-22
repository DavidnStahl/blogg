using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggUppgift.Models;

namespace BloggUppgift.ViewModels
{
    public class BloggViewModels
    {
        public BloggViewModels()
        {
            BloggInfo = new BloggInfo();
            BloggCategories = new List<BloggCategories>();
        }

        public BloggInfo BloggInfo { get; set; }
        public List<BloggCategories> BloggCategories { get; set; }
    }
}
