using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ArticleViewModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int CountReader { get; set; }
    }
}