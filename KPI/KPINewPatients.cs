using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI
{
	public class KPINewPatients {

		///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
		public static DataTable GetNewPatients(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
			DataTable table=new DataTable();
			table.Columns.Add("Name");
			table.Columns.Add("Gender");
			table.Columns.Add("Age");
			table.Columns.Add("Date of Service");
            DataRow row;
            string command = @"
                SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Preferred, r.ProcDate, p.Birthdate  
                FROM patient p 
                INNER JOIN procedurelog r ON r.PatNum = p.PatNum 
                INNER JOIN procedurecode c ON c.CodeNum = r.CodeNum
                WHERE (c.ProcCode = 01101 OR c.ProcCode = 01102 OR c.ProcCode = 01103) AND
                (r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @")
                GROUP BY p.PatNum";

            DataTable raw=ReportsComplex.GetTable(command);
			Patient pat;
			for(int i=0;i<raw.Rows.Count;i++) {
				row=table.NewRow();
				pat=new Patient();
				pat.LName=raw.Rows[i]["LName"].ToString();
				pat.FName=raw.Rows[i]["FName"].ToString();
				pat.MiddleI=raw.Rows[i]["MiddleI"].ToString();
				pat.Preferred=raw.Rows[i]["Preferred"].ToString();
				row["Name"]=pat.GetNameLF();
                row["Gender"] = genderFormat(raw.Rows[i]["Gender"].ToString());
                row["Age"] = birthdate_to_age(raw.Rows[i]["Birthdate"].ToString());
                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString();
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
