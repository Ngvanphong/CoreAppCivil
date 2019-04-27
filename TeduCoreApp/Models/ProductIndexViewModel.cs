using System.Collections.Generic;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Slide;
using TeduCoreApp.Data.ViewModels.Tag;

namespace TeduCoreApp.Models
{
    public class ProductIndexViewModel
    {
        public List<SlideViewModel> Slides { get; set; }
        public List<TagViewModel> Tags { get; set; }
        public string DomainApi { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}