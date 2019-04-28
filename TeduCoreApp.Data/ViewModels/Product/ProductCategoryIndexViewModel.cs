using System;
using System.Collections.Generic;
using System.Text;
using TeduCoreApp.Data.Enums;

namespace TeduCoreApp.Data.ViewModels.Product
{
   public class ProductCategoryIndexViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

       
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

       
        public string SeoPageTitle { set; get; }

        public string SeoAlias { set; get; }

        
        public string SeoKeywords { set; get; }

       
        public string SeoDescription { set; get; }

        public virtual ICollection<ProductViewModel> Products { set; get; }
    }
}
