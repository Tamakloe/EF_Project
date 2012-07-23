using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RateMyAmenity.Models;


namespace RateMyAmenity.DAL
{
    public class GetCSV : DropCreateDatabaseIfModelChanges<RateMyAmenityContext>
    {
       private RateMyAmenityContext context = new RateMyAmenityContext();

        public void SaveAmenity(List<Amenity> Amenities)
        {
            Amenities.ForEach(s => context.Amenities.Add(s)); 
            context.SaveChanges();
        }


        public void SaveParking(List<Parking> Parking)
        {
            Parking.ForEach(s => context.Parking.Add(s));
            context.SaveChanges();
        }
    }
           
}