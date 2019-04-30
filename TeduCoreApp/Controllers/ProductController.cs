using Microsoft.AspNetCore.Mvc;
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
        private IPantnerService _pantnerService;

        public ProductController(IProductService productService, ISlideService slideService,
            IConfiguration config,IProductCategoryService productCategoryService, IPantnerService pantnerService)
        {
            _productService = productService;
            _slideService = slideService;
            _pantnerService = pantnerService;
            _config = config;
            _productCategoryService = productCategoryService;
        }

        [Route("{alias}.pc-{id}.html")] 
        public IActionResult Index(int id, int pageSize=20, int page = 1)
        {
            ProductIndexViewModel product = new ProductIndexViewModel() { };
            product.ProductCategory = _productCategoryService.GetById(id);           
            product.Tags = _productService.GetAllTag(15);
            product.DomainApi = _config["DomainApi:Domain"];
            List<ProductViewModel> productLists = _productService.GetAllByCategoryPaging(id, page, pageSize, out int totalRows);
            product.WebResultPaging=new WebResultPaging<ProductViewModel>()
            {
                Items = productLists,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            };
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
        public IActionResult Search(string term,string categoryid)
        {
            List<string> listNames = _productService.GetProductName(term, categoryid);
            return new OkObjectResult(new { data = listNames });
        }

        [Route("product/search.html")]
        [HttpGet]
        public IActionResult SearchProduct(string searchProduct,string categoryid, int page=1,int pageSize=9)
        {
            ViewBag.SearchName = searchProduct;
            ViewBag.DomainApi = _config["DomainApi:Domain"];
            List<ProductViewModel> products = _productService.GetAllByNamePaging(searchProduct,categoryid, page, pageSize, out int totalRows);
            WebResultPaging<ProductViewModel> resultPagging =new WebResultPaging<ProductViewModel>()
            {
                Items = products,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            };
            return View(resultPagging);
        }

        [Route("pantner-{id}.html")]
        public IActionResult ProductPantner(int id, int pageSize = 20, int page = 1)
        {
            ProductPantnerViewModel product = new ProductPantnerViewModel() { };             
            product.Tags = _productService.GetAllTag(15);
            product.DomainApi = _config["DomainApi:Domain"];
            List<ProductViewModel> productLists = _productService.GetAllByPantner(id, page, pageSize, out int totalRows);
            product.Pantner = _pantnerService.GetById(id);
            product.WebResultPaging = new WebResultPaging<ProductViewModel>()
            {
                Items = productLists,
                PageIndex = page,
                PageSize = pageSize,
                TotalRows = totalRows,
            };
            return View(product);
        }

    }
}