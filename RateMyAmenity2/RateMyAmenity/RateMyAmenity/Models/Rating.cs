using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyAmenity.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int AmenityID { get; set; }
        public int UserID { get; set; }
        public float RatingValue { get; set; }
        public string Comments { get; set; }
        public string Image { get; set; }
        public virtual User User { get; set; }
        public virtual Amenity Amenity { get; set; }

    }
}