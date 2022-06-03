using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTimeController : ControllerBase
    {
        MovieTimeService _movieTimeService;

        public MovieTimeController(MovieTimeService movieTimeService)
        {
            _movieTimeService = movieTimeService;
        }

        [HttpPost("AddMovieTime")]
        public IActionResult AddMovieTime(ShowMovieTime showMovieTime)
        {
            return Ok(_movieTimeService.AddMovieTime(showMovieTime));
        }

        [HttpGet("ShowAllMovieTime")]
        public IActionResult ShowAllMovieTime()
        {
            return Ok(_movieTimeService.ShowAllMovie());
        }

        [HttpDelete("delete")]
        public IActionResult DeleteMovieTime(int id)
        {
            return Ok(_movieTimeService.DeleteMovieTime(id));
        }
    }
}
