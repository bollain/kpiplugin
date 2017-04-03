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
    public class KPI4
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi4noshow.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }

        [TestMethod]
        public void GetPatientsNoShow()
        {
            DataTable real_dt = KPINoShowAppt.GetNoShowAppt(Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-03-20"));
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Gender");
            expected_dt.Columns.Add("Age");
            expected_dt.Columns.Add("Postal Code");
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Primary Provider");
			expected_dt.Columns.Add("Procedure Description");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Name"] = "Test, Patient 1";
            _testPat["Gender"] = "F";
            var birthdate = Convert.ToDateTime("1990-07-21");
            var age = DateTime.UtcNow.Year - birthdate.Year;
            if (birthdate > DateTime.UtcNow.AddYears(-age)) age--;
            _testPat["Age"] = age.ToString();
            _testPat["Postal Code"] = "T6E1R1";
            _testPat["Primary Provider"] = "DOC";
			_testPat["Procedure Description"] = "fix teeth";

            expected_dt.Rows.Add(_testPat);

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(1, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Name"], expected_dt.Rows[0]["Name"]);

        }
    }
}