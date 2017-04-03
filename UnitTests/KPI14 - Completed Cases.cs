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

            String patQuery = @"
                SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM unittest.procedurelog pl
                JOIN unittest.appointment a ON pl.PlannedAptNum = a.AptNum
                JOIN unittest.procedurecode pc ON pc.CodeNum = pl.CodeNum
                JOIN unittest.patient p ON p.PatNum = pl.PatNum
                WHERE a.AptStatus = 6
                AND pl.ProcStatus = 2      
                AND (pl.ProcDate BETWEEN '2016-03-21' AND '2018-03-21' )
            ";


            // var patsFor14a = KPICompletedCases.GetCompletedCasesPats(startDate, endDate);
            var patsFor14a = StretchKPICustomForm.GetPatients(startDate, endDate, patQuery);
            Assert.IsNotNull(patsFor14a);
            Assert.AreEqual(1, patsFor14a.Rows.Count);

            var compcasesFor14a = KPICompletedCases.GetCompletedCasesPerPat(startDate, endDate,
                "1401");

            Assert.AreEqual(1, compcasesFor14a.Rows.Count);

            var seedData3 = File.ReadAllText(@"..\..\Resources\kpi14completedcasesPT3.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData3);

            var patsFor14b = StretchKPICustomForm.GetPatients(startDate, endDate, patQuery);
            Assert.IsNotNull(patsFor14b);
            Assert.AreEqual(2, patsFor14b.Rows.Count);

            var compcasesFor14b = KPICompletedCases.GetCompletedCasesPerPat(startDate, endDate,
                "1402");
            Assert.AreEqual(3, compcasesFor14b.Rows.Count);
            compcasesFor14b = KPICompletedCases.GetCompletedCasesPerPat(startDate, endDate,
                "1403");
            Assert.AreEqual(3, compcasesFor14b.Rows.Count);

        }
    }
}
