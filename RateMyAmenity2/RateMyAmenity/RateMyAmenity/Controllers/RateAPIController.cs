using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RateMyAmenity.ViewModels;

namespace RateMyAmenity.Controllers
{


    public class RateAPIController : ApiController
    {
        RateAPI[] RateAPIs = new RateAPI[] /*calling array*/
        {
/* need to connect to DB */

        new RateAPI { AmenityID = 1, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 2, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 3, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"},
        new RateAPI { AmenityID = 4, RatingID = 1,  Name = "Pub", RatingValue = 3, Comments = "la la la"},
        new RateAPI { AmenityID = 5, RatingID = 2,  Name = "Cinema", RatingValue = 2, Comments = "la la la"},
        new RateAPI { AmenityID = 6, RatingID = 3,  Name = "Toilet", RatingValue = 1, Comments = "la la la"}
    };





        public IEnumerable<RateAPI> GetAllRateAPIs()
        {
            return RateAPIs;
        }
        public RateAPI GetRateAPIByAmenityID(int id)
        {
            var RateAPI = RateAPIs.FirstOrDefault((r) => r.AmenityID == id);
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