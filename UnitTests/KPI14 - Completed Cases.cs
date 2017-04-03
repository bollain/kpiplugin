using System;
using System.IO;
using System.Data;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDental;
using KPIReporting.KPI;
using OpenDentBusiness;

namespace UnitTests
{
    [TestClass]
    public class KPI14
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi14completedcasesPT1.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);

        }
        [TestMethod]
        public void GetCompletedCases()
        {
            DataTable compcasesFor14;
            DataTable patsFor14;
            patsFor14 = KPICompletedCases.GetCompletedCasesPats(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"));

            Assert.AreEqual(0, patsFor14.Rows.Count);
            
            var seedData2 = File.ReadAllText(@"..\..\Resources\kpi14completedcasesPT2.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData2);

            var startDate = new DateTime(2016, 3, 20);
            var endDate = new DateTime(2017, 4, 5);
            var patsFor14a = KPICompletedCases.GetCompletedCasesPats(startDate, endDate);
            Assert.IsNotNull(patsFor14a);
            Assert.AreEqual(1, patsFor14a.Rows.Count);
            

        }
    }
}
