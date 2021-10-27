using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace HvorErBat.Models
{
    class Bus
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<Position> CoordinatesList { get; set; }
        public string Destination { get; set; }
        public string NextStop { get; set; }
        public int Icon { get; set; }
        public string DelayInMinutes { get; set; }
    }
}
