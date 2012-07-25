using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RateMyAmenity.ViewModels;
using RateMyAmenity.Models;
using System.Collections;

namespace RateMyAmenity.Controllers
{

    public class RateAPIController : ApiController

    {
       // List<RateAPI> RateAPIs = new List<RateAPI>();
        ArrayList RateAPIs = new ArrayList();
        RateMyAmenityContext db = new RateMyAmenityContext();

        

        public void GetAPIData1()
        {
            
            IQueryable<RateAPI> api = from rating in db.Ratings select new RateAPI();
            RateAPIs.Add(api);   
        }


/*
        public IEnumerable<Rating> Get() { }
        
         //var RateAPIs = GetAPIData();

         IQueryable<RateAPI> RateAPIs = GetAPIData();
        

         public IQueryable GetAPIData()
         {
             var RateAPIs = from rating in db.Ratings select new RateAPI();
             return RateAPIs();

         }

/*
     RateAPI[] RateAPIs = new RateAPI[] 

    {

        new RateAPI { AmenityID = 1, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 2, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 3, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"},
        new RateAPI { AmenityID = 4, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 5, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 6, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"}
    };
        */


        public IEnumerable<RateAPI> GetAllRateAPIs()
        {
            return RateAPIs;
        }


        public RateAPI GetRateAPIByAmenityID(int id)
        {
           var RateAPI = RateAPIs.FirstOrDefault((r) => r.AmenityID == id);
            // Amenity amenity = db.Amenities.Find(id);

          //  Rating RateAPI = db.Ratings.FirstOrDefault((r) => r.AmenityID == id);
            
            if (RateAPI == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }

            return RateAPI;
        }


        public IEnumerable<RateAPI> GetRateAPIsByName(string name)
        {
            return RateAPIs.Where(
                (r) => string.Equals(r.Name, name,
                   StringComparison.OrdinalIgnoreCase));

        }
    }
}