using AutoMapper;

using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.ViewModels.Blog;
using TeduCoreApp.Data.ViewModels.Contact;
using TeduCoreApp.Data.ViewModels.FunctionVm;
using TeduCoreApp.Data.ViewModels.Identity;
using TeduCoreApp.Data.ViewModels.Page;
using TeduCoreApp.Data.ViewModels.Pantner;
using TeduCoreApp.Data.ViewModels.Permission;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Slide;
using TeduCoreApp.Data.ViewModels.SystemConfig;
using TeduCoreApp.Data.ViewModels.Tag;

namespace TeduCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c));
            CreateMap<FunctionViewModel, Function>()
               .ConstructUsing(c => new Function(c));
            CreateMap<ProductViewModel, Product>()
               .ConstructUsing(c => new Product(c));
            CreateMap<ProductImageViewModel, ProductImage>()
              .ConstructUsing(c => new ProductImage(c));

            CreateMap<AppRoleViewModel, AppRole>()
            .ConstructUsing(c => new AppRole(c.Name, c.Description));
            CreateMap<AppUserViewModel, AppUser>()
             .ConstructUsing(c => new AppUser(c));
            CreateMap<PermissionViewModel, Permission>()
             .ConstructUsing(c => new Permission(c));
            CreateMap<BlogViewModel, Blog>()
            .ConstructUsing(c => new Blog(c));
            CreateMap<TagViewModel, Tag>()
           .ConstructUsing(c => new Tag(c));
            CreateMap<BlogTagViewModel, BlogTag>()
           .ConstructUsing(c => new BlogTag(c));
            CreateMap<BlogImageViewModel, BlogImage>()
            .ConstructUsing(c => new BlogImage(c));
            CreateMap<SlideViewModel, Slide>()
             .ConstructUsing(c => new Slide(c));

            CreateMap<ContactViewModel, Contact>()
           .ConstructUsing(c => new Contact(c));
            CreateMap<PageViewModel, Page>()
          .ConstructUsing(c => new Page(c));
            CreateMap<PageImageViewModel, PageImage>()
          .ConstructUsing(c => new PageImage(c));
            CreateMap<PantnerViewModel, Pantner>()
          .ConstructUsing(c => new Pantner(c));

            CreateMap<SystemConfigViewModel, SystemConfig>()
         .ConstructUsing(c => new SystemConfig(c));
        }
    }
}