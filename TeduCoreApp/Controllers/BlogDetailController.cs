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


        public BlogDetailController(IBlogService blogService)
        {
            _blogService = blogService;
    
        }
        [Route("{alias}.b-{id}.html")]
        public IActionResult Index(int id)
        {
            BlogDetailIndexViewModel blogDetail = new BlogDetailIndexViewModel() { };
            blogDetail.Bog = _blogService.GetById(id);
            blogDetail.TagsForBlogDetail = _blogService.GetTagByBlogId(id);
           
            return View(blogDetail);
        }
    }
}