using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataObjects
{
    public class ClimbingRoute : AbstractRoute 
    {
        public Coordinate Base { get; set; }
    }
}
