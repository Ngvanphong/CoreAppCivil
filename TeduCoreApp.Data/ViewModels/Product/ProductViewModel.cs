﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.ViewModels.Pantner;


namespace TeduCoreApp.Data.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        [MaxLength(500)]
        public string ThumbnailImage { get; set; }

        [StringLength(255)]
        public string Tag { get; set; }

        public  ProductCategoryViewModel ProductCategory { set; get; }

        public string SeoPageTitle { set; get; }

        [StringLength(255)]
        public string SeoAlias { set; get; }

        [StringLength(255)]
        public string SeoKeywords { set; get; }

        [StringLength(255)]
        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public Status Status { set; get; }

        public int? PantnerId { set; get; }
       
        public virtual PantnerViewModel Pantner { get; set; }



    }
}
