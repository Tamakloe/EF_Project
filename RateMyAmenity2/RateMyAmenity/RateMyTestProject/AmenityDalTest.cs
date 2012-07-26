using RateMyAmenity.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Linq;

namespace RateMyTestProject
{
    
    
    /// <summary>
    ///This is a test class for AmenityDalTest and is intended
    ///to contain all AmenityDalTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AmenityDalTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AmenityDal Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void AmenityDalConstructorTest()
        {
            AmenityDal target = new AmenityDal();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAvgRating
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void GetAvgRatingTest()
        {
            AmenityDal target = new AmenityDal(); // TODO: Initialize to an appropriate value
            IQueryable expected = null; // TODO: Initialize to an appropriate value
            IQueryable actual;
            actual = target.GetAvgRating();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetParkingDetails
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void GetParkingDetailsTest()
        {
            AmenityDal target = new AmenityDal(); // TODO: Initialize to an appropriate value
            double lat1 = 0F; // TODO: Initialize to an appropriate value
            double long1 = 0F; // TODO: Initialize to an appropriate value
            IQueryable expected = null; // TODO: Initialize to an appropriate value
            IQueryable actual;
            actual = target.GetParkingDetails(lat1, long1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
