using System;
using System.Collections.Generic;

namespace BloggUppgift.Models
{
    public partial class BloggInfo
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Heading { get; set; }
        public string BloggInput { get; set; }

        public virtual BloggCategories Category { get; set; }
    }
}
