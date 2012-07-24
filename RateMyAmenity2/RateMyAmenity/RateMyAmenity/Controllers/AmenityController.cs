using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyAmenity.Models;
using RateMyAmenity.ViewModels;
using RateMyAmenity.DataImport;
using RateMyAmenity.DAL;
using RateMyAmenity.BLL;
using System.IO;

namespace RateMyAmenity.Controllers
{
    public class AmenityController : Controller
    {     
        private RateMyAmenityContext db = new RateMyAmenityContext();
        private AmenityDal amenitydal = new AmenityDal();

        //
        // GET: /Amenity/

        [Authorize(Roles = "admin")]
        public ActionResult List()
        {
            return View(db.Amenities.ToList());
        }


       // [Authorize(Roles = "admin")]
        public ActionResult CreateDB()
        {
            BLLGetCSV bllgetcsv = new BLLGetCSV();
            bllgetcsv.ImportCSV();
            return View("Index");
        }


        public ViewResult Index(string sortOrder, string searchString)
        {
          //  BLLSortFilterData bllsortfilterdata = new BLLSortFilterData();
            //var amenities = bllsortfilterdata.SortFilterData(sortOrder, searchString);


            ViewBag.DescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "Description desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
            ViewBag.Address4SortParm = sortOrder == "Address4" ? "Address4 desc" : "Address4";
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
                case "Description desc":
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

            
            return View(amenities.ToList());
        }


        //
        // GET: /Amenity/Details/5

        public ActionResult Details(int id = 0)
        {   
            Amenity amenity = db.Amenities.Find(id);
            if (amenity == null)
            {
                return HttpNotFound();
            }

            return View(amenity);
        }


        [ChildActionOnly]
        public ActionResult RatingDetails()
        {
            var data = amenitydal.GetAvgRating();

            return PartialView("_RatingDetails", data);
        }


        // GET: /Amenity/_ParkingDetails

       [ChildActionOnly]
        public ActionResult ParkingDetails(int id)
        {
            Amenity amenity = db.Amenities.Find(id); 
            
            var lat1 = amenity.Latitude;
            var long1 = amenity.Longitude;

            var data = amenitydal.GetParkingDetails(lat1, long1);

           return PartialView("_ParkingDetails", data);
        }


        //
        // GET: /Amenity/Create

        public ActionResult Create()
        {
           return View();
        }

        //
        // POST: /Amenity/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                db.Amenities.Add(amenity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amenity);
        }

        //
        // GET: /Amenity/Edit/5

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Amenity amenity = db.Amenities.Find(id);
            if (amenity == null)
            {
                return HttpNotFound();
            }
            return View(amenity);
        }

        //
        // POST: /Amenity/Edit/5

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amenity);
        }

        //
        // GET: /Amenity/Delete/5

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Amenity amenity = db.Amenities.Find(id);
            if (amenity == null)
            {
                return HttpNotFound();
            }
            return View(amenity);
        }

        //
        // POST: /Amenity/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Amenity amenity = db.Amenities.Find(id);
            db.Amenities.Remove(amenity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}