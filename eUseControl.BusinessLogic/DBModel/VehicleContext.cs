using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Vehicle;

namespace eUseControl.BusinessLogic.DBModel
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("name=eUseControl")
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
