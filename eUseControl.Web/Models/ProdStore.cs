﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities.Vehicle;
namespace eUseControl.Web.Models
{
    public class ProdStore
    {
        public List<ProdMin> Products { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedBrend { get; set; }
        public string SelectedTag { get; set; }
        public string SelectedName { get; set; }
        public int LowPrice { get; set; }
        public int HighPrice { get; set; }
        public string Sort { get; set; }
        public ProdStore()
        {
            Products = new List<ProdMin>();
        }
    }
}