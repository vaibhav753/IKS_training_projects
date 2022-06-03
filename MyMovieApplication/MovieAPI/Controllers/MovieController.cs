using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieServices;

        public MovieController(MovieService movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieServices.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieServices.AddMovie(movieModel));
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok(_movieServices.DeleteMovie(id));
        }

        [HttpPut("EditMovie")]
        public IActionResult EditMovie(MovieModel movieModel)
        {
            return Ok(_movieServices.EditMovie(movieModel));
        }

        [HttpGet("FindMovieById")]
        public IActionResult FindMovieById(int id)
        {
            return Ok(_movieServices.FindMovieById(id));
        }
    }
}
