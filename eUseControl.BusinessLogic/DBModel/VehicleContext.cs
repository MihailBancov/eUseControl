using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Car;

namespace eUseControl.BusinessLogic.DBModel
{
    public class CarContext : DbContext
    {
        public CarContext() : base("name=eUseControl")
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
