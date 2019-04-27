﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Data.ViewModels.Blog;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Blogs")]
    public class Blog : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public Blog() { }
       

        public Blog(BlogViewModel blogVm)
        {
            Name = blogVm.Name;
            Image = blogVm.Image;
            Description = blogVm.Description;
            Content = blogVm.Content;
            HomeFlag = blogVm.HomeFlag;
            HotFlag = blogVm.HotFlag;
            ViewCount = blogVm.ViewCount;
            Tags = blogVm.Tags;
            Status = blogVm.Status;
            SeoPageTitle = blogVm.SeoPageTitle;
            SeoAlias = blogVm.SeoAlias;
            SeoKeywords = blogVm.SeoKeywords;
            SeoDescription = blogVm.SeoDescription;
        }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }


        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Content { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public string Tags { get; set; }

        public virtual ICollection<BlogTag> BlogTags { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }

        [MaxLength(256)]
        public string SeoPageTitle { set; get; }

        [Column(TypeName ="varchar(256)")]
        public string SeoAlias { set; get; }

        [MaxLength(256)]
        public string SeoKeywords { set; get; }

        [MaxLength(256)]
        public string SeoDescription { set; get; }
    }
}
