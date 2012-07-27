using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RateMyAmenity.Models;
using RateMyAmenity.ViewModels;
using RateMyAmenity.DAL;


namespace RateMyAmenity.Controllers
{

    public class RateAPIController : ApiController
    {
        private RateMyAmenityContext db = new RateMyAmenityContext();
        private AmenityDal amenitydal = new AmenityDal();

        private IQueryable<RateAPI> RateAPIs()
        {
            return from a in db.Ratings
                   select new RateAPI() { AmenityID = a.AmenityID, RatingID = a.RatingID, Comments = a.Comments };
        }


        public IEnumerable<RateAPI> GetAllRateAPIs()
        {
            return RateAPIs();
        }
        public RateAPI GetRateAPIByAmenityID(int id)
        {
            var RateAPI = RateAPIs().FirstOrDefault((r) => r.AmenityID == id);
            if (RateAPI == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }

            return RateAPI;
        }

        public IEnumerable<RateAPI> GetRateAPIsByName(string name)
        {
            return RateAPIs().Where(
                (r) => string.Equals(r.Name, name,
                   StringComparison.OrdinalIgnoreCase));

        }
    }
}