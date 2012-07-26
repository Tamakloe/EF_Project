using RateMyAmenity.DataImport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RateMyAmenity.Models;
using System.Collections.Generic;
using System.IO;

namespace RateMyTestProject
{
    
    
    /// <summary>
    ///This is a test class for IDataParserTest and is intended
    ///to contain all IDataParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDataParserTest
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


        internal virtual IDataParser CreateIDataParser()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDataParser target = null;
            return target;
        }

        /// <summary>
        ///A test for parseAmenity
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void parseAmenityTest()
        {
            IDataParser target = CreateIDataParser(); // TODO: Initialize to an appropriate value
            string amenitytype = string.Empty; // TODO: Initialize to an appropriate value
            List<Amenity> expected = null; // TODO: Initialize to an appropriate value
            List<Amenity> actual;
            actual = target.parseAmenity(amenitytype);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for parseParking
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void parseParkingTest()
        {
            IDataParser target = CreateIDataParser(); // TODO: Initialize to an appropriate value
            string parkingtype = string.Empty; // TODO: Initialize to an appropriate value
            List<Parking> expected = null; // TODO: Initialize to an appropriate value
            List<Parking> actual;
            actual = target.parseParking(parkingtype);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for setStreamSource
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void setStreamSourceTest()
        {
            IDataParser target = CreateIDataParser(); // TODO: Initialize to an appropriate value
            StreamReader reader = null; // TODO: Initialize to an appropriate value
            target.setStreamSource(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for supportsType
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Gerry\\Documents\\GitHub\\EF_Project\\RateMyAmenity2\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:50265/")]
        public void supportsTypeTest()
        {
            IDataParser target = CreateIDataParser(); // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.supportsType(format);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
