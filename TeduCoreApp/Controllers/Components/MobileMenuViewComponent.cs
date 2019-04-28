using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Models;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Controllers.Components
{
    public class MobileMenuViewComponent:ViewComponent
    {
        private IProductCategoryService _productCategoryService;
        private IPantnerService _pantnerService;
        private IMemoryCache _cache;
        public MobileMenuViewComponent(IProductCategoryService productCategoryService, IPantnerService pantnerService, IMemoryCache cache)
        {
            _productCategoryService = productCategoryService;
            _pantnerService = pantnerService;
            _cache = cache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = _cache.GetOrCreate(CacheKeys.CategoryMobile, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return new MobileVewModel { listCategory = _productCategoryService.GetAll(), listPantner = _pantnerService.GetAll() };
            });
            return View(category);
        }
    }
}
