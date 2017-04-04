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
    public class KPI12
    {
        [TestInitialize]
        public void Initialize()
        {
            //Create test DB
            DatabaseTools.SetDbConnection("", "localhost", "3306", "root", "", false);
            DatabaseTools.FreshFromDump("localhost", "3306", "root", "", false);
            //Inject data
            var seedData = File.ReadAllText(@"..\..\Resources\kpi12.txt");
            DatabaseTools.ExecuteSqlScript("localhost", "3306", "root", "", seedData);
        }



        [TestMethod]
        public void GetCorrect()
        {
            Float real_val = KPIConversionRate.GetConversionRate(Convert.ToDateTime('2017-03-15'), Convert.ToDateTime("2017-03-30"), "01202");
            Float exp_val = 100


            Assert.IsNotNull(real_val);
            Assert.AreEqual(exp_val, real_val);
        }


        [TestMethod]
        public void Get0Percent()
        {
          Float real_val = KPIConversionRate.GetConversionRate(Convert.ToDateTime('2017-03-15'), Convert.ToDateTime("2017-03-30"), "02202");
          Float exp_val = 0


          Assert.IsNotNull(real_val);
          Assert.AreEqual(exp_val, real_val);

        }


        [TestMethod]
        public void GetNoProcedures()
        {
          Float real_val = KPIConversionRate.GetConversionRate(Convert.ToDateTime('2017-03-15'), Convert.ToDateTime("2017-03-30"), "02222");
          Float exp_val = 9999


          Assert.IsNotNull(real_val);
          Assert.AreEqual(exp_val, real_val);

        }
      }

  }
