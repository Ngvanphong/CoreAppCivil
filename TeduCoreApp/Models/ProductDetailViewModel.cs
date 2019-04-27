using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Tag;

namespace TeduCoreApp.Models
{
    public class ProductDetailViewModel
    {
        public ProductViewModel ProductDetail { get; set; }

        public List<ProductViewModel> ProductRelate { get; set; }

        public List<ProductViewModel> ProductUpsell { get; set; }

        public List<TagViewModel> ProductTags { set; get; }


        public string DomainApi { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
     
    }
}
