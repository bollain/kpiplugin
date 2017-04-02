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
    public class KPI11
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi11.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }



        [TestMethod]
        public void GetNYY()
        {
            DataTable real_dt = KPIRecTreatment.GetRecTreatmentNYY(20, "01202");
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            expected_dt.Rows.Add(_testPat);

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(3, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);

        }


        [TestMethod]
        public void GetNYN()
        {
            DataTable real_dt = KPIRecTreatment.GetRecTreatmentNYN(20);
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            DataRow _testPat2 = expected_dt.NewRow();
            _testPat2["Procedure"] = "01202";

            DataRow _testPat3 = expected_dt.NewRow();
            _testPat3["Procedure"] = "01202";




            expected_dt.Rows.Add(_testPat);
            expected_dt.Rows.Add(_testPat2);
            expected_dt.Rows.Add(_testPat3);



            Assert.IsNotNull(real_dt);
            Assert.AreEqual(3, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[1]["Procedure"], expected_dt.Rows[1]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[2]["Procedure"], expected_dt.Rows[2]["Procedure"]);



        }


        [TestMethod]
        public void GetNNY()
        {
            DataTable real_dt = KPIRecTreatment.GetRecTreatmentNNY("01202");
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            DataRow _testPat2 = expected_dt.NewRow();
            _testPat2["Procedure"] = "01202";

            DataRow _testPat3 = expected_dt.NewRow();
            _testPat3["Procedure"] = "01202";

            DataRow _testPat4 = expected_dt.NewRow();
            _testPat4["Procedure"] = "01202";

            DataRow _testPat5 = expected_dt.NewRow();
            _testPat5["Procedure"] = "01202";

            DataRow _testPat6 = expected_dt.NewRow();
            _testPat6["Procedure"] = "01202";

            expected_dt.Rows.Add(_testPat);
            expected_dt.Rows.Add(_testPat2);
            expected_dt.Rows.Add(_testPat3);
            expected_dt.Rows.Add(_testPat4);
            expected_dt.Rows.Add(_testPat5);
            expected_dt.Rows.Add(_testPat6);



            Assert.IsNotNull(real_dt);
            Assert.AreEqual(6, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);

        }


        [TestMethod]
        public void GetNNN()
        {
            DataTable real_dt = KPIRecTreatment.GetRecTreatmentNNN();
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(6, real_dt.Rows.Count);

        }


        [TestMethod]
        public void GetYYY()
        {
            DataTable real_dt = KPIRecTreatment.GetRecTreatmentYYY(Convert.ToDateTime("2017-03-15"), Convert.ToDateTime("2017-03-30"),20, "01202");
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            expected_dt.Rows.Add(_testPat);

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(2, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);

        }


        [TestMethod]
        public void GetYYN()
        {
          DataTable real_dt = KPIRecTreatment.GetRecTreatmentYYN(Convert.ToDateTime("2017-03-07"), Convert.ToDateTime("2017-03-30"),21);
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            DataRow _testPat2 = expected_dt.NewRow();
            _testPat2["Procedure"] = "01202";

            DataRow _testPat3 = expected_dt.NewRow();
            _testPat3["Procedure"] = "01202'";


            expected_dt.Rows.Add(_testPat);
            expected_dt.Rows.Add(_testPat2);
            expected_dt.Rows.Add(_testPat3);


            Assert.IsNotNull(real_dt);
            Assert.AreEqual(3, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[1]["Procedure"], expected_dt.Rows[1]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[2]["Procedure"], expected_dt.Rows[2]["Procedure"]);

        }


        [TestMethod]
        public void GetYNY()
        {
          DataTable real_dt = KPIRecTreatment.GetRecTreatmentYNY(Convert.ToDateTime("2017-03-02"), Convert.ToDateTime("2017-03-30"),"01202");
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Procedure"] = "01202";

            DataRow _testPat2 = expected_dt.NewRow();
            _testPat2["Procedure"] = "01202";

            DataRow _testPat3 = expected_dt.NewRow();
            _testPat3["Procedure"] = "01202";

            expected_dt.Rows.Add(_testPat);
            expected_dt.Rows.Add(_testPat2);
            expected_dt.Rows.Add(_testPat3);

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(6, real_dt.Rows.Count);
            Assert.AreEqual(real_dt.Rows[0]["Procedure"], expected_dt.Rows[0]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[1]["Procedure"], expected_dt.Rows[1]["Procedure"]);
            Assert.AreEqual(real_dt.Rows[2]["Procedure"], expected_dt.Rows[2]["Procedure"]);


        }


        [TestMethod]
        public void GetYNN()
        {
          DataTable real_dt = KPIRecTreatment.GetRecTreatmentYNN(Convert.ToDateTime("2017-03-02"), Convert.ToDateTime("2017-03-30"));
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Procedure");
            expected_dt.Columns.Add("Priority");
            expected_dt.Columns.Add("Status of Pre-Authorization");

            Assert.IsNotNull(real_dt);
            Assert.AreEqual(6, real_dt.Rows.Count);

        }
    }
}
