using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataObjects
{
    public class RouteContext : DbContext
    {
        public DbSet<ClimbingRoute> Climbs { get; set; }
        public DbSet<MtbRoute> TrailRides { get; set; }
        public DbSet<SkiRoute> SkiTrours { get; set; }
        public DbSet<HikeRoute> Hikes { get; set; }
        public DbSet<TrailRunRoute> TrailRuns { get; set; }
        
        public DbSet<Coordinate> Points { get; set; }   //TODO idunno if we really need this
    }
}
