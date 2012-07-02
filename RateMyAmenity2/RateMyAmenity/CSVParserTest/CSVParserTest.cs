using RateMyAmenity.DataImport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RateMyAmenity.Models;
using System.Collections.Generic;
using System.IO;

namespace CSVParserTest
{
    
    
    /// <summary>
    ///This is a test class for CSVParserTest and is intended
    ///to contain all CSVParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CSVParserTest
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
        ///A test for CSVParser Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\mcoffey\\EF_Project\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:57136/")]
        public void CSVParserConstructorTest()
        {
            CSVParser target = new CSVParser();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for RateMyAmenity.DataImport.IDataParser.parseAmenity
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\mcoffey\\EF_Project\\RateMyAmenity\\RateMyAmenity", "/")]
        [UrlToTest("http://localhost:57136/")]
        [DeploymentItem("RateMyAmenity.dll")]
        public void parseAmenityTest()
        {
            IDataParser target = new CSVParser(); // TODO: Initialize to an appropriate value
            List<Amenity> expected = null; // TODO: Initialize to an appropriate value
            List<Amenity> actual;
            actual = target.parseAmenity();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RateMyAmenity.DataImport.IDataParser.setStreamSource
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\mcoffey\\EF_Project\\RateMyAmenity\\RateMyAmenity", "/")]
        //[UrlToTest("http://localhost:57136/")]
        //[DeploymentItem("RateMyAmenity.dll")]
        public void setStreamSourceTest()
        {
            StreamReader reader = new StreamReader("C:\\Users\\mcoffey\\EF_Project\\RateMyAmenity\\RateMyAmenity\\Content\\ArtCentres.csv",true); // TODO: Initialize to an appropriate value
            
            IDataParser target = new CSVParser();

            target.setStreamSource(reader);

            Amenity a1 = new Amenity();
            a1.Name = "Draiocht";

           // List<Amenity> expected = new List<Amenity>();
            //expected.Add(a);

            List<Amenity> actual;
            actual = target.parseAmenity();
            Assert.AreEqual(4, actual.Count);

            Amenity amenity = actual.Find(item => item.Name = "Draiocht");
        }

        /// <summary>
        ///A test for RateMyAmenity.DataImport.IDataParser.supportsType
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void supportsTypeTest1()
        {
            IDataParser target = new CSVParser();   // test to check format = csv
            string format = "csv"; 
            bool expected = true; 
            bool actual;
            actual = target.supportsType(format);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void supportsTypeTest2()
        {
            IDataParser target = new CSVParser();  // test to check format for null (i.e. no file)
            string format = null; 
            bool expected = false; 
            bool actual;
            actual = target.supportsType(format);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void supportsTypeTest3()
        {
            IDataParser target = new CSVParser(); // test to check format = something other than csv
            string format = "noncsv"; 
            bool expected = false; 
            bool actual;
            actual = target.supportsType(format);
            Assert.AreEqual(expected, actual);
        }
    }
}
