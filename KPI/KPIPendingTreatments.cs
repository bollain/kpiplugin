using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI {
    public class KPIPendingTreatments
    {
        /*
        13.Pending treatment(patients waiting for appointment)
        List of all patients whose dental treatment has not been scheduled.This would not include
        procedure code 01202.Extract the information in Chart module/ Planned Appointment tab
        at the top right side of the screen – Report should extract for all patients with entries in this
        section of the chart - patient’s name and ID#, contact information, and procedures planned
        (will include procedure code and description).Note: If the treatment has been scheduled,
        there should not be an entry in the “Planned Appointment” section of the chart.

        */
        ///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetPendingTreatments(DateTime dateStart, DateTime dateEnd)
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
            table.Columns.Add("Procedure Code");
            table.Columns.Add("Treatment Planned");


            DataRow row;

            string command = @"
				SELECT p.PatNum, p.LName, p.FName, p.MiddleI, p.Gender, p.Zip, p.PriProv, 
                           p.HmPhone, p.WkPhone, p.WirelessPhone, p.Email, pc.Descript, pc.ProcCode 
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
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
                row["Name"] = pat.GetNameLF();
                pat.HmPhone = raw.Rows[i]["HmPhone"].ToString();
                pat.WkPhone = raw.Rows[i]["WkPhone"].ToString();
                pat.WirelessPhone  = raw.Rows[i]["WirelessPhone"].ToString();
                pat.Email = raw.Rows[i]["Email"].ToString();

                row["Home Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Work Phone"] = raw.Rows[i]["WkPhone"].ToString();
                row["Wireless Phone"] = raw.Rows[i]["WirelessPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();

                row["Procedure Code"] = raw.Rows[i]["ProcCode"].ToString();
                row["Treatment Planned"] = raw.Rows[i]["Descript"].ToString();

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

        public static DataTable GetPendingTreatmentPats(DateTime dateStart, DateTime dateEnd)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("PatNum");
            table.Columns.Add("Name");
            table.Columns.Add("Home Phone");
            table.Columns.Add("Cell Phone");
            table.Columns.Add("Wireless Phone");
            table.Columns.Add("Email");


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

            DataTable raw = ReportsComplex.GetTable(command);
            Patient pat;
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                pat = new Patient();
                pat.LName = raw.Rows[i]["LName"].ToString();
                pat.FName = raw.Rows[i]["FName"].ToString();
                pat.MiddleI = raw.Rows[i]["MiddleI"].ToString();
                row["Name"] = raw.Rows[i]["FName"].ToString() + " " + raw.Rows[i]["MiddleI"].ToString() + 
                " " + raw.Rows[i]["LName"].ToString();
                pat.HmPhone = raw.Rows[i]["HmPhone"].ToString();
                pat.WkPhone = raw.Rows[i]["WkPhone"].ToString();
                pat.WirelessPhone = raw.Rows[i]["WirelessPhone"].ToString();
                pat.Email = raw.Rows[i]["Email"].ToString();

                row["PatNum"] = raw.Rows[i]["PatNum"];
                row["Home Phone"] = raw.Rows[i]["HmPhone"].ToString();
                row["Work Phone"] = raw.Rows[i]["WkPhone"].ToString();
                row["Cell Phone"] = raw.Rows[i]["WirelessPhone"].ToString();
                row["Email"] = raw.Rows[i]["Email"].ToString();

                table.Rows.Add(row);
            }


            return table;

        }

        public static DataTable GetPendingTreatmentProcsPerPat(DateTime dateStart, DateTime dateEnd, String patNum)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Procedure Code");
            table.Columns.Add("Treatment Planned");


            DataRow row;

            string command = @"
				SELECT  pc.Descript, pc.ProcCode 
                FROM procedurelog pl
                JOIN procedurecode pc ON pl.CodeNum = pc.CodeNum
                JOIN appointment a ON a.AptNum = pl.PlannedAptNum
                JOIN patient p ON a.PatNum = p.PatNum
                WHERE pl.AptNum = 0
                AND a.AptStatus = 6
                AND pc.ProcCode != 01202
                AND p.PatNum = '" + patNum + @"'
            ";

            DataTable raw = ReportsComplex.GetTable(command);
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                row["Procedure Code"] = raw.Rows[i]["ProcCode"].ToString();
                row["Treatment Planned"] = raw.Rows[i]["Descript"].ToString();

                table.Rows.Add(row);
            }


            return table;

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
