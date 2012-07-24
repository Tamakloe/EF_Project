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
                       select new RatingAverage()
                       {
                           AmenityID = avgRating.Key,
                           RatingValue = avgRating.Average(r => r.RatingValue)

                       };
        return data;
        }


           //Get Parking Details based on long/lat of amenity

        public IQueryable GetParkingDetails(Double lat1, Double long1)
       // public IQueryable<IGrouping<String, ParkingDetails>> GetParkingDetails(Double lat1, Double lat2)
        {
             var data = (from parking in context.Parking
                        where parking.Latitude > lat1 - 0.0001 
                            && parking.Latitude < lat1 + 0.0001
                            || parking.Longitude > long1 - 0.0001
                            && parking.Longitude < long1 + 0.0001
                             // || parking.Latitude < lat1 - 0.0001

                        //  group parking by parking.AreaDesc into areaDesc
                        //where parking.TotalSpaces == "3"
                        //      group parking by parking.AreaDesc into areaDesc
                        //     select areaDesc.FirstOrDefault();
                        select new ParkingDetails()
                       {
                           RoadName = parking.RoadName,
                           NoSpaces = parking.TotalSpaces,
                           AreaDesc = parking.AreaDesc
                       }).Distinct();

                   //    }).GroupBy(p => p.AreaDesc);

            return data;
        }
    }
}


