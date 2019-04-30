using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeduCoreApp.Data.ViewModels.Blog;
using TeduCoreApp.Data.ViewModels.Tag;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Models
{
 public class BlogIndexViewModel
    {
        public BlogIndexViewModel()
        {
            ResultPagging = new WebResultPaging<BlogViewModel> { };
        }
        public WebResultPaging<BlogViewModel> ResultPagging { get; set; } 

        public string DomainApi { get; set; }
    }
}
