using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RateMyAmenity.ViewModels
{
    public class RatingDetails
    {
        public float RatingValue { get; set; }
        public int AmenityID { get; set; }
    }
}