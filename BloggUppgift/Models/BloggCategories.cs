using System;
using System.Collections.Generic;

namespace BloggUppgift.Models
{
    public partial class BloggCategories
    {
        public BloggCategories()
        {
            BloggInfo = new HashSet<BloggInfo>();
        }

        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<BloggInfo> BloggInfo { get; set; }
    }
}
