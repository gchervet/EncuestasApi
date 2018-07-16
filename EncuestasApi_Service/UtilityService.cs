using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi_Service
{
    public class UtilityService
    {
        public static string GetHtmlStringFromDataset(DataSet dataSet)
        {
            try
            {
                string messageBody = "<font>Registro diario de alumnos que realizaron la encuesta: </font><br><br>";

                if (dataSet.Tables.Count < 1)
                    return "<font>Registro diario de alumnos que realizaron la encuesta: </font><font>No existen novedades de alumnos. </font><br><br>";
                if (dataSet.Tables[0].Rows.Count == 0)
                    return "<font>Registro diario de alumnos que realizaron la encuesta: </font><font>No existen novedades de alumnos. </font><br><br>";

                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        messageBody += htmlTdStart + column.ColumnName + htmlTdEnd;
                    }

                }

                messageBody += htmlHeaderRowEnd;

                foreach (DataRow Row in dataSet.Tables[0].Rows)
                {
                    messageBody = messageBody + htmlTrStart;
                    foreach (var item in Row.ItemArray)
                    {
                        messageBody = messageBody + htmlTdStart + item + htmlTdEnd;
                    }
                    messageBody = messageBody + htmlTrEnd;
                }

                messageBody = messageBody + htmlTableEnd;


                return messageBody;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
