using RateMyAmenity.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace RateMyTestProject
{


    /// <summary>
    ///This is a test class for SearchControllerTest and is intended
    ///to contain all SearchControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SearchControllerTest
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
        ///A test for SearchController Constructor
        [UrlToTest("http://localhost:50265/")]
        public void SearchControllerConstructor()
        {
            SearchController target = new SearchController(); // TODO: Initialize to an appropriate value
            float longitude = 0F; // TODO: Initialize to an appropriate value
            float latitude = 0F; // TODO: Initialize to an appropriate value
            ActionResult expected = target.SearchByLocation(longitude, latitude); // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SearchByLocation(longitude, latitude);
            Assert.AreEqual(longitude, latitude);
        }

        /// <summary>
        ///A test for SearchByLocation
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        [UrlToTest("http://localhost:50265/")]
        public void SearchByLocationTest()
        {
            SearchController target = new SearchController(); // TODO: Initialize to an appropriate value
            float longitude = 0F; // TODO: Initialize to an appropriate value
            float latitude = 0F; // TODO: Initialize to an appropriate value
            ActionResult expected = target.SearchByLocation(longitude, latitude); // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SearchByLocation(longitude, latitude);
            Assert.AreEqual(longitude, latitude);
        }
    }
}
//Failed	SearchByLocationTest	RateMyTestProject	Assert.AreEqual failed. Expected:<System.Web.Mvc.JsonResult>. Actual:<System.Web.Mvc.JsonResult>. 	