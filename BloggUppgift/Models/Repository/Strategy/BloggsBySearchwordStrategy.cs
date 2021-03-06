﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggUppgift.Models.Interface;
using BloggUppgift.ViewModels;

namespace BloggUppgift.Models.Strategy
{
    public class BloggsBySearchwordStrategy : ISearchForBloggs
    {
        public List<BloggInfo> Get(ArchiveBloggViewModel model)
        {
            var list = new List<BloggInfo>();
            using (BloggContext db = new BloggContext())
            {
                list = db.BloggInfo.Where(r => r.Heading.StartsWith(model.BloggInfo.Heading)).ToList();
            }

            return list;
        }
    }
}
