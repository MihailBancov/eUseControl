using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Models
{
    public class VehicleData
    {
        public string name { get; set; }
        public int price { get; set; }
        public int Power { get; set; }
        public int torque { get; set; }
        public int weight { get; set; }
        public string image { get; set; }

        public VehicleData()
        {
            name = null;
            price = 0;
            Power = 0;
            torque = 0;
            weight = 0;
            image = null;
        }
    }
}