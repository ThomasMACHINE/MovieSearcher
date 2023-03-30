using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ApiHandler;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Movie Endpoint
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Movie([FromForm] string title, [FromForm] string actor, [FromForm] string director)
        {
            Movie movie;
            try
            {
                movie = await MovieHandler.CreateMovie(title);
            } // Figure out how handle errors gracefully
            catch (Exception e)
            {
                return View(null);
            }
            return View(movie);
        }
    }
}
