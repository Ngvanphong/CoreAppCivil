﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Models;
using TeduCoreApp.Utilities.Dtos;
using static TeduCoreApp.Utilities.Constants.CommonConstants;

namespace TeduCoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ISlideService _slideService;        
        private IConfiguration _config;
        private IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, ISlideService slideService,
            IConfiguration config,IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _slideService = slideService;
           
            _config = config;
            _productCategoryService = productCategoryService;
        }

        [Route("{alias}.pc-{id}.html")] 
        public IActionResult Index(int id)
        {
            ProductIndexViewModel product = new ProductIndexViewModel() { };
            product.ProductCategory = _productCategoryService.GetById(id);
            product.Slides = _slideService.GetAll();
           
            product.Tags = _productService.GetAllTag(15);
            product.DomainApi = _config["DomainApi:Domain"];
            return View(product);
        }

        [Route("product/getProductByCategory")]
        [HttpGet]
        public IActionResult GetProduct(int id,int page,int pageSize)
        {
            List<ProductViewModel> products = _productService.GetAllByCategoryPaging(id, page, pageSize, out int totalRows);
            return new OkObjectResult(new WebResultPaging<ProductViewModel>()
            {              
                Items = products,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            });
        }

        [Route("product/search")]
        [HttpGet]
        public IActionResult Search(string term)
        {
            List<string> listNames = _productService.GetProductName(term);
            return new OkObjectResult(new { data = listNames });
        }

        [Route("product/search.html")]
        [HttpGet]
        public IActionResult SearchProduct(string searchProduct, int page=1,int pageSize=9)
        {
            ViewBag.SearchName = searchProduct;
            ViewBag.DomainApi = _config["DomainApi:Domain"];
            List<ProductViewModel> products = _productService.GetAllByNamePaging(searchProduct, page, pageSize, out int totalRows);
            WebResultPaging<ProductViewModel> resultPagging =new WebResultPaging<ProductViewModel>()
            {
                Items = products,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            };
            return View(resultPagging);
        }

    }
}