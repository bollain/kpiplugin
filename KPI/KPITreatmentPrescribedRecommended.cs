using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;
using OpenDental;
using KPIReporting.KPI;

namespace KPIReporting.KPI
{
     public class KPIRecTreatment
    {

        ///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetRecTreatmentYYY(DateTime dateStart, DateTime dateEnd, long pnum, String pc)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND "+ POut.DateT(dateEnd)+ @"
                       AND rc.ProcCode = " + "'" + POut.String(pc) + "'" + @"
                       AND p.PatNum = " + POut.Long(pnum) + @"
                ORDER BY r.ProcDate";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentYYN(DateTime dateStart, DateTime dateEnd, long pnum)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND "+ POut.DateT(dateEnd)+ @"
                      AND  p.PatNum = " + POut.Long(pnum) + @"
                ORDER BY r.ProcDate";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentYNY(DateTime dateStart, DateTime dateEnd, String pc)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND "+ POut.DateT(dateEnd)+ @"
                       AND rc.ProcCode = " + "'" + POut.String(pc) + "'" + @"
                ORDER BY r.ProcDate";


            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentYNN(DateTime dateStart, DateTime dateEnd)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE r.ProcDate BETWEEN " + POut.DateT(dateStart) + @" AND "+ POut.DateT(dateEnd)+ @"
                ORDER BY r.ProcDate";

            System.Diagnostics.Debug.WriteLine(command);

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentNNN()
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod());
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                ORDER BY r.ProcDate";
            System.Diagnostics.Debug.WriteLine(command);

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }
        // finish these queries.
        public static DataTable GetRecTreatmentNYY(long pnum, String pc)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod());
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE rc.ProcCode = " + "'" + POut.String(pc) + "'" + @" AND p.PatNum = " + POut.Long(pnum) + @"
                ORDER BY r.ProcDate";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentNYN(long pnum)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod());
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE p.PatNum = " + POut.Long(pnum) + @"
                ORDER BY r.ProcDate";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable GetRecTreatmentNNY(String pc)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod());
            }
            DataTable table = new DataTable();
            table.Columns.Add("Date of Service");
            table.Columns.Add("Name");
            table.Columns.Add("Procedure");
            table.Columns.Add("Priority");
            table.Columns.Add("Status of Pre-Authorization");


            DataRow row;
            string command = @"
				SELECT r.ProcDate, p.LName, p.FName, p.MiddleI, rc.ProcCode, tpa.Priority, r.ProcStatus
                FROM patient p
                JOIN procedurelog r ON r.PatNum = p.PatNum
                JOIN treatplan t ON t.PatNum = p.PatNum
                JOIN treatplanattach tpa ON tpa.ProcNum = r.ProcNum AND tpa.TreatPlanNum = t.TreatPlanNum
                JOIN procedurecode rc ON rc.CodeNum = r.CodeNum
                WHERE rc.ProcCode = " + "'" + POut.String(pc) + "'" + @"
                ORDER BY r.ProcDate";

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();

                row["Date of Service"] = raw.Rows[i]["ProcDate"].ToString().Substring(0, 10);
                row["Name"] = pat.GetNameLF();
                row["Procedure"] = raw.Rows[i]["ProcCode"].ToString();
                row["Priority"] = raw.Rows[i]["Priority"].ToString();
                row["Status of Pre-Authorization"] = raw.Rows[i]["ProcStatus"];
                table.Rows.Add(row);
            }
            return table;
        }



    }
}
