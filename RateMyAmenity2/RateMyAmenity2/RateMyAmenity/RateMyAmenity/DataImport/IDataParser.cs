using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RateMyAmenity;
using System.IO;
using RateMyAmenity.Models;

namespace RateMyAmenity.DataImport
{
    interface IDataParser
    {
        List<Amenity> parseAmenity(String amenitytype);
        void setStreamSource(StreamReader reader);
        Boolean supportsType(String format);
    }
}
