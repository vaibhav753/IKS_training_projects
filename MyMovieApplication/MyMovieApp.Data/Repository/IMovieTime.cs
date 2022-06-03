using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IMovieTime
    {
        public string AddMovieTime(ShowMovieTime movieTime);

        List<ShowMovieTime> showAllMovie();

        string DeleteMovieTime(int id);
    }
}
