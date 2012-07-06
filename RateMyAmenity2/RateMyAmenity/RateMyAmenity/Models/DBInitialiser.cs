using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RateMyAmenity.Models;
using RateMyAmenity.DataImport;
using System.IO;
using System.Net;

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


            // Add uri and type for each amenity to a multidimensional array.
            string[,] amenities = new string[,] { 
            
                {"http://data.fingal.ie/datasets/csv/Arts_Centres.csv", "Art Centres" },  
                {"http://data.fingal.ie/datasets/csv/Cinemas.csv", "Cinemas" }, 
                {"http://data.fingal.ie/datasets/csv/Heritage_Venues.csv", "Heritage Venues"},
                {"http://data.fingal.ie/datasets/csv/Parks.csv", "Parks" },
                { "http://data.fingal.ie/datasets/csv/Play_Areas.csv", "Play Areas" }
            };

            //  loop through each amenity, parse using the csvparser & add to the DB.
            for (int i = 0; i < amenities.Length /2 ; i++)
            {
                IDataParser ourcsv = new CSVParser();

                //  code to fetch the csv from a URI instead of locally.  uses system.net.
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(amenities[i, 0]);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                Stream st = rspFP.GetResponseStream();


                StreamReader tmp = new StreamReader(st);
                ourcsv.setStreamSource(tmp);

                // pass the amenity type to parseAmenity
                var Amenities = ourcsv.parseAmenity(amenities[i, 1]);

                //  Add and save data to the DB.
                Amenities.ForEach(s => context.Amenities.Add(s));
                context.SaveChanges();

            }

        }
    }
}