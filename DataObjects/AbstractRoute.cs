using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public abstract class AbstractRoute
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
