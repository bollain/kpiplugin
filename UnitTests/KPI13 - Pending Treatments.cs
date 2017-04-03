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
    public class KPI13
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT1.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);

        }

        [TestMethod]
        public void GetPendingTreatments()
        {

            DataTable plannedAppsFor13;
            DataTable patsFor13;
            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"), 
                 KPIPendingTreatments.getPatQuery());

            Assert.AreEqual(0, patsFor13.Rows.Count);

            // TEST FOR 2 TREATMENTS FOR 1 PAT, 1 PLANNEDAPPT; ONE TREATMENT HAS CODE 01202 
            var seedData2 = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT2.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData2);

            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                 KPIPendingTreatments.getPatQuery());

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                patsFor13.Rows[0]["PatNum"].ToString());

            Assert.AreEqual(1, patsFor13.Rows.Count);
            Assert.AreEqual(1, plannedAppsFor13.Rows.Count);

            // TEST FOR 6 MORE TREATMENTS FOR 3PATS, 2 MORE PLANNEDAPPTS
            var seedData3 = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT3.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData3);

            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                 KPIPendingTreatments.getPatQuery());

            Assert.AreEqual(3, patsFor13.Rows.Count);

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                "1302");
            Assert.AreEqual(3, plannedAppsFor13.Rows.Count);

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                "1303");
            Assert.AreEqual(3, plannedAppsFor13.Rows.Count);

            // TEST FOR 3 LESS TREATMENTS FOR 3PATS, 1 MORE SCHEDULEDAPPT
            var seedData4 = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT4.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData4);

            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                 KPIPendingTreatments.getPatQuery());

            Assert.AreEqual(2, patsFor13.Rows.Count);


            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                "1302");
            Assert.AreEqual(0, plannedAppsFor13.Rows.Count);

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
               "1303");
            Assert.AreEqual(3, plannedAppsFor13.Rows.Count);




        }
    }
}
