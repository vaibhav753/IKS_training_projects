using Microsoft.EntityFrameworkCore;
using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class User : IUser
    {
        MovieDbContext _moviedbContext;

        public User(MovieDbContext moviedbContext)
        {
            _moviedbContext = moviedbContext;
        }

        public string Delete(int id)
        {
            string message = "";
            var foundUser=_moviedbContext.userModel.Find(id);
            if(foundUser != null)
            {
                _moviedbContext.userModel.Remove(foundUser);
                _moviedbContext.SaveChanges();
                message = "User Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "User Not Found..!!";
                return message;
            }
        }

        public object Login(UserModel userModel)
        {
            UserModel validateduser = null;
            var foundUser =_moviedbContext.userModel.Where(u => u.Email.Equals(userModel.Email) && u.Password.Equals(userModel.Password)).ToList();
            if(foundUser.Count() > 0)
            {
                validateduser= foundUser[0];
                return validateduser;
            }
            else
            {
                return "User not Found..!!";
            }
        }

        public string Register(UserModel userModel)
        {
            string message = "";
            _moviedbContext.userModel.Add(userModel);
            _moviedbContext.SaveChanges();
            message = "Record inserted Successfully!!";
            return message;
        }

        public object SelectUser()
        {
            List<UserModel> list = _moviedbContext.userModel.ToList();
            return list;
        }

        public string Update(UserModel userModel)
        {
            _moviedbContext.Entry(userModel).State = EntityState.Modified;
            _moviedbContext.SaveChanges();
            return "Data Upddated";
        }

        public object findUserById(int id)
        {
            var foundUser = _moviedbContext.userModel.Find(id);
            if(foundUser!=null)
            {
                return foundUser;
            }
            else
            {
                return "User not Found..!!";
            }
        }
    }
}
