using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using RateMyAmenity.Models;


namespace RateMyAmenity.DataImport
{
    public class CSVParser :IDataParser
    {

        private String supportedFormat = "csv";
        private StreamReader reader;

        List<Models.Amenity> IDataParser.parseAmenity()
        {
            CsvReader csv = new CsvReader(reader, true);
            int fieldCount = csv.FieldCount;

            List<Amenity> facility = new List<Amenity>();

            String[] headers = csv.GetFieldHeaders();

            while (csv.ReadNextRecord())
            {
                Amenity exObj = new Amenity();

                for (int i = 0; i < fieldCount; i++)
                { // need to make this more robust for non expected values
                    if (headers[i].Equals("Name")) {
                        exObj.Name = csv[i];
                    } else if (headers[i].Equals("Address1")) {
                        exObj.Address1 = csv[i];
                    } else if (headers[i].Equals("Address2")) {
                        exObj.Address2 = csv[i]; 
                    } else if (headers[i].Equals("Address3")) {
                        exObj.Address3 = csv[i];
                    } else if (headers[i].Equals("Address4")) {
                        exObj.Address4 = csv[i];
                    } else if (headers[i].Equals("Phone")) {
                        exObj.Phone = csv[i];
                    } else if (headers[i].Equals("Email")) {
                        exObj.Email = csv[i];
                    } else if (headers[i].Equals("Website")) {
                        exObj.Website = csv[i];
                    } else if (headers[i].Equals("Lat")) {
                        exObj.Lat = Convert.ToDouble(csv[i]);
                    } else if (headers[i].Equals("Long")) {
                        exObj.Long = Convert.ToDouble(csv[i]);
                    }
                }
                facility.Add(exObj);
                
            }
            return facility;

        }

        void IDataParser.setStreamSource(StreamReader reader)
        //void IDataParser.setStreamSource(String MyCsv)    
        {
            this.reader = reader;

        }

        bool IDataParser.supportsType(string format)
        {
            if (format == null)  // Checks for null
            {
                return false;
            }

            if (format.Equals(supportedFormat)) {
                return true;
            }
            return false;
        }

      
    }
}