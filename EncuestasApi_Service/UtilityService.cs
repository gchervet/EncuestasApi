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
                string messageBody = "<font>The following are the records: </font><br><br>";

                if (dataSet.Tables[0].Rows.Count == 0)
                    return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow Row in table.Rows)
                    {
                        messageBody += htmlTableStart;
                        messageBody += htmlHeaderRowStart;
                        messageBody += htmlTdStart + "ActualDate " + htmlTdEnd;
                        messageBody += htmlHeaderRowEnd;

                        messageBody = messageBody + htmlTrStart;
                        messageBody = messageBody + htmlTdStart + Row["DisplayVoucherNumber"] + htmlTdEnd;
                        messageBody = messageBody + htmlTrEnd;


                        messageBody = messageBody + htmlTrStart;
                        messageBody = messageBody + htmlTdStart + Row["AccountName"] + htmlTdEnd;
                        messageBody = messageBody + htmlTrEnd;
                    }
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
