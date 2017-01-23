﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mvccoreappgithub.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content("Farshid Ahmadi");
        }

        public IActionResult Index1(int id, string name)
        {
            ViewBag.id = id;
            ViewBag.name = name;

            return View();
        }

    }
}
