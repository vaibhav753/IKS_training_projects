using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieApp.UI.Models;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
       

        //IActionResult also has one more type JsonResult
        public async Task<IActionResult> IndexAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        return View(movieModel);
                    }
                }

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
