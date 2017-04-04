using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDentBusiness;
using System.Data;
using KPIReporting.KPI;

namespace UnitTests
{
    [TestClass]
    public class DowntimeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\downtime.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }

        [TestMethod]
        public void GetProviderDowntime()
        {

            DataTable test = KPIReporting.KPI.KPIDowntime.GetDowntime(Convert.ToDateTime("2014-03-20"), Convert.ToDateTime("2017-03-20"));


            Assert.IsNotNull(test);
            Assert.AreEqual("00:20:00", test.Rows[0][1]);
            Assert.AreEqual("00:40:00", test.Rows[1][1]);



        }
    }
}
