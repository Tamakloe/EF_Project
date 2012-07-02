using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyAmenity.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public float RatingValue { get; set; }
        public string Comments { get; set; }
        public string Image { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Amenity> Amenities { get; set; }

    }
}