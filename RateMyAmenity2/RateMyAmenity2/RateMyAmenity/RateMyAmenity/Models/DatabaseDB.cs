using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RateMyAmenity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace RateMyAmenity.Models 
{
    public class DatabaseDB : DbContext
    {
        /* public DbSet<User> Users { get; set; }  */
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }

     /*  code that stops DB names being created in the plural
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } */

}