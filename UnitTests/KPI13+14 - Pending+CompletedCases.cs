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
    public class KPI1314
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi1314pendingcompletetreatments.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }

        [TestMethod]
        public void GetPatientsOnActiveRecall()
        {
            // DataTable real_dt = KPIActiveRecall.GetActiveRecall(Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-03-20"));
            DataTable patsFor13 = KPIPendingTreatments.GetPendingTreatmentPats(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"));

            DataTable patsFor14 = KPICompletedCases.GetCompletedCasesPats(
                Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-04-05"));
            DataTable patsFor14dateOutOfRange = KPICompletedCases.GetCompletedCasesPats(
                Convert.ToDateTime("2018-03-20"), Convert.ToDateTime("2019-04-05"));

            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("PatNum");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Home Phone");
            expected_dt.Columns.Add("Work Phone");
            expected_dt.Columns.Add("Cell Phone");     
            expected_dt.Columns.Add("Email");                   

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

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(1, patsFor13.Rows.Count);
            Assert.AreEqual(3, patsFor14.Rows.Count);
            Assert.AreEqual(0, patsFor14dateOutOfRange.Rows.Count);
            // Assert.AreEqual(real_dt.Rows[0]["Name"], expected_dt.Rows[0]["Name"]);

        }
    }
}
