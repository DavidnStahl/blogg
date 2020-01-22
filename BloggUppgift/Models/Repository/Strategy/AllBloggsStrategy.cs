using BloggUppgift.Models.Interface;
using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BloggUppgift.Models.Strategy
{
    public class AllBloggsStrategy : ISearchForBloggs
    {
        public List<BloggInfo> Get(ArchiveBloggViewModel model)
        {
            var list = new List<BloggInfo>();
            using (BloggContext db = new BloggContext())
            {
                list = db.BloggInfo.OrderByDescending(r => r.Date).ToList();
            }
            return list;
        }
    }
}
