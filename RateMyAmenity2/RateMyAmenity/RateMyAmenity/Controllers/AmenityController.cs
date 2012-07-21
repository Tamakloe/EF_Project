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

        //
        // GET: /Amenity/

        public ActionResult List()
        {
            return View(db.Amenities.ToList());
        }

        public ActionResult CreateDB()
        {
            BLLGetCSV bllgetcsv = new BLLGetCSV();
            bllgetcsv.CreateAmenityDB();
            return View("Index");
        }


        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "Type desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
            ViewBag.Address4SortParm = sortOrder == "Address4" ? "Address4 desc" : "Address4";
            var amenities = from s in db.Amenities
                           select s;

            
            // search fields for search box on home page
            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(s => s.Type.ToUpper().Contains(searchString.ToUpper())
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
                    amenities = amenities.OrderByDescending(s => s.Type);
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
                    amenities = amenities.OrderBy(s => s.Type);
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
     //       return View(data);
        }


        [ChildActionOnly]
        public ActionResult RatingDetails()
        {
            // Get Rating Value Average
            var data = from rating in db.Ratings      
                       group rating by rating.AmenityID into avgRating
                       select new RatingAverage()
                       {
                           AmenityID = avgRating.Key,
                           RatingValue = avgRating.Average(r => r.RatingValue)

                       };

            return PartialView("_RatingDetails", data);
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