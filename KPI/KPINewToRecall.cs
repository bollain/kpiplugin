using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Collections;
using OpenDentBusiness;

namespace KPIReporting.KPI
{
	public class KPINewToRecall {

        ///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetNewToRecall(DateTime dateStart,DateTime dateEnd) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetTable(MethodBase.GetCurrentMethod(),dateStart,dateEnd);
			}
            DataTable table = new DataTable();

            table.Columns.Add("Name");
            table.Columns.Add("Gender");
            table.Columns.Add("Age");
            table.Columns.Add("Type of Recall");
            DataRow row;
            string command = @"
               SELECT p.LName, p.FName, p.MiddleI, p.Gender, p.Preferred, p.Birthdate, t1.Description  
	FROM patient p 
		INNER JOIN procedurelog l ON l.PatNum = p.PatNum 
		INNER JOIN procedurecode c ON c.CodeNum = l.CodeNum
        INNER JOIN recalltrigger t2 ON c.CodeNum = t2.CodeNum
        INNER JOIN recalltype t1 ON t2.RecallTypeNum = t1.RecallTypeNum
                WHERE c.ProcCode = 01202 AND
					  (l.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @") AND
                      l.PatNum IN (SELECT p2.PatNum
								FROM patient p2
									INNER JOIN procedurelog l2 ON l2.PatNum = p2.PatNum 
									INNER JOIN procedurecode c2 ON c2.CodeNum = l2.CodeNum
								WHERE (c2.ProcCode = 01101 OR c2.ProcCode = 01102 OR c2.ProcCode = 01103) AND
										l2.ProcDate < l.ProcDate AND
                                        l2.ProcDate > (DATE_SUB(l.ProcDate,INTERVAL 1 YEAR)))";

            DataTable rawrecall = ReportsComplex.GetTable(command);

            Patient pat;
            String recalltype;

            for (int j = 0; j < rawrecall.Rows.Count; j++)
            {
                row = table.NewRow();
                pat = new Patient();

                recalltype = rawrecall.Rows[j]["Description"].ToString();
                if (recalltype == null || recalltype == "")
                {
                    recalltype = "Default";
                }
                pat.LName = rawrecall.Rows[j]["LName"].ToString();
                pat.FName = rawrecall.Rows[j]["FName"].ToString();
                pat.MiddleI = rawrecall.Rows[j]["MiddleI"].ToString();
                pat.Preferred = rawrecall.Rows[j]["Preferred"].ToString();

                row["Name"] = pat.GetNameLF();
                row["Gender"] = genderFormat(rawrecall.Rows[j]["Gender"].ToString());
                row["Age"] = birthdate_to_age(rawrecall.Rows[j]["Birthdate"].ToString());
                row["Type of Recall"] = recalltype;
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
