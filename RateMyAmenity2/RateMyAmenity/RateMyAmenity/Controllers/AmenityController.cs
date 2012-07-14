using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyAmenity.Models;
using RateMyAmenity.DataImport;
using System.IO;

namespace RateMyAmenity.Controllers
{
    public class AmenityController : Controller
    {
        private DatabaseDB db = new DatabaseDB();

        //
        // GET: /Amenity/

   //     public ActionResult Index()
   //     {
   //         return View(db.Amenities.ToList());
   //     }


        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "Type desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
            var amenities = from s in db.Amenities
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(s => s.Type.ToUpper().Contains(searchString.ToUpper())
                                       || s.Name.ToUpper().Contains(searchString.ToUpper()));
            }


            switch (sortOrder)
            {
                case "Type desc":
                    amenities = amenities.OrderByDescending(s => s.Type);
                    break;
                case "Name":
                    amenities = amenities.OrderBy(s => s.Name);
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
        }

        //
        // GET: /Amenity/Create

        public ActionResult Create()
        {
        //    IDataParser ourcsv = new CSVParser();
          //  StreamReader tmp = new StreamReader("C:\\Users\\mcoffey\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\Content\\ArtCentres.csv");
          //  ourcsv.setStreamSource(tmp);
           // ourcsv.parseAmenity();
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