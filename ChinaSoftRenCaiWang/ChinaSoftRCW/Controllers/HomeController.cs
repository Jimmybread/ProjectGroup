using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChinaSoftRCW.Models;
using Microsoft.Extensions.Hosting;
using ChinaSoftRCW.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace ChinaSoftRCW.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            IDataRepository dataRepository,
            IHostEnvironment hostEnvironment) : base(dataRepository, hostEnvironment)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
