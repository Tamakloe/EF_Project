using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RateMyAmenity.ViewModels
{
    public class RateAPI
    {
        public int RatingID { get; set; }
        public int AmenityID { get; set; }
        public string Name { get; set; }
        public float RatingValue { get; set; }
        public string Comments { get; set; }
    }
}