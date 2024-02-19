using NUnit.Framework;
using WinExifTool.Utils;

namespace TestWinExifTool
{
    public class TestGPSPoint
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestParseGPS()
        {
            TestParseGPSPoint(GPSPoint.Parse("40.892433 N, 73.982871 E"), 40.8924, 73.9828);
            TestParseGPSPoint(GPSPoint.Parse("40.89243352315631, 73.98287154503505"), 40.8924, 73.9828);
            TestParseGPSPoint(GPSPoint.Parse("40°53'32.6\"N 73°58'58.4\"E"), 40.8924, 73.9828);

            TestParseGPSPoint(GPSPoint.Parse("40.892433 N, 73.982871 W"), 40.8924, -73.9828);
            TestParseGPSPoint(GPSPoint.Parse("40.89243352315631, -73.98287154503505"), 40.8924, -73.9828);
            TestParseGPSPoint(GPSPoint.Parse("40°53'32.6\"N 73°58'58.4\"W"), 40.8924, -73.9828);

            TestParseGPSPoint(GPSPoint.Parse("40.892433 S, 73.982871 E"), -40.8924, 73.9828);
            TestParseGPSPoint(GPSPoint.Parse("-40.89243352315631, 73.98287154503505"), -40.8924, 73.9828);
            TestParseGPSPoint(GPSPoint.Parse("40°53'32.6\"S 73°58'58.4\"E"), -40.8924, 73.9828);

            Assert.Pass();
        }

        public void TestParseGPSPoint(GPSPoint p, double Lat, double Lng)
        {
            Assert.IsFalse(p.State != GPSPoint.PointState.Empty, "B³¹d parsowania");
            Assert.AreEqual(p.Lat, Lat, 0.001);
            //Assert.GreaterOrEqual(p.Lat, Lat - 0.0001);
            //Assert.LessOrEqual(p.Lat, Lat + 0.0001);
            Assert.AreEqual(p.Lng, Lng, 0.001);
            //Assert.GreaterOrEqual(p.Lng, Lng - 0.0001);
            //Assert.LessOrEqual(p.Lng, Lng + 0.0001);

            if (Lat >= 0)
            {
                Assert.AreEqual(p.LatRef, "North");
            }
            else
            {
                Assert.AreEqual(p.LatRef, "South");
            }

            if (Lng >= 0)
            {
                Assert.AreEqual(p.LngRef, "East");
            }
            else
            {
                Assert.AreEqual(p.LngRef, "West");
            }
        }
    }
}