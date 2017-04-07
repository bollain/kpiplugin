using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDentBusiness;
using System.Data;
using KPIReporting.KPI;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class NonProductivePracticeTimeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\nonproductivepracticetime.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }

        [TestMethod]
        public void GetTotalNonProductivePracticeTime()
        {
            var startDate = new DateTime(2014, 3, 20);
            var endDate = new DateTime(2017, 3, 20);
            List<object> testData = KPIReporting.KPI.KPINonProductivePracticeTime.GetNonProductivePracticeTime(startDate, endDate);
            DataTable test = (DataTable)testData[0];
            Assert.IsNotNull(test);
            Assert.AreEqual(3, test.Rows.Count);
        }
    }
}
