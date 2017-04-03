using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;

namespace KPIReporting.KPI
{
    public class KPINonProductivePracticeTime
    {

        ///<summary> dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetNonProductivePracticeTime(DateTime dateStart, DateTime dateEnd)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Total Non-Productive Practice Time");
            table.Columns.Add("Patients with unrescheduled broken appointments");
            DataRow row;
            string command = @"
            SELECT  sec_to_time(sum(length(appointment.Pattern))*5*60) AS NonProdTime,count(distinct(appointment.PatNum)) AS NPPTBrokeAppt
				FROM appointment 
                LEFT JOIN patient ON (patient.PatNum = appointment.PatNum)
                
                WHERE EXISTS (	SELECT *
								FROM procedurelog 
                                LEFT JOIN procedurecode ON (procedurecode.CodeNum = procedurelog.CodeNum)
                                WHERE procedurelog.AptNum = appointment.AptNum
								AND (procedurecode.ProcCode = 99999 OR procedurecode.ProcCode = 99998) 
                              )
                AND appointment.AptStatus = 5 
				AND appointment.AptDateTime BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @"";

            DataTable raw = ReportsComplex.GetTable(command);
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                row["Total Non-Productive Practice Time"] = raw.Rows[i]["NonProdTime"].ToString();
                row["Patients with unrescheduled broken appointments"] = raw.Rows[i]["NPPTBrokeAppt"].ToString();
                table.Rows.Add(row);
            }
            return table;
        }


    }
}

