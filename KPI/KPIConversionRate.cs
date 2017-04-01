using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using OpenDentBusiness;
using OpenDental;

namespace KPIReporting.KPI
{
     public class KPIConversionRate
    {

        ///<summary>If not using clinics then supply an empty list of clinicNums. dateStart and dateEnd can be MinVal/MaxVal to indicate "forever".</summary>
        public static float GetConversionRate(DateTime dateStart, DateTime dateEnd, String pc)
        {
           // Find all procedures for that ProcCode
            string command = @"

                SELECT COUNT(*)
                FROM appointment a
                JOIN procedurelog pl ON pl.PlannedAptNum = a.NextAptNum 
                JOIN procedurecode x ON x.CodeNum = pl.CodeNum 
                WHERE x.ProcCode = " + "'" + POut.String(pc) + "'" + @" 
                    AND pl.DateTP BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @"";
            // Find procedures that have been planned.
            string command2 = @"
                SELECT COUNT(*)
                FROM appointment a
                JOIN procedurelog pl ON pl.PlannedAptNum = a.NextAptNum 
                JOIN procedurecode x ON x.CodeNum = pl.CodeNum 
                WHERE x.ProcCode = " + "'" + POut.String(pc) + "'" + @" 
                    AND pl.DateTP BETWEEN " + POut.DateT(dateStart) + @" AND " + POut.DateT(dateEnd) + @"
                    AND pl.AptNum = 0";


            DataTable raw = ReportsComplex.GetTable(command);
            DataTable raw2 = ReportsComplex.GetTable(command2);
            float returnval = 0;
            // No Procedures At All
           
               
                float TOTALPROCEDURES = float.Parse(raw.Rows[0]["COUNT(*)"].ToString());
                float PROCEDURESPLANNED = float.Parse(raw2.Rows[0]["COUNT(*)"].ToString());
                float TOTALCOUNTPROCEDURES = TOTALPROCEDURES + PROCEDURESPLANNED;
            if (TOTALCOUNTPROCEDURES == 0)
            {
                return 9999;
            }
            else { 
            System.Diagnostics.Debug.Write(TOTALCOUNTPROCEDURES);
                System.Diagnostics.Debug.Write(PROCEDURESPLANNED);

                //    (Count of all procedures - Count of Planned Procedures)  / Count of All Procedures
                //  Simply put:    (Count of procedures scheduled) / Count of All procedures          
                returnval = ((TOTALCOUNTPROCEDURES - PROCEDURESPLANNED) / TOTALCOUNTPROCEDURES) * 100;
                return (float) Math.Round(returnval, 2);

            }

        }




    }
}
