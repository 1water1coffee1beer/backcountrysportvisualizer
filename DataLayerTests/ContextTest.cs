using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayerTests
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void TestContext()
        {
            using (RouteContext context = new RouteContext())
            {
                List<Coordinate> list = new List<Coordinate>();
                list.Add(new Coordinate { Elevation = 1646.62f, Latitude = 40.211386f, Longitude = -105.272751f, Timestamp = DateTime.Now });
                list.Add(new Coordinate { Elevation = 1647.29f, Latitude = 40.211626f, Longitude = -105.271718f, Timestamp = DateTime.Now });
                list.Add(new Coordinate { Elevation = 1648.56f, Latitude = 40.211749f, Longitude = -105.270478f, Timestamp = DateTime.Now });
                list.Add(new Coordinate { Elevation = 1650.48f, Latitude = 40.211681f, Longitude = -105.269346f, Timestamp = DateTime.Now });
                list.Add(new Coordinate { Elevation = 1652.93f, Latitude = 40.211283f, Longitude = -105.267828f, Timestamp = DateTime.Now });
                
                context.SkiTrours.Add(new SkiRoute { Name = "test route", Route = list, URL = "www.test.com" });

                context.SaveChanges();

                Task<SkiRoute> task = context.SkiTrours.FirstOrDefaultAsync();
                
                Assert.IsNotNull(task);
            }
        }
    }
}
