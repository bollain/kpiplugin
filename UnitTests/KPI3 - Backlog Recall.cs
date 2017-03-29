using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDentBusiness;
using System.Data;
using KPIReporting.KPI;

namespace UnitTests
{
    [TestClass]
    public class KPI3
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\backlogrecall.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }

        [TestMethod]
        public void GetPatientsOnRecall()
        {
            var startDate = new DateTime(2016, 3, 20);
            var endDate = new DateTime(2017, 3, 20);
            DataTable test = KPIRecallBacklog.GetRecallBacklog(startDate, endDate);
            Assert.IsNotNull(test);
            Assert.AreEqual(23, test.Rows.Count);
        }
    }
}
