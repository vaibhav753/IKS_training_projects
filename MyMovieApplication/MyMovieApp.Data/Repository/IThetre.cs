using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IThetre
    {
        string AddThetre(ThetreModel thetreModel);

        object SelectThetre();

        string EditThetre(ThetreModel thetreModel);

        string DeleteThetre(int id);

        object fetchThetreById(int id);
    }
}
