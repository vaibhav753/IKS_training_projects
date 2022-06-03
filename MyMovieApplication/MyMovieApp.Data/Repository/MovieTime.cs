using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class MovieTime : IMovieTime
    {
        MovieDbContext _movieDbContext;

        public MovieTime(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddMovieTime(ShowMovieTime movieTime)
        {
            _movieDbContext.MovieTime.Add(movieTime);
            _movieDbContext.SaveChanges();
            return "Movie Time Added Successfully...!!";
        }

        public List<ShowMovieTime> showAllMovie()
        {
            return _movieDbContext.MovieTime.ToList();
        }

       public string DeleteMovieTime(int id)
        {
            ShowMovieTime foundMovieTime = _movieDbContext.MovieTime.Find(id);
            if(foundMovieTime != null)
            {
                _movieDbContext.MovieTime.Remove(foundMovieTime);
                _movieDbContext.SaveChanges();
                return "Successfully Deleted MovieTime..!!";
            }
            else
            {
                return "Sorry Unable TO Delete MovieTime..";
            }
        }
    }
}
