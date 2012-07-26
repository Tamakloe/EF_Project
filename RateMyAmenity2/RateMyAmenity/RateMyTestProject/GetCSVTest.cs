using RateMyAmenity.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RateMyAmenity.Models;
using System.Collections.Generic;

namespace RateMyTestProject
{
    
    
    /// <summary>
    ///This is a test class for GetCSVTest and is intended
    ///to contain all GetCSVTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GetCSVTest
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
        ///A test for GetCSV Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void GetCSVConstructorTest()
        {
            GetCSV target = new GetCSV();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for SaveAmenity
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void SaveAmenityTest()
        {
            GetCSV target = new GetCSV(); // TODO: Initialize to an appropriate value
            List<Amenity> Amenities = null; // TODO: Initialize to an appropriate value
            target.SaveAmenity(Amenities);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveParking
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void SaveParkingTest()
        {
            GetCSV target = new GetCSV(); // TODO: Initialize to an appropriate value
            List<Parking> Parking = null; // TODO: Initialize to an appropriate value
            target.SaveParking(Parking);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
