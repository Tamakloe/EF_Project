using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyAmenity.Models
{
    public class Parking
    {
        public int ParkingID { get; set; }
        public string Description { get; set; }
        public string AreaDesc { get; set; }
        public string RoadName { get; set; }
        public string TotalSpaces { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}