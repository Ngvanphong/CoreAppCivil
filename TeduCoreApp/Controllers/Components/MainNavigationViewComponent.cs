using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Controllers.Components
{
    public class MainNavigationViewComponent:ViewComponent
    {
        public MainNavigationViewComponent()
        {
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {                     
            return View();
        }
    }
}
