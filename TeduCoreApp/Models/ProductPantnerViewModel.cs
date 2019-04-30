using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Data.ViewModels.Pantner;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Tag;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Models
{
    public class ProductPantnerViewModel
    {
        public string DomainApi { get; set; }

        public PantnerViewModel Pantner{ get; set; }

        public WebResultPaging<ProductViewModel> WebResultPaging { set; get; }

        public List<TagViewModel> Tags { get; set; }
    }
}
