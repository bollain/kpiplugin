using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness
{
    public class StretchKPICustomForm
    {
        public static DataTable GetPatients(DateTime dateStart, DateTime dateEnd, string query)
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
            table.Columns.Add("Wireless Phone");
            table.Columns.Add("Email");
            // table.Columns.Add("Procedure Code");
            // table.Columns.Add("Treatment Planned");


            DataRow row;

            string command = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
            ";

            DataTable raw = ReportsComplex.GetTable(query);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();
                pat.MiddleI = raw.Rows[i]["MiddleI"].ToString();
                row["Name"] = pat.GetNameLF();
                pat.HmPhone = raw.Rows[i]["HmPhone"].ToString();
                pat.WkPhone = raw.Rows[i]["WkPhone"].ToString();
                pat.WirelessPhone = raw.Rows[i]["WirelessPhone"].ToString();
                pat.Email = raw.Rows[i]["Email"].ToString();

                row["PatNum"] = raw.Rows[i]["PatNum"].ToString();
                row["Home Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Work Phone"] = raw.Rows[i]["WkPhone"].ToString();
                row["Wireless Phone"] = raw.Rows[i]["WirelessPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();

                table.Rows.Add(row);
            }


            return table;

        }

        public static DataTable GetPatientsWithinDates(DateTime dateStart, DateTime dateEnd, string query)
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
            table.Columns.Add("Wireless Phone");
            table.Columns.Add("Email");
            // table.Columns.Add("Procedure Code");
            // table.Columns.Add("Treatment Planned");


            DataRow row;

            string command = @"
				SELECT DISTINCT p.PatNum, p.LName, p.FName, p.MiddleI, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
            ";

            DataTable raw = ReportsComplex.GetTable(query);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();
                pat.MiddleI = raw.Rows[i]["MiddleI"].ToString();
                // row["Name"]=pat.GetNameLF();
                row["Name"] = raw.Rows[i]["FName"].ToString() + " " + raw.Rows[i]["MiddleI"].ToString() +
                 ". " + raw.Rows[i]["LName"].ToString();
                pat.HmPhone = raw.Rows[i]["HmPhone"].ToString();
                pat.WkPhone = raw.Rows[i]["WkPhone"].ToString();
                pat.WirelessPhone = raw.Rows[i]["WirelessPhone"].ToString();
                pat.Email = raw.Rows[i]["Email"].ToString();

                row["PatNum"] = raw.Rows[i]["PatNum"].ToString();
                row["Home Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Work Phone"] = raw.Rows[i]["WkPhone"].ToString();
                row["Wireless Phone"] = raw.Rows[i]["WirelessPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();

                table.Rows.Add(row);
            }


            return table;

        }

    }
}
