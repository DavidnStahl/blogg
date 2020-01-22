using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggUppgift.Models.Strategy;

namespace BloggUppgift.Models
{
    public class DBRepository
    {
        public void CreateNewBlogg(BloggInfo model)
        {
            using (BloggContext db = new BloggContext())
            {               
                var blogg = new BloggInfo()
                {
                    CategoryId = model.CategoryId,
                    Date = DateTime.Now,
                    BloggInput = model.BloggInput,              
                    Heading = model.Heading
                };
                db.BloggInfo.Add(blogg);
                db.SaveChanges();          
            }
        }
        public List<BloggInfo> GetBloggs(ArchiveBloggViewModel model)
        {
            var list = new List<BloggInfo>();
            if ((model.BloggInfo.CategoryId == 4 ||model.BloggInfo.CategoryId == 0) && model.BloggInfo.Heading == null)
            {
                return new AllBloggsStrategy().Get(model); 
            }
            else if((model.BloggInfo.CategoryId == 0 || model.BloggInfo.CategoryId == 4)&& model.BloggInfo.Heading != null)
            {
                return new BloggsBySearchwordStrategy().Get(model);
            }
            else if(model.BloggInfo.CategoryId != 4 && model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading == null)
            {
                return new BloggsByCategoryStrategy().Get(model);
            }
            else if(model.BloggInfo.CategoryId != 4 && model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading != null)
            {
                return new BloggsByCategoryAndSearchwordStrategy().Get(model);
            }
            return list;
        }
        public BloggInfo GetBloggDetails(int id)
        {
            var blogg = new BloggInfo();
            using (BloggContext db = new BloggContext())
            {
                blogg = db.BloggInfo.FirstOrDefault(r => r.Id == id);
                
            }
            return blogg;
        }
    }
}
