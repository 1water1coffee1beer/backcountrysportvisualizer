using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class MtbRoute : AbstractRoute
    {
        public List<Coordinate> Route { get; set; }
    }
}
