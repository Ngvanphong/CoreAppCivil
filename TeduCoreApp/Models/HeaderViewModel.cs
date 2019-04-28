using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Data.ViewModels.Contact;
using TeduCoreApp.Data.ViewModels.Product;

namespace TeduCoreApp.Models
{
    public class HeaderViewModel
    {
        public ContactViewModel contacts { set; get; }

        public List<ProductCategoryViewModel> listProductCategory { get; set; }
    }
}
