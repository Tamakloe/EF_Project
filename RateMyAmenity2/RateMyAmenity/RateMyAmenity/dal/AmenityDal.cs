using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyAmenity.Models;
using RateMyAmenity.ViewModels;


namespace RateMyAmenity.DAL
{
    public class AmenityDal
    {
        private RateMyAmenityContext context = new RateMyAmenityContext();

        public IQueryable GetAvgRating()
        {
            //Get Rating Value Average
            
            var data = from rating in context.Ratings 
                       group rating by rating.AmenityID into avgRating
                       select new RatingDetails()
                       {
                           AmenityID = avgRating.Key,
                           RatingValue = avgRating.Average(r => r.RatingValue)
                       };
        return data;
        }


           //Get Parking Details based on long/lat of amenity

        public IQueryable GetParkingDetails(Double lat1, Double long1)
        {
             var data = (from parking in context.Parking
                        where parking.Latitude > lat1 - 0.0001 
                            && parking.Latitude < lat1 + 0.0001
                            || parking.Longitude > long1 - 0.0001
                            && parking.Longitude < long1 + 0.0001
                        select new ParkingDetails()
                       {
                           RoadName = parking.RoadName,
                           NoSpaces = parking.TotalSpaces,
                           AreaDesc = parking.AreaDesc
                       }).Distinct();

            return data;
        }
    }
}


