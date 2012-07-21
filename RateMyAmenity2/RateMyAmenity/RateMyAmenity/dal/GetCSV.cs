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

        public void Save(List<Amenity> Amenities)
        {
            Amenities.ForEach(s => context.Amenities.Add(s)); 
            context.SaveChanges();
        }
    }
           
}