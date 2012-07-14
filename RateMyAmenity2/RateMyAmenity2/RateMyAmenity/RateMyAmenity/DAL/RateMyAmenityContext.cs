using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RateMyAmenity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RateMyAmenity.Models
{
    public class RateMyAmenityContext : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
