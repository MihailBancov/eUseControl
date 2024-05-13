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
using eUseControl.Domain.Entities.Vehicle;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi
    {
        internal ULoginResp AddNewCar(Vehicle car)
        {
            if (car.Name == null && car.Price == 0 && car.Power == 0 && car.Torque == 0 && car.Weight == 0)
            {
                return new ULoginResp { Status = false, StatusMsg = "Not all fields are filled out correctly!" };
            }

            using (var db = new VehicleContext())
            {
                db.Vehicles.Add(car);    //добавляем запись в базу данных 
                db.SaveChanges();
            }
            return new ULoginResp { Status = true };
        }

        internal void DeleteCurrentCar(string carName)
        {
            using (var db = new VehicleContext())
            {
                var deleteCar = db.Vehicles.FirstOrDefault(car => car.Name == carName);
                if (deleteCar != null)
                {
                    db.Vehicles.Remove(deleteCar);
                    db.SaveChanges();
                }
            }
        }
        internal void DeleteCurrentReview(string mewssage)
        {
            using (var db = new ReviewContext())
            {
                var deleteReview = db.CustomerReviews.FirstOrDefault(review => review.Message == mewssage);
                if (deleteReview != null)
                {
                    db.CustomerReviews.Remove(deleteReview);
                    db.SaveChanges();
                }
            }
        }
    }
}
