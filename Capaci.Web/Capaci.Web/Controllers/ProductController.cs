﻿using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
