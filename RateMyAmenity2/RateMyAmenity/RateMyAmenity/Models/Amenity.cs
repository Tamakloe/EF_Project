using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateMyAmenity.Models
{
    public class Amenity
    {
        public int AmenityID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public double Latitude { get; set; }
<<<<<<< HEAD
        public double Longtitude { get; set; }
=======
        public double Longitude { get; set; }
>>>>>>> da9d7126f6476305b3ff206c4be1baef7b3fb321
        public string DefaultImage { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

              [UIHint("LocationDetail")] 
        [NotMapped] 
        public LocationDetail Location 
        { 
            get 
            { 
                return new LocationDetail() { Latitude = this.Latitude, Longitude = this.Longitude, Description = this.Description, Name = this.Name }; 
            } 
            set 
            { 
                this.Latitude = value.Latitude; 
                this.Longitude = value.Longitude; 
                this.Description = value.Description; 
                this.Name = value.Name; 
            } 
        } 
    } 
 
    public class LocationDetail 
    { 
        public double Latitude; 
        public double Longitude; 
        public string Description; 
        public string Name; 
    } 
    }
