using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinaSoftRCW.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChinaSoftRCW.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}