﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PcRepaire.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}