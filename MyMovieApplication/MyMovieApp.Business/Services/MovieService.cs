using MyMovieApp.Data.DataConnection;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class MovieService
    {
        IMovie movie;

        public MovieService(IMovie movie)
        {
            this.movie = movie;
        }

        public string AddMovie(MovieModel movieModel)
        {
            return movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return movie.SelectMovie();
        }

        public string DeleteMovie(int id)
        {
            return movie.DeleteMovie(id);
        }

        public string EditMovie(MovieModel movieModel)
        {
            return movie.EditMovie(movieModel);
        }

        public object FindMovieById(int id)
        {
            return movie.findMovieById(id);
        }

    }
}
