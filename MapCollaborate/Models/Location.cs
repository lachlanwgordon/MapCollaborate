using System;


namespace MapCollaborate.Models
{
    public struct Location
    {

        public Location(double lat, double lon) : this()
        {
            Latitude = lat;
            Longitude = lon;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}