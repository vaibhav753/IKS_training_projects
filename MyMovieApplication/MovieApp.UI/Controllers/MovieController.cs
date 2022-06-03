﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {

        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowMovies()
        {
            using(HttpClient client=new HttpClient())
            {
                string endpint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        string data=await response.Content.ReadAsStringAsync();
                        var movieModel=JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        return View(movieModel);
                    }
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieModel movieModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Movie/AddMovie";
            using(HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie Added Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Add Movie..!!";
                    }
                }
                return View();
            }
          
        }

        [HttpGet]
        public async Task<IActionResult> Updatemovie(int MovieId)
        {
            string URL = _configuration["WebApiURL"] + "Movie/FindMovieById?id=" + MovieId;
            using(HttpClient client = new HttpClient())
            {
                using(var response=await client.GetAsync(URL))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var data= await response.Content.ReadAsStringAsync();
                       var movie = JsonConvert.DeserializeObject<MovieModel>(data);
                        return View(movie);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Updatemovie(MovieModel movieModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            var URL = _configuration["WebApiURL"] + "Movie/EditMovie";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(URL,body))
                {
                   if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowMovies", "Movie");
                    }
                }
            }
            return RedirectToAction("ShowMovies", "Movie");
        }

        [HttpGet]
        public async Task<IActionResult> deleteMovie(int MovieId)
        {
            var URL = _configuration["WebApiURL"] + "Movie/DeleteMovie?id="+ MovieId;
            using(HttpClient client = new HttpClient())
            {
                using(var response = await client.DeleteAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowMovies", "Movie");
                    }
                }
            }
            return RedirectToAction("ShowMovies", "Movie");
        }

    }
}
