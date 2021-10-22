using System;
using System.Collections.Generic;
using System.Text;

namespace HvorErBat.Models
{
    class Bus
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string CoordinatesList { get; set; }
        public string Destination { get; set; }
        public string NextStop { get; set; }
        public string Icon { get; set; }
        public string DelayInMinutes { get; set; }
    }
}
