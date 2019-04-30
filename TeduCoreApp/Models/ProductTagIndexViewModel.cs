using System.Collections.Generic;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Slide;
using TeduCoreApp.Data.ViewModels.Tag;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Models
{
    public class ProductTagIndexViewModel
    {
        public WebResultPaging<ProductViewModel> WebResultPaging { set; get; }
        public string DomainApi { get; set; }
        public TagViewModel ProductTag { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}