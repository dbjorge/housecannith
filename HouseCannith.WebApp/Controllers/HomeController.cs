using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseCannith.Data;
using HouseCannith.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseCannith.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ComprendiumDbContext _comprendiumDbContext;

        public HomeController(ComprendiumDbContext comprendiumDbContext)
        {
            _comprendiumDbContext = comprendiumDbContext;
        }

        public IActionResult Index()
        {
            ViewData["TestData"] = _comprendiumDbContext.Class.First().Name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
