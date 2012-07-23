using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyAmenity.Models;
using RateMyAmenity.Controllers;
using System.IO;


namespace RateMyAmenity.BLL
{
    public class BLLSortFilterData
    {
        private RateMyAmenityContext db = new RateMyAmenityContext();

        public IQueryable SortFilterData(string sortOrder, string searchString)
        {
         //   ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "Type desc" : "";
          //  ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
          //  ViewBag.Address4SortParm = sortOrder == "Address4" ? "Address4 desc" : "Address4";
            var amenities = from s in db.Amenities
                            select s;

            
            // search fields for search box on home page
            if (!String.IsNullOrEmpty(searchString))
            {
               amenities = amenities.Where(s => s.Description.ToUpper().Contains(searchString.ToUpper())
                                       || s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Address1.ToUpper().Contains(searchString.ToUpper())
                                       || s.Address2.ToUpper().Contains(searchString.ToUpper())
                                       || s.Address3.ToUpper().Contains(searchString.ToUpper())
                                       || s.Address4.ToUpper().Contains(searchString.ToUpper())
                                       || s.Phone.ToUpper().Contains(searchString.ToUpper())
                                       || s.Email.ToUpper().Contains(searchString.ToUpper())
                                       || s.Website.ToUpper().Contains(searchString.ToUpper()));
            }


            switch (sortOrder)
            {
                case "Type desc":
                    amenities = amenities.OrderByDescending(s => s.Description);
                    break;
                case "Name":
                    amenities = amenities.OrderBy(s => s.Name);
                    break;
                case "Address1 desc":
                    amenities = amenities.OrderBy(s => s.Address1);
                    break;
                case "Address2 desc":
                    amenities = amenities.OrderBy(s => s.Address2);
                    break;
                case "Address3 desc":
                    amenities = amenities.OrderBy(s => s.Address3);
                    break;
                case "Address4 desc":
                    amenities = amenities.OrderBy(s => s.Address4);
                    break;
                default:
                    amenities = amenities.OrderBy(s => s.Description);
                    break;
            }

            return amenities;
        }

    }
}