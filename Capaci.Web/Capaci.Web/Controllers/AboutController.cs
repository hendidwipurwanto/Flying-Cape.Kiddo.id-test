﻿using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
