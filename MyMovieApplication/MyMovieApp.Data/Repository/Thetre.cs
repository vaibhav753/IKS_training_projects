using Microsoft.EntityFrameworkCore;
using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class Thetre : IThetre
    {
        MovieDbContext _movieDbContext;

        public Thetre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }


        //crud Operations
        public string AddThetre(ThetreModel thetreModel)
        {
            string message = "";
            _movieDbContext.thetreModels.Add(thetreModel);
            _movieDbContext.SaveChanges();
            message = "Thetre Added Successfully..!!";
            return message;
        }

        public object SelectThetre()
        {
            List<ThetreModel> thetreList = _movieDbContext.thetreModels.ToList();
            return thetreList;
        }

        public string EditThetre(ThetreModel thetreModel)
        {
            _movieDbContext.Entry(thetreModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Thetre Details Update Successfully..!!";
        }

        public string DeleteThetre(int id)
        {
            ThetreModel foundThetre=_movieDbContext.thetreModels.Find(id);
            _movieDbContext.thetreModels.Remove(foundThetre);
            _movieDbContext.SaveChanges();
            return "Thetre Deleted Successfully..!!";
        }

        public object fetchThetreById(int id)
        {
            ThetreModel foundThetre=_movieDbContext.thetreModels.Find(id);
            if(foundThetre != null)
            {
                return foundThetre;
            }
            else
            {
                return "Sorry..Thetre Not Found..!!";
            }
        }
    }
}
