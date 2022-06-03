using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IUser
    {
        string Register(UserModel userModel);

        string Update(UserModel userModel);

        object Login(UserModel userModel);

        string Delete(int id);

        object SelectUser();

        public object findUserById(int id);
    }
}
