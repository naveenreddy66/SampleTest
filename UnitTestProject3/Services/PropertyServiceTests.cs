using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTest.Models;
using SampleTest.Services;
using System.Xml;

namespace UnitTestProject3
{
    [TestClass]
    public class PropertyServiceTests
    {
      
        public TestContext TestContext { get; set; }
        private const string XML_PROVIDER = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        //Inside XML\TestData.xml, for every CanBuyHouse node, create the appropriate child nodes to satisfy the expected results (one positive and one negative test)
        //  [DataSource(XML_PROVIDER, @"|DataDirectory|\Xml\TestData.xml", "CanBuyHouse", DataAccessMethod.Sequential)]
        [DataSource("MyXMLDataSource")]
        [TestMethod]
        public void CanBuyHouse()
        {
            //Arrange
            //Get the expected results, input country, and properties country from the XML
            var country = TestContext.DataRow["Country"].ToString();
            var expected = TestContext.DataRow["ExpectedResults"].ToString(); ;//Get the data from the XML
            Property prop = new Property
            {
                Country = TestContext.DataRow["Property"].ToString()
            };

            //act
            PropertyService propertyService = new PropertyService();
            var actual = propertyService.CanBuyHouse(prop, country);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
