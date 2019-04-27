using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, IHasSeoMetaData, ISwitchable, IDateTracking
    {
        public Product()
        {

        }
        public Product(ProductViewModel productVm)
        {
            Name = productVm.Name;
            CategoryId = productVm.CategoryId;                    
            Description = productVm.Description;
            Content = productVm.Content;
            Tag = productVm.Tag;           
            Status = productVm.Status;
            SeoPageTitle = productVm.SeoPageTitle;
            SeoAlias = productVm.SeoAlias;
            SeoKeywords = productVm.SeoKeywords;
            SeoDescription = productVm.SeoDescription;
            ThumbnailImage = productVm.ThumbnailImage;
        }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
         
        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        [MaxLength(500)]
        public string ThumbnailImage { get; set; }

        [MaxLength(255)]
        public string Tag { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
        [MaxLength(255)]
        public string SeoPageTitle { set; get; }
        [Column(TypeName ="varchar(255)")]
        public string SeoAlias { set; get; }
        [MaxLength(255)]
        public string SeoKeywords { set; get; }
        [MaxLength(255)]
        public string SeoDescription { set; get; }
    }
}
