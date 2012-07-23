using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyAmenity.Models;

namespace RateMyAmenity.Controllers
{
    public class JsonAmenity
    {
        public int AmenityID { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }

    public class SearchController : Controller
    {
        private RateMyAmenityContext db = new RateMyAmenityContext();

        //
        // AJAX: /Search/SearchByLocation

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult SearchByLocation(float longitude, float latitude)
        {
            var amenities = db.Amenities.ToList();
            var jsonPlaces = from place in amenities
                              select new JsonAmenity
                              {
                                  AmenityID = place.AmenityID,
                                  Latitude = place.Latitude,
                                  Longitude = place.Longitude,
                                  Name = place.Name,
                                  Description = place.Description,
                                  Phone = place.Phone
                              };

            return Json(jsonPlaces.ToList());
        }

    }
}