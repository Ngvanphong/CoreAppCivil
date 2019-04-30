using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Models;

namespace TeduCoreApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private IProductService _productService;
        private IConfiguration _config;
        private IProductImageService _productImageService;
       
        public ProductDetailController(IProductService productService, IConfiguration config,IProductImageService productImageService
            )
        {
            _productService = productService;
            _config = config;
            _productImageService = productImageService;
     
        }
        [Route("{alias}.p-{id}.html")]
        public IActionResult Index(int id)
        {
            ProductDetailViewModel productDetail = new ProductDetailViewModel() { };
            productDetail.ProductDetail = _productService.GetById(id);
            productDetail.ProductRelate = _productService.GetProductRelate(productDetail.ProductDetail.CategoryId,6);                  
            productDetail.DomainApi= _config["DomainApi:Domain"];
            productDetail.ProductImages = _productImageService.GetProductImageByProdutId(id);
           
            return View(productDetail);
        }


    }
}