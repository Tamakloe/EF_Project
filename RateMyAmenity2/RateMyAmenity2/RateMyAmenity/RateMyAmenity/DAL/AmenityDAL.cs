using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyAmenity.Models;
using System.Configuration;

namespace RateMyAmenity.dal
{
    public class AmenityDAL
    {
        protected DatabaseDB db = new DatabaseDB();
        public AmenityDAL()
        {
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                Console.WriteLine();
                System.Diagnostics.Debug.WriteLine("Using ConnectionStrings property.");

                // Get connection strings
                foreach (ConnectionStringSettings connection in
                    connections)
                {
                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;

                    System.Diagnostics.Debug.WriteLine("Name:   {0}",
                        name);
                    System.Diagnostics.Debug.WriteLine("Connection string:   {0}",
                        connectionString);
                    System.Diagnostics.Debug.WriteLine("Provider:   {0}",
                        provider);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No Connection String is defined.");
            }
        }
        public Amenity findAmenityType(String Name, String Type)
        {
            List<Amenity> type = null;
            type = db.Amenities.ToList();

            foreach (Amenity t in type)
            {
                if (t.Address1.Equals(Name) && t.Address2.Equals(Type))
                {

                    return t;
                }

            }
            return null;
        }
        public Amenity findAmenityById(int id)
        {
            return null;
        }
    }
}
     /*    public Amenity addAmenity(Amenity Type)
         {
             return null;
         }
     }
 }
        */