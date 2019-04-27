using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Models;
using TeduCoreApp.Utilities.Dtos;
using static TeduCoreApp.Utilities.Constants.CommonConstants;

namespace TeduCoreApp.Controllers
{
    public class ProductTagController : Controller
    {
        private IProductService _productService;
        private ISlideService _slideService;
       
       
        private IConfiguration _config;
        public ProductTagController(IProductService productService,ISlideService slideService,
            IConfiguration config)
        {
            _productService = productService;
            _slideService = slideService;
           
            _config = config;
        }

        [Route("pt-{id}.html")]
        public IActionResult Index(string id)
        {
            ProductTagIndexViewModel productTag = new ProductTagIndexViewModel() { };
            productTag.DomainApi= _config["DomainApi:Domain"];
           
            productTag.Slides = _slideService.GetAll(true);
            productTag.ProductTag = _productService.GetTagById(id);
            productTag.Tags = _productService.GetAllTag(15);
            return View(productTag);
        }

        [Route("productTag/getProductByTag")]
        [HttpGet]
        public IActionResult GetProduct(string tag, int page, int pageSize)
        {
            List<ProductViewModel> products = _productService.GetAllByTagPaging(tag, page, pageSize, out int totalRows);
            return new OkObjectResult(new WebResultPaging<ProductViewModel>()
            {
                Items = products,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            });
        }
    }
}