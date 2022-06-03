using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;

        public UserService(IUser iuser)
        {
            _iuser = iuser;
        }

        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel); 
        }

        public object selectUser()
        {
            return _iuser.SelectUser();
        }

        public string deleteUser(int id)
        {
            return _iuser.Delete(id);
        }

        public object Login(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }

        public object findUserById(int id)
        {
            return _iuser.findUserById(id);
        }

        public string EditUser(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }
    }
}
