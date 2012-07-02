using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RateMyAmenity.Models;

namespace RateMyAmenity.Models
{
    public class DBInitialiser : DropCreateDatabaseIfModelChanges<DatabaseDB>
    {
        protected override void Seed(DatabaseDB context)
        {
            var Users = new List<User>
            {
                new User { UserName = "Carson",   Email = "Alexander.com", Password = "12345" },
                new User { UserName = "Meredith", Email = "Alonso.com",    Password = "12345" },
                new User { UserName = "Arturo",   Email = "Anand.com",     Password = "12345" },
                new User { UserName = "Gytis",    Email = "Barzdukas.com", Password = "12345" },
                new User { UserName = "Yan",      Email = "Li.com",        Password = "12345" },
                new User { UserName = "Peggy",    Email = "Justice.com",   Password = "12345" },
                new User { UserName = "Laura",    Email = "Norman.com",    Password = "12345" },
                new User { UserName = "Nino",     Email = "Olivetto.com",  Password = "12345" }
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var Rating = new List<Rating>
            {
                new Rating { RatingValue = 3, Comments = "Chemistry",      Image = "image.jpg" },
                new Rating { RatingValue = 3, Comments = "Microeconomics", Image = "image.jpg" },
                new Rating { RatingValue = 3, Comments = "Macroeconomics", Image = "image.jpg" },
                new Rating { RatingValue = 4, Comments = "Calculus",       Image = "image.jpg" },
                new Rating { RatingValue = 4, Comments = "Trigonometry",   Image = "image.jpg" },
                new Rating { RatingValue = 3, Comments = "Composition",    Image = "image.jpg" },
                new Rating { RatingValue = 4, Comments = "Literature",     Image = "image.jpg" }
            };
            Rating.ForEach(s => context.Ratings.Add(s));
            context.SaveChanges();

            var Amenities = new List<Amenity>
            {
                new Amenity { Type = "park" , Name = "Johnstown", Address1 = "Johnstown Road", Address2 = "Finglas", Address3 = "Dublin 11" , Address4 = "", Phone = "12345", Email = "park@gmail.com", Website = "www.park.com", Lat = 34.23, Long = 23, DefaultImage = "image.jpg"},
                new Amenity { Type = "park" , Name = "Johnstown", Address1 = "Johnstown Road", Address2 = "Finglas", Address3 = "Dublin 11" , Address4 = "", Phone = "12345", Email = "park@gmail.com", Website = "www.park.com", Lat = 34, Long = 25, DefaultImage = "image.jpg"},
                new Amenity { Type = "park" , Name = "Johnstown", Address1 = "Johnstown Road", Address2 = "Finglas", Address3 = "Dublin 11" , Address4 = "", Phone = "12345", Email = "park@gmail.com", Website = "www.park.com", Lat = 34, Long = 28, DefaultImage = "image.jpg"},
                new Amenity { Type = "park" , Name = "Johnstown", Address1 = "Johnstown Road", Address2 = "Finglas", Address3 = "Dublin 11" , Address4 = "", Phone = "12345", Email = "park@gmail.com", Website = "www.park.com", Lat = 34, Long = 23, DefaultImage = "image.jpg"},
                new Amenity { Type = "park" , Name = "Johnstown", Address1 = "Johnstown Road", Address2 = "Finglas", Address3 = "Dublin 11" , Address4 = "", Phone = "12345", Email = "park@gmail.com", Website = "www.park.com", Lat = 34, Long = 23, DefaultImage = "image.jpg"},
            };
            Amenities.ForEach(s => context.Amenities.Add(s));
            context.SaveChanges();
        }
    }
}