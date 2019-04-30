﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Models;
using static TeduCoreApp.Utilities.Constants.CommonConstants;

namespace TeduCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ISlideService _slideService;
        private IProductCategoryService _productCategoryService;

        private IBlogService _blogService;
        private IConfiguration _config;
       
        private ISystemConfigService _systemConfig;
        public HomeController(IProductService productService, ISlideService slideService,
            IBlogService blogService, IConfiguration config, ISystemConfigService systemConfig, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _slideService = slideService;
            _productCategoryService = productCategoryService;
           
            _blogService = blogService;
            _config = config;
            
            _systemConfig = systemConfig;
        }
        [ResponseCache(Duration=600, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            
            HomeViewModel homeVm = new HomeViewModel() { };
            homeVm.ListCategory= _productCategoryService.GetAllIncludeProduct();   
            homeVm.ListSlide = _slideService.GetAll();         
            homeVm.DomainApi = _config["DomainApi:Domain"];
            ViewBag.HomeTitle = _systemConfig.Detail("HomeTitle").Value1;
            ViewBag.HomeMetaDescription = _systemConfig.Detail("HomeMetaDescription").Value1;
            ViewBag.HomeMetaKeyword = _systemConfig.Detail("HomeMetaKeyword").Value1;
            return View(homeVm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}