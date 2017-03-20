using System;
using System.IO;
using System.Reflection;
using OpenDental;
using OpenDentBusiness;


namespace UnitTests
{
    class DatabaseTools
    {
        //public static string DbName;

        //public static bool DbExists(){
        //	string command="";
        //}

        ///<summary>This is analogous to FormChooseDatabase.TryToConnect.  Empty string is allowed.</summary>
        public static bool SetDbConnection(string dbName, bool isOracle)
        {
            return SetDbConnection(dbName, "localhost", "", "root", "", isOracle);
        }

        //<summary>This function allows connecting to a specific server.</summary>
        public static bool SetDbConnection(string dbName, string serverAddr, string port, string userName, string password, bool isOracle)
        {
            OpenDentBusiness.DataConnection dcon;
            //Try to connect to the database directly
            try
            {
                if (!isOracle)
                {
                    DataConnection.DBtype = DatabaseType.MySql;
                    dcon = new OpenDentBusiness.DataConnection(DataConnection.DBtype);
                    dcon.SetDb("Server=" + serverAddr + ";Port=" + port + ";Database=" + dbName + ";User ID=" + userName + ";Password=" + password + ";CharSet=utf8;Treat Tiny As Boolean=false", "", DataConnection.DBtype, true);
                    RemotingClient.RemotingRole = RemotingRole.ClientDirect;
                    return true;
                }
                else
                {
                    DataConnection.DBtype = DatabaseType.Oracle;
                    dcon = new OpenDentBusiness.DataConnection(DataConnection.DBtype);
                    dcon.SetDb("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + serverAddr + ")(PORT=" + port + "))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=" + userName + ";Password=" + password + ";", "", DataConnection.DBtype, true);
                    RemotingClient.RemotingRole = RemotingRole.ClientDirect;
                    return true;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                //textResults.Text="Make a copy of any OD db and rename it to unittest.";
                if (isOracle)
                {
                    //MessageBox.Show("May need to create a Fresh Db for Oracle.");
                }
                return false;
            }
        }

        public static string FreshFromDump(string serverAddr, string port, string userName, string password, bool isOracle)
        {
            if (!isOracle)
            {
                string command = "DROP DATABASE IF EXISTS unittest";
                try
                {
                    DataCore.NonQ(command);
                }
                catch
                {
                    throw new Exception("Database could not be dropped.  Please remove any remaining text files and try again.");
                }
                command = "CREATE DATABASE unittest";
                DataCore.NonQ(command);
                SetDbConnection("unittest", serverAddr, port, userName, password, false);
                command = File.ReadAllText(@"C:\Users\Armando\Documents\Visual Studio 2015\Projects\OpenDental\KPIReporting\UnitTests\Resources\dump.txt");
                DataCore.NonQ(command);
                string toVersion = Assembly.GetAssembly(typeof(OpenDental.PrefL)).GetName().Version.ToString();
                //MessageBox.Show(Application.ProductVersion+" - "+
//                if (!PrefL.ConvertDB(true, toVersion))
//                {
//                    throw new Exception("Wrong version.");
//                }
                //ProcedureCodes.TcodesClear();
                //FormProcCodes.ImportProcCodes("", CDT.Class1.GetADAcodes(), "");//IF THIS LINE CRASHES:
                                                                                //Go to Solution, Configuration Manager.  Exclude UnitTest project from build.
//                AutoCodes.SetToDefault();
//                ProcButtons.SetToDefault();
//                ProcedureCodes.ResetApptProcsQuickAdd();
                //RefreshCache (might be missing a few)  Or, it might make more sense to do this as an entirely separate method when running.
                //ProcedureCodes.RefreshCache();
            }
            else
            {
                //This stopped working. Might look into it later: for now manually create the unittest db

                //Make sure the command CREATE OR REPLACE DIRECTORY dmpdir AS 'c:\oraclexe\app\tmp'; was run
                //and there is an opendental user with matching username/pass 
                //The unittest.dmp was taken from a fresh unittest db created from the code above.  No need to alter it further. 
                //string command=@"impdp opendental/opendental DIRECTORY=dmpdir DUMPFILE=unittest.dmp TABLE_EXISTS_ACTION=replace LOGFILE=impschema.log";
                //ExecuteCommand(command);
            }
            return "Fresh database loaded from sql dump.\r\n";
        }

        private static void ExecuteCommand(string Command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;
                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + Command);
                ProcessInfo.CreateNoWindow = false;
                ProcessInfo.UseShellExecute = false;
                Process = System.Diagnostics.Process.Start(ProcessInfo);
                Process.Close();
            }
            catch
            {
                throw new Exception("Running cmd failed.");
            }
        }


        public static string ClearDb()
        {
            string command = @"
				DELETE FROM appointment;
				DELETE FROM carrier;
				DELETE FROM claim;
				DELETE FROM claimproc;
				DELETE FROM clockevent;
				DELETE FROM employee;
				DELETE FROM fee;
				DELETE FROM feesched WHERE FeeSchedNum !=53; /*because this is the default fee schedule for providers*/
				DELETE FROM hl7def;
				DELETE FROM hl7msg;
				DELETE FROM insplan;
				DELETE FROM patient;
				DELETE FROM patientrace;
				DELETE FROM patplan;
				DELETE FROM payperiod;
				DELETE FROM procedurelog;
				DELETE FROM provider WHERE ProvNum>2;
				DELETE FROM timeadjust;
				DELETE FROM timecardrule;
				";
            DataCore.NonQ(command);
//            Providers.RefreshCache();
//            FeeScheds.RefreshCache();
            return "Database cleared of old data.\r\n";
        }


    }
}