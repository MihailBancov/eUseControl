using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Models
{
    public class VehiclesData
    {
        public List<VehicleData> vehicles;

        public VehiclesData()
        {
            vehicles = new List<VehicleData>();
        }
    }
}