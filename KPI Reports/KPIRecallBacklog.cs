using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenDentBusiness.KPI_Reports
{
    public class KPIRecallBacklog
    {
        public static DataTable GetRecallBacklog(DateTime dateStart, DateTime dateEnd)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod());
            }
            DataTable table=new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Gender");
            table.Columns.Add("Preferred Contact Method");
            table.Columns.Add("Phone");
            table.Columns.Add("Email");
            table.Columns.Add("Hygienist ID (Last appointment)");
            table.Columns.Add("Date of Last Recall");
            table.Columns.Add("Due Date");
            DataRow row;
            string command = @"
                SELECT p.LName, p.FName, p.MiddleI, p.Preferred, p.Gender, p.PreferContactMethod, p.HmPhone, p.Email, r.ProcDate, c.ProcCode, r.AptNum, a.ProvHyg, a.AptDateTime, q.DateDue
                FROM patient p 
	                INNER JOIN procedurelog r ON r.PatNum = p.PatNum
	                INNER JOIN procedureCode c ON r.CodeNum = c.CodeNum
                    INNER JOIN recall q ON p.PatNum = q.PatNum
                    INNER JOIN appointment a ON r.PatNum = a.PatNum  WHERE c.ProcCode=01202 AND a.AptStatus=6 AND
                    r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + 
                @" GROUP BY p.PatNUm";



            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();
                pat.MiddleI = raw.Rows[i]["MiddleI"].ToString();
                pat.Preferred = raw.Rows[i]["Preferred"].ToString();
                row["Name"] = pat.GetNameLF();
                row["Gender"] = genderFormat(raw.Rows[i]["Gender"].ToString());
                row["Preferred Contact Method"] = getContactMethod(raw.Rows[i]["PreferContactMethod"].ToString());
                row["Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();
                row["Hygienist ID (Last appointment)"] = raw.Rows[i]["ProvHyg"].ToString();
                row["Date of Last Recall"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Due Date"] = raw.Rows[i]["DateDue"].ToString().Substring(0, 10);
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

        ///<summary>Returns true if string matches ContactMethod enum names.</summary>
        private static string getContactMethod(string contactMethodName)
        {
            int contact = Int32.Parse(contactMethodName);
            string[] contactNames = Enum.GetNames(typeof(ContactMethod));

            return contactNames[contact];
        }

    }
}
