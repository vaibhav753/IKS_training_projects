using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class MovieTimeService
    {
        IMovieTime _imovieTime;

        public MovieTimeService(IMovieTime imovieTime)
        {
            _imovieTime = imovieTime;
        }

        public string AddMovieTime(ShowMovieTime showMovieTime)
        {
            return _imovieTime.AddMovieTime(showMovieTime);
        }

        public List<ShowMovieTime> ShowAllMovie()
        {
            return _imovieTime.showAllMovie();
        }
        
        public string DeleteMovieTime(int id)
        {
            return _imovieTime.DeleteMovieTime(id);
        }

    }
}
