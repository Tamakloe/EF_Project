using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RateMyAmenity.ViewModels;
<<<<<<< HEAD
using RateMyAmenity.Models;
using System.Collections;
=======
>>>>>>> 0ea982992d3acc32c88417af18ca378be4ed0910

namespace RateMyAmenity.Controllers
{

<<<<<<< HEAD
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
=======

    public class RateAPIController : ApiController
    {
        RateAPI[] RateAPIs = new RateAPI[] /*calling array*/
        {
/* need to connect to DB */
>>>>>>> 0ea982992d3acc32c88417af18ca378be4ed0910

        new RateAPI { AmenityID = 1, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 2, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 3, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"},
        new RateAPI { AmenityID = 4, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 5, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 6, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"}
    };
<<<<<<< HEAD
        */
=======



>>>>>>> 0ea982992d3acc32c88417af18ca378be4ed0910


        public IEnumerable<RateAPI> GetAllRateAPIs()
        {
            return RateAPIs;
        }
<<<<<<< HEAD


        public RateAPI GetRateAPIByAmenityID(int id)
        {
           var RateAPI = RateAPIs.FirstOrDefault((r) => r.AmenityID == id);
            // Amenity amenity = db.Amenities.Find(id);

          //  Rating RateAPI = db.Ratings.FirstOrDefault((r) => r.AmenityID == id);
            
=======
        public RateAPI GetRateAPIByAmenityID(int id)
        {
            var RateAPI = RateAPIs.FirstOrDefault((r) => r.AmenityID == id);
>>>>>>> 0ea982992d3acc32c88417af18ca378be4ed0910
            if (RateAPI == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }

            return RateAPI;
        }

<<<<<<< HEAD

=======
>>>>>>> 0ea982992d3acc32c88417af18ca378be4ed0910
        public IEnumerable<RateAPI> GetRateAPIsByName(string name)
        {
            return RateAPIs.Where(
                (r) => string.Equals(r.Name, name,
                   StringComparison.OrdinalIgnoreCase));

        }
    }
}