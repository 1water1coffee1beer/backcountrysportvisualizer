using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Coordinate
    {
        [Key]
        public long CoordinateId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
