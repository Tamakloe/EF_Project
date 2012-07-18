using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RateMyAmenity.ViewModels
{
    public class RatingAverage
    {
        public float RatingValue { get; set; }
        public int AmenityID { get; set; }
    }
}