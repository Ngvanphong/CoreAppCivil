using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Data.ViewModels.Blog;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Slide;

namespace TeduCoreApp.Models
{
    public class HomeViewModel
    {
    public List<SlideViewModel> ListSlide { get; set; }

    public string DomainApi { get; set; }

    public List<ProductCategoryIndexViewModel> ListCategory { get; set; }
        
   
    }
}
