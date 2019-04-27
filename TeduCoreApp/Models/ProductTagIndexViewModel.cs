using System.Collections.Generic;
using TeduCoreApp.Data.ViewModels.Slide;
using TeduCoreApp.Data.ViewModels.Tag;

namespace TeduCoreApp.Models
{
    public class ProductTagIndexViewModel
    {
        public List<SlideViewModel> Slides { get; set; }
        public string DomainApi { get; set; }
        public TagViewModel ProductTag { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}