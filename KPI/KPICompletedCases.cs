using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI {
	public class KPICompletedCases {
        /*
        Completed cases
        List of patients compiled from the Treatment Plan module whose treatment has been
        completed within the period designated by the operator
        */

        ///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetCompletedCases(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
			DataTable table=new DataTable();
			table.Columns.Add("Name");
			table.Columns.Add("Date of Service");

            table.Columns.Add("Treatment Code");  
            table.Columns.Add("Treatment Completed");  
            table.Columns.Add("Billed");   

            DataRow row;


            string command = @"
				SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Zip, p.PriProv, pl.ProcDate, pl.ProcNum, pc.ProcCode, 
                        pc.Descript, pl.ProcFee
                FROM procedurelog pl
                JOIN appointment a ON pl.PlannedAptNum = a.AptNum
                JOIN procedurecode pc ON pc.CodeNum = pl.CodeNum
                JOIN patient p ON p.PatNum = pl.PatNum
                WHERE a.AptStatus = 6
                AND pl.ProcStatus = 2
                AND (pl.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @")";



            DataTable raw = ReportsComplex.GetTable(command);
			Patient pat;
           
			for(int i=0;i<raw.Rows.Count;i++) {
                
                row =table.NewRow();
				pat=new Patient();
				pat.LName=raw.Rows[i]["LName"].ToString();
				pat.FName=raw.Rows[i]["FName"].ToString();
				pat.MiddleI=raw.Rows[i]["MiddleI"].ToString();
                row["Name"] = raw.Rows[i]["FName"].ToString() + " " + raw.Rows[i]["MiddleI"].ToString() +
                 " " + raw.Rows[i]["LName"].ToString();
                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Treatment Code"] = raw.Rows[i]["ProcCode"].ToString();
                row["Treatment Completed"] = raw.Rows[i]["Descript"].ToString();
                row["Billed"] = raw.Rows[i]["ProcFee"].ToString();

                table.Rows.Add(row);
                
            }
            return table;
		}




        public static DataTable GetCompletedCasesPats(DateTime dateStart, DateTime dateEnd)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("PatNum");
            table.Columns.Add("Name");
            table.Columns.Add("Home Phone");
            table.Columns.Add("Work Phone");
            table.Columns.Add("Cell Phone");
            table.Columns.Add("Email");

            DataRow row;

            string command = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM procedurelog pl
                JOIN appointment a ON pl.PlannedAptNum = a.AptNum
                JOIN procedurecode pc ON pc.CodeNum = pl.CodeNum
                JOIN patient p ON p.PatNum = pl.PatNum
                WHERE a.AptStatus = 6
                AND pl.ProcStatus = 2      
                AND (pl.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @")
            ";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();
                pat.MiddleI = raw.Rows[i]["MiddleI"].ToString();
                row["Name"] = raw.Rows[i]["FName"].ToString() + " " + raw.Rows[i]["LName"].ToString();
                pat.HmPhone = raw.Rows[i]["HmPhone"].ToString();
                pat.WkPhone = raw.Rows[i]["WkPhone"].ToString();
                pat.WirelessPhone = raw.Rows[i]["WirelessPhone"].ToString();
                pat.Email = raw.Rows[i]["Email"].ToString();

                row["PatNum"] = raw.Rows[i]["PatNum"].ToString();
                row["Home Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Work Phone"] = raw.Rows[i]["WkPhone"].ToString();
                row["Cell Phone"] = raw.Rows[i]["WirelessPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();

                table.Rows.Add(row);
            }


            return table;

        }

        public static DataTable GetCompletedCasesPerPat(DateTime dateStart, DateTime dateEnd, String patNum)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Treatment Code");
            table.Columns.Add("Treatment Completed");
            table.Columns.Add("Billed");

            DataRow row;

            string command = @"
				SELECT  pc.ProcCode, pl.ProcDate,
                        pc.Descript, pl.ProcFee
                FROM procedurelog pl
                JOIN appointment a ON pl.PlannedAptNum = a.AptNum
                JOIN procedurecode pc ON pc.CodeNum = pl.CodeNum
                JOIN patient p ON p.PatNum = pl.PatNum
                WHERE a.AptStatus = 6
                AND pl.ProcStatus = 2
                AND (pl.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @")
                AND p.PatNum = '" + patNum + @"'
                ";

            DataTable raw = ReportsComplex.GetTable(command);

            for (int i = 0; i < raw.Rows.Count; i++)
            {

                row = table.NewRow();
                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Treatment Code"] = raw.Rows[i]["ProcCode"].ToString();
                row["Treatment Completed"] = raw.Rows[i]["Descript"].ToString();
                double a = (double)raw.Rows[i]["ProcFee"];
                row["Billed"] = a;

                table.Rows.Add(row);

            }
            return table;
        }

        private static string genderFormat(string gNum)
        {
            if (gNum == "0")
            {
                return "M";
            }
            else if (gNum == "1")
            {
                return "F";
            }
            else
            {
                return "Unknown";
            }
        }

        private static int birthdate_to_age(string bd)
        {
            DateTime birthdate = Convert.ToDateTime(bd);
            var today = DateTime.UtcNow;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }

    }
}
