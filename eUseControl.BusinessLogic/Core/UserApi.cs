using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using AutoMapper;
using BusinessLogic.DBModel;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Car;
using eUseControl.Domain.Entities.Review;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.BusinessLogic
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {

            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))              //Если email валидный, то сравнить с u.Email else сравнить с u.Username
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);    //Берем u, где u.Email==data.Credential
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }

            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
        }
        internal ULoginResp UserRegistrationAction(ULoginData data)
        {
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))      //Если email валидный, то сравнить с u.Email else сравнить с u.Username
            {
                if (data.Name == null || data.Password == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }
                if (data.Name.Length > 5 && data.Password.Length > 8)
                {
                    var pass = LoginHelper.HashGen(data.Password);
                    UDbTable result = new UDbTable
                    {
                        Username = data.Name,
                        Email = data.Credential,
                        Password = pass,
                        LasIp = data.LoginIp,
                        LastLogin = data.LoginDateTime,
                        Level = URole.User,
                    };
                    using (var db = new UserContext())
                    {
                        db.Users.Add(result);    //добавляем запись в базу данных 
                        db.SaveChanges();
                    }
                    return new ULoginResp { Status = true };
                }
            }
            return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
        }
        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = db.Sessions.FirstOrDefault(e => e.Username == loginCredential);
                }
                else
                {
                    curent = db.Sessions.FirstOrDefault(e => e.Username == loginCredential);
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }
        internal List<Car> Car()
        {
            List<Car> result = new List<Car>();
            using (var db = new CarContext())
            {
                var cars = db.Cars;
                foreach (var c in cars)
                {
                    result.Add(c);
                }
            }
            return result;
        }
        internal List<UserReview> Review()
        {
            List<UserReview> result = new List<UserReview>();
            using (var db = new ReviewContext())
            {
                var reviews = db.CustomerReviews;
                foreach (var r in reviews)
                {
                    result.Add(r);
                }
            }
            return result;
        }
        internal void NewReview(UserReview review)
        {
            if (review.Name != null && review.Message != null)
            {
                using (var db = new ReviewContext())
                {
                    db.CustomerReviews.Add(review);    //добавляем запись в базу данных 
                    db.SaveChanges();
                }
            }
        }
    }
}
