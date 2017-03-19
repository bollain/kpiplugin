using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI {
	public class KPIActiveRecall {

		///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
		public static DataTable GetActiveRecall(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
			DataTable table=new DataTable();
			table.Columns.Add("Name");
			table.Columns.Add("Gender");
			table.Columns.Add("Age");
			table.Columns.Add("Postal Code");
			table.Columns.Add("Date of Service");
            table.Columns.Add("Frequency");
            table.Columns.Add("Primary Provider");
            DataRow row;
            string command = @"
				SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Zip, p.PriProv, p.Preferred, r.ProcDate, p.Birthdate, q.RecallInterval
				FROM patient p 
				JOIN procedurelog r ON r.PatNum = p.PatNum 
                JOIN recall q ON p.PatNum = q.PatNum 
				WHERE r.ProcDate = (SELECT MAX(r2.ProcDate) 
                FROM procedurelog r2
                JOIN procedurecode c ON r2.CodeNum = c.CodeNum 
                WHERE r.PatNum = r2.PatNum AND
                c.ProcCode = 01202 AND 
                r2.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @") AND
                q.RecallTypeNum = 1 AND 
                q.IsDisabled = 0 GROUP BY p.PatNum";

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
                Console.Write(raw.Rows[i]["Gender"].ToString());
                row["Gender"] = genderFormat(raw.Rows[i]["Gender"].ToString());
				row["Postal Code"]=raw.Rows[i]["Zip"].ToString();
                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Age"] = birthdate_to_age(raw.Rows[i]["Birthdate"].ToString());
                Interval frequency = new Interval(Int32.Parse(raw.Rows[i]["RecallInterval"].ToString()));
                row["Frequency"] = frequency.ToString();
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
