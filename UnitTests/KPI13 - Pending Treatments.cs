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
            // DataTable real_dt = KPIActiveRecall.GetActiveRecall(Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-03-20"));
            // DataTable patsFor13 = KPIPendingTreatments.GetPendingTreatmentPats(
            //    Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"));
            String patQuery = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
            ";

            DataTable plannedAppsFor13;
            DataTable patsFor13;
            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"), patQuery);

            Assert.AreEqual(0, patsFor13.Rows.Count);

            // TEST FOR 2 TREATMENTS FOR 1 PAT, 1 PLANNEDAPPT; ONE TREATMENT HAS CODE 01202 
            var seedData2 = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT2.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData2);

            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"), patQuery);

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                patsFor13.Rows[0]["PatNum"].ToString());

            Assert.AreEqual(1, patsFor13.Rows.Count);
            Assert.AreEqual(1, plannedAppsFor13.Rows.Count);

            // TEST FOR 6 MORE TREATMENTS FOR 3PATS, 2 MORE PLANNEDAPPTS
            var seedData3 = File.ReadAllText(@"..\..\Resources\kpi13pendingtreatmentsPT3.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData3);

            patsFor13 = StretchKPICustomForm.GetPatients(
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"), patQuery);

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
                 Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"), patQuery);

            Assert.AreEqual(2, patsFor13.Rows.Count);


            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
                "1302");
            Assert.AreEqual(0, plannedAppsFor13.Rows.Count);

            plannedAppsFor13 = KPIPendingTreatments.GetPendingTreatmentProcsPerPat(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"),
               "1303");
            Assert.AreEqual(3, plannedAppsFor13.Rows.Count);



            /*
            DataTable expected_dt = new DataTable();
            expected_dt.Clear();
            expected_dt.Columns.Add("PatNum");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Home Phone");
            expected_dt.Columns.Add("Work Phone");
            expected_dt.Columns.Add("Cell Phone");     
            expected_dt.Columns.Add("Email"); 
            */

            /*
            DataRow _testPat = expected_dt.NewRow();
            _testPat["Name"] = "Test, Patient 1";
            _testPat["Gender"] = "F";
            var birthdate = Convert.ToDateTime("1990-07-21");
            var age = DateTime.UtcNow.Year - birthdate.Year;
            if (birthdate > DateTime.UtcNow.AddYears(-age)) age--;
            _testPat["Age"] = age.ToString();
            _testPat["Postal Code"] = "T6E1R1";
            _testPat["Date of Service"] = "25/12/2016";
            _testPat["Frequency"] = "1y";
            _testPat["Primary Provider"] = "DOC";
            */

            // expected_dt.Rows.Add(_testPat);

            // Assert.IsNotNull(real_dt);

            // Assert.AreEqual(real_dt.Rows[0]["Name"], expected_dt.Rows[0]["Name"]);

        }
    }
}
