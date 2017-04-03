using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using OpenDentBusiness;

namespace KPIReporting.KPI
{
    public class KPIDowntime
    {

        ///<summary> dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static DataTable GetDowntime(DateTime dateStart, DateTime dateEnd)
        {
            if (RemotingClient.RemotingRole == RemotingRole.ClientWeb)
            {
                return Meth.GetTable(MethodBase.GetCurrentMethod(), dateStart, dateEnd);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Provider");
            table.Columns.Add("Provider Number");
            table.Columns.Add("Total Down-time");

            DataRow row;
            string command = @"
            
            SELECT  appointment.ProvNum , sec_to_time((sum((CHAR_LENGTH(appointment.Pattern) - CHAR_LENGTH(REPLACE(appointment.Pattern, 'X', ''))) ))*5*60)  AS DownTime
				FROM appointment 
                           
                WHERE EXISTS (	SELECT *
								FROM procedurelog
                                LEFT JOIN procedurecode ON (procedurecode.CodeNum = procedurelog.CodeNum)
                                WHERE procedurelog.AptNum = appointment.AptNum
								AND (procedurecode.ProcCode = 99999 OR procedurecode.ProcCode = 99998) 
                                )
                AND appointment.AptStatus = 5
				AND appointment.AptDateTime BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @"
                GROUP BY appointment.ProvNum";
            List<Provider> AllProviders = Providers.GetAll();
            Console.WriteLine(AllProviders.Count);
            DataTable raw = ReportsComplex.GetTable(command);
            for (int i = 0; i < raw.Rows.Count; i++)
            {
                row = table.NewRow();
                row["Provider"] = Providers.GetFormalName(PIn.Long(raw.Rows[i]["ProvNum"].ToString()));
                row["Provider Number"] = raw.Rows[i]["ProvNum"].ToString();
                row["Total Down-time"] = raw.Rows[i]["DownTime"].ToString();
                table.Rows.Add(row);
            }
            foreach (var provider in AllProviders)
            {
                DataRow[] inTable = table.Select(provider.ProvNum.ToString());
                if (inTable.Length == 0)
                {
                    row = table.NewRow();
                    row["Provider"] = Providers.GetFormalName(provider.ProvNum);
                    row["Provider Number"] = provider.ProvNum.ToString();
                    row["Total Down-time"] = "00:20:00";
                    table.Rows.Add(row);
                }
            }
            return table;
        }


    }
}
