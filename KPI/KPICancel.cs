using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI
{
	public class KPICancel {

		///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
		public static DataTable GetCancel(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
			DataTable table=new DataTable();
			table.Columns.Add("Name");
			table.Columns.Add("Gender");
			table.Columns.Add("Age");
			table.Columns.Add("Postal Code");
			table.Columns.Add("Date of Service");
            table.Columns.Add("Primary Provider");
            table.Columns.Add("Procedure Description");
            DataRow row;
            string command = @"
				SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Zip, p.PriProv, p.Preferred, p.Birthdate, r.ProcDate, a.ProcDescript
                FROM patient p 
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN procedurecode c ON r.CodeNum = c.CodeNum
                JOIN appointment a ON a.AptNum = r.AptNum
                WHERE (c.ProcCode = 99998 OR c.ProcCode = 99997) AND 
                r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd);

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
				row["Primary Provider"]=Providers.GetAbbr(PIn.Long(raw.Rows[i]["PriProv"].ToString()));
                row["Gender"] = genderFormat(raw.Rows[i]["Gender"].ToString());
				row["Postal Code"]=raw.Rows[i]["Zip"].ToString();
                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Procedure Description"] = raw.Rows[i]["ProcDescript"].ToString();
                row["Age"] = birthdate_to_age(raw.Rows[i]["Birthdate"].ToString());
				table.Rows.Add(row);
			}
			return table;
		}

        private static string genderFormat(string gNum)
        {
            if (gNum == "0") {
                return "M";
            }
            else if (gNum == "1") {
                return "F";
            }
            else {
                return "Unknown";
            }
        }

        private static int birthdate_to_age(string bd) {
            DateTime birthdate = Convert.ToDateTime(bd);
            var today = DateTime.UtcNow;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }

	}
}
