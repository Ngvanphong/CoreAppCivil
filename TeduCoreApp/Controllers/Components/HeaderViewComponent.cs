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
    public class HeaderViewComponent:ViewComponent
    {
        private IContactService _contactService;
        private IProductCategoryService _productCategoryService;
        private IMemoryCache _cache;
        public HeaderViewComponent(IContactService contactServie, IProductCategoryService productCategoryService, IMemoryCache cache)
        {
            _contactService = contactServie;
            _productCategoryService = productCategoryService;
            _cache = cache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerCache = _cache.GetOrCreate(CacheKeys.Header, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                HeaderViewModel header = new HeaderViewModel() { };
                header.contacts = _contactService.GetContact();
                header.listProductCategory = _productCategoryService.GetCategoryHeader();
                return header;
            });
            return View(headerCache);
        }
    }
}
