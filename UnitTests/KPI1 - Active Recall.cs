using System;
using System.IO;
using System.Data;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDentBusiness;


namespace UnitTests
{
    [TestClass]
    public class KPI1
    {
        [TestMethod]
        public void InjectPatients()
        {
            string injectKPI = @"/* Truncate all involved tables */
            TRUNCATE TABLE unittest.patient;
            TRUNCATE TABLE unittest.recall;
            TRUNCATE TABLE unittest.procedurelog;

            /* Insert 1 patient who should qualify as on Active Recall */
            INSERT INTO `unittest`.`procedurelog` (`PatNum`, `CodeNum`, `ProcDate`) VALUES('1', '404', '2016-12-25');
            INSERT INTO `unittest`.`recall` (`PatNum`, `RecallInterval`, `IsDisabled`, `RecallTypeNum`) VALUES('1', '16777216', '0', '1');
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `MiddleI`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('Test', 'Patient', '1', '1', '1990-07-21', 'T6E1R1', '1');

            /*Amanda TooLongAgo - Patient with latest procedure date too far in the past to qualify for being on active recall*/
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('TooLongAgo', 'Amanda', '1', '1976-03-22', 'A5A5A5', '1');
            INSERT INTO `unittest`.`procedurelog` (`PatNum`, `CodeNum`, `ProcDate`) VALUES('2', '404', '2013-12-25');
            INSERT INTO `unittest`.`recall` (`PatNum`, `RecallInterval`, `IsDisabled`, `RecallTypeNum`) VALUES('2', '167772', '0', '1');

            /*Tom IsDisabled - Patient with recall flagged as disabled */
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('IsDisabled', 'Tom', '0', '1982-06-28', 'T6E1R1', '1');
            INSERT INTO `unittest`.`procedurelog` (`PatNum`, `CodeNum`, `ProcDate`) VALUES('3', '404', '2017-12-25');
            INSERT INTO `unittest`.`recall` (`PatNum`, `RecallInterval`, `IsDisabled`, `RecallTypeNum`) VALUES('3', '167772', '1', '1');

            /*Mary WrongCode - Patient with procedure code that is not 404 */
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('WrongCode', 'Mary', '1', '1999-10-28', 'T6E1R1', '1');
            INSERT INTO `unittest`.`procedurelog` (`PatNum`, `CodeNum`, `ProcDate`) VALUES('4', '30000', '2017-12-25');
            INSERT INTO `unittest`.`recall` (`PatNum`, `RecallInterval`, `IsDisabled`, `RecallTypeNum`) VALUES('4', '167772', '0', '1');

            /*Marsha NoRecall - Patient with no table instance of recall */
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('NoRecall', 'Marsha', '1', '1995-03-28', 'T6E1R1', '1');
            INSERT INTO `unittest`.`procedurelog` (`PatNum`, `CodeNum`, `ProcDate`) VALUES('5', '404', '2017-12-25');

            /*Erica NoLog- Patient with no procedurelog at all */
            INSERT INTO `unittest`.`patient` (`LName`, `FName`, `Gender`, `Birthdate`, `Zip`, `PriProv`) VALUES('NoLog', 'Erica', '1', '1959-10-28', 'T6E1R1', '1');
            INSERT INTO `unittest`.`recall` (`PatNum`, `RecallInterval`, `IsDisabled`, `RecallTypeNum`) VALUES ('6', '167772', '0', '1');";

            //If the above gives an SQL syntax error, strip all white linebreaks
            injectSQLWithSpecialGuestArmando(injectKPI);

            DataTable real_dt = KPIActiveRecall.GetActiveRecall(Convert.ToDateTime("2016-03-20"), Convert.ToDateTime("2017-03-20"));
            DataTable expected_dt = new DataTable();

            expected_dt.Clear();
            expected_dt.Columns.Add("Name");
            expected_dt.Columns.Add("Gender");
            expected_dt.Columns.Add("Age");
            expected_dt.Columns.Add("Postal Code");
            expected_dt.Columns.Add("Date of Service");
            expected_dt.Columns.Add("Frequency");
            expected_dt.Columns.Add("Primary Provider");

            DataRow _testPat = expected_dt.NewRow();
            _testPat["Name"] = "Test, Patient 1";
            _testPat["Gender"] = "F";
            _testPat["Age"] = "26";
            _testPat["Postal Code"] = "T6E1R1";
            _testPat["Date of Service"] = "25/12/2016";
            _testPat["Frequency"] = "1y";
            _testPat["Primary Provider"] = "DOC";

        }
    }
}
