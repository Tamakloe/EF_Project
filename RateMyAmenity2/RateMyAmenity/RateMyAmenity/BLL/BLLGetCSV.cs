using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyAmenity.DAL;
using RateMyAmenity.DataImport;
using RateMyAmenity.Models;
using System.Data.Entity;
using System.IO;
using System.Net;

// BLL class to create the amenity and parking DB from external CSV data

namespace RateMyAmenity.BLL
{
    public class BLLGetCSV
    {
        private GetCSV getcsv = new GetCSV();

        public void ImportCSV()
        {
            CreateAmenityDB();
            CreateParkingDB();
        }

        public void CreateAmenityDB()
        {
            // Add uri and type for each amenity to a multidimensional array.
            string[,] amenities = new string[,] { 
            
                {"http://data.fingal.ie/datasets/csv/Arts_Centres.csv", "Art Centres" },  
                {"http://data.fingal.ie/datasets/csv/Cinemas.csv", "Cinemas" }, 
                {"http://data.fingal.ie/datasets/csv/Heritage_Venues.csv", "Heritage Venues"},
                {"http://data.fingal.ie/datasets/csv/Parks.csv", "Parks" },
                { "http://data.fingal.ie/datasets/csv/Play_Areas.csv", "Play Areas" }
            };

            //  loop through each amenity, parse using the csvparser & add to the DB.
            for (int i = 0; i < amenities.Length / 2; i++)
            {
                IDataParser ourcsv = new CSVParser();

                //  code to fetch the csv from a URI instead of locally.  uses system.net.
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(amenities[i, 0]);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                // Stream st = rspFP.GetResponseStream();


                StreamReader tmp = new StreamReader(rspFP.GetResponseStream());
                ourcsv.setStreamSource(tmp);

                // pass the amenity type to parseAmenity
                var Amenities = ourcsv.parseAmenity(amenities[i, 1]);


                //  save data to the DB.
                getcsv.SaveAmenity(Amenities);

            }
        }

        public void CreateParkingDB()
        {
            // Add uri and type for each parking to a multidimensional array.
            string[,] parking = new string[,] { 
            
                {"http://data.fingal.ie/datasets/csv/Disabled_Parking.csv", "Disabled Parking" },  
            };

            //  loop through each amenity, parse using the csvparser & add to the DB.
            for (int i = 0; i < parking.Length / 2; i++)
            {
                IDataParser ourcsv = new CSVParser();

                //  code to fetch the csv from a URI instead of locally.  uses system.net.
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(parking[i, 0]);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                // Stream st = rspFP.GetResponseStream();


                StreamReader tmp = new StreamReader(rspFP.GetResponseStream());
                ourcsv.setStreamSource(tmp);

                // pass the parkingtype to parseParking
                var Parking = ourcsv.parseParking(parking[i, 1]);

                //  save data to the DB.
                getcsv.SaveParking(Parking);  

            }
        }
    }

}

