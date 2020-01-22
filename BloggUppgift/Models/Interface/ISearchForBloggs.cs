using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggUppgift.Models.Interface
{

    interface ISearchForBloggs
    {
        List<BloggInfo> Get(ArchiveBloggViewModel model);
    }
}
