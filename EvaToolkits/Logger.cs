using gudusoft.gsqlparser;
using Gurock.SmartInspect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Data;
using System.Data.OleDb;	    // using OldDbConnection
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Xml;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Web;

namespace EvaToolkits
{
    public static class Logger
    {
        static Logger()
        {
            SiAuto.Si.Connections = "tcp()";
            SiAuto.Si.Enabled = true;
        }

        public static void LogSql(string dtname, string sql, ArrayList arrParam)
        {
            SiAuto.Main.LogMessage(dtname);

            sql = sql.Trim().ToUpper();

            string declareSQL = sql;

            if (arrParam != null)
            {
                foreach (OracleParameter param in arrParam)
                {
                    declareSQL = declareSQL.Replace(param.ParameterName.ToUpper(), string.Format("'{0}'", param.Value.ToString()));
                }
            }

            //foreach(string line in GetFormattedSqlLines(declareSQL))
            //    SiAuto.Main.LogMessage(line);


            SiAuto.Main.LogMessage(declareSQL);

            SiAuto.Main.LogMessage("");

            if (declareSQL.Contains(":"))
                SiAuto.Main.LogError(dtname);
        }

        public static void D(string message)
        {
            SiAuto.Main.LogMessage(message);
        }

        public static string GetFormattedSql(string sql)
        {
            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            sqlparser.PrettyPrint();

            return sqlparser.FormattedSqlText.Text;
        }

        public static List<string> GetFormattedSqlLines(string sql)
        {
            string formattedSql = GetFormattedSql(sql);

            return formattedSql.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
