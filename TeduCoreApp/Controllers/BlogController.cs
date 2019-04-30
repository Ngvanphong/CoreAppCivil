using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Models;
using static TeduCoreApp.Utilities.Constants.CommonConstants;

namespace TeduCoreApp.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;
       
        private IConfiguration _config;
        public BlogController(IBlogService blogService, 
            IConfiguration config)
        {
            _blogService = blogService;
           
            _config = config;
        }
        [Route("blog.html")]
        public IActionResult Index(int page=1,int pageSize=9)
        {
            BlogIndexViewModel blogIndex = new BlogIndexViewModel() { };
            blogIndex.ResultPagging.Items = _blogService.GetAllPaggingByActive(page, pageSize, out int totalRows);
            blogIndex.ResultPagging.PageIndex = page;
            blogIndex.ResultPagging.PageSize = pageSize;
            blogIndex.ResultPagging.TotalRows = totalRows;
            blogIndex.DomainApi= _config["DomainApi:Domain"];

            return View(blogIndex);
        }
    }
}