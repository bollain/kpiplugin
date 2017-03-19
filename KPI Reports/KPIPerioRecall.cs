using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness {
	public class KPIPerioRecall {

		///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
		public static DataTable GetPerioRecall(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
			DataTable table=new DataTable();
			table.Columns.Add("Name");
			table.Columns.Add("Gender");
			table.Columns.Add("Age");
			table.Columns.Add("Postal Code");
			table.Columns.Add("Date of Next Appointment");
            table.Columns.Add("Frequency");
            table.Columns.Add("HygienistID");
            table.Columns.Add("Primary Provider");
            DataRow row; //Could not find code 43400 so just assumed all procedure codes between 40000 and 50000
            string command = @"
				SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Zip, p.PriProv, p.Preferred, p.Birthdate, r.RecallInterval, a.AptDateTime, a.ProvHyg
				FROM patient p 
				JOIN procedurelog x ON x.PatNum = p.PatNum 
                JOIN procedurecode c ON c.CodeNum = x.CodeNum 
                JOIN appointment a ON a.AptNum = x.AptNum 
                JOIN recall r ON r.PatNum = p.PatNum 
                WHERE r.IsDisabled = 0 AND 
                r.RecallTypeNum = 3 AND 
                c.ProcCode > 40000 AND 
                c.ProcCode < 50000 AND 
                a.IsHygiene = 1 AND 
                a.AptDateTime = (SELECT MAX(a2.AptDateTime) 
                FROM appointment a2 
                WHERE a2.AptNum = a.AptNum AND 
                a2.AptDateTime BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @") GROUP BY p.PatNum";

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
                row["Date of Next Appointment"] = raw.Rows[i]["AptDateTime"].ToString().Substring(0, 10);
                Interval frequency = new Interval(Int32.Parse(raw.Rows[i]["RecallInterval"].ToString()));
                row["Frequency"] = frequency.ToString();
                row["HygienistID"] = raw.Rows[i]["ProvHyg"].ToString();
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
