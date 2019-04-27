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
    public class BlogDetailController : Controller
    {
        private IBlogService _blogService;
       
        private IConfiguration _config;

        public BlogDetailController(IBlogService blogService, 
            IConfiguration config)
        {
            _blogService = blogService;
           
            _config = config;
        }
        [Route("{alias}.b-{id}.html")]
        public IActionResult Index(int id)
        {
            BlogDetailIndexViewModel blogDetail = new BlogDetailIndexViewModel() { };
            blogDetail.Bog = _blogService.GetById(id);
            blogDetail.TagsForBlogDetail = _blogService.GetTagByBlogId(id);
            blogDetail.DomainApi = _config["DomainApi:Domain"];
            blogDetail.Tags = _blogService.GetTagBlogTop(15);
           
            return View(blogDetail);
        }
    }
}