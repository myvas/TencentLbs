using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Myvas.AspNetCore.TencentLbs
{
    public class Location
    {
        public Location() { }
        public Location(decimal longitude, decimal latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public Location(double longitude, double latitude)
        {
            Latitude = (decimal)latitude;
            Longitude = (decimal)longitude;
        }

        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("lng")]
        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return $"Location: ({Latitude}, {Longitude})";
        }
    }
}
