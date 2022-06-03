using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class ThetreService
    {
        IThetre _iThetre;

        public ThetreService(IThetre iThetre)
        {
            _iThetre = iThetre;
        }

        public string AddThetre(ThetreModel thetreModel)
        {
            return _iThetre.AddThetre(thetreModel);

        }

        public Object SelectThetre()
        {
            return _iThetre.SelectThetre();
        }

        public string EditThetre(ThetreModel thetreModel)
        {
            return _iThetre.EditThetre(thetreModel);
        }

        public string DeleteThetre(int id)
        {
            return _iThetre.DeleteThetre(id);
        }

        public object FetchThetreById(int id)
        {
            return _iThetre.fetchThetreById(id);
        }
    }
}
