using com.think4u.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class dbAccessLite
    {
        private string databaseId;
    
        public dbAccessLite():this("default"){}

        public dbAccessLite(string databaseId)
        {
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentNullException("databaseId");

            this.databaseId = databaseId;
        }

        public DataSet runExecuteQuery(string dtname, string sql)
        {
            if (string.IsNullOrEmpty(dtname))
                throw new ArgumentNullException("tableName");

            if (string.IsNullOrEmpty(sql))
                throw new ArgumentNullException("sql");

            string connectionString = GetConnectionString(databaseId);

            DataSet result = new DataSet();
            DataTable dtInfo = createReturnInfo("info");
            result.Tables.Add(dtInfo);

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    using (OracleDataAdapter adapter = new OracleDataAdapter(sql, conn))
                    {
                        adapter.Fill(result, dtname);

                        DataTable dt = result.Tables[dtname];
                        if (dt.Rows.Count <= 0)
                        {
                            setReturnInfo(dtInfo, dtname, NODATA_CODE, 0, "");
                        }
                        else
                        {
                            setReturnInfo(dtInfo, dtname, SUCCESS_CODE, 0, "", dt.Rows.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                setReturnInfo(dtInfo, dtname, ERROR_CODE, 0, ex.Message);
            }

            return result;
        }

        private string GetConnectionString(string databaseId)
        {
            dbConnection dbConnection = new dbConnection(databaseId, @"C:\dbConfig.XML");

            System.Data.OracleClient.OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
            builder.DataSource = dbConnection.getDbName();
            builder.UserID = dbConnection.getId();
            builder.Password = dbConnection.getPassword();
            var a = builder.ConnectionString;
            
            return builder.ConnectionString;
        }

        #region Private Methods
        private const string SUCCESS_CODE = "000";
        private const string NODATA_CODE = "100";
        private const string ERROR_CODE = "999";

        private void setReturnInfo(DataTable dt, string dtname, string returnCode, int affected, string message)
        {
            setReturnInfo(dt, dtname, returnCode, affected, message, 0);
        }

        private void setReturnInfo(DataTable dt, string dtname, string returnCode, int affected, string message, int nRowCount)
        {
            DataRow dataRow = dt.NewRow();
            dataRow["TransResult"] = dtname;
            dataRow["ReturnCode"] = returnCode;
            dataRow["RecordsAffected"] = affected;
            dataRow["Message"] = ParseDBErrorMsg(message);
            dataRow["RowCount"] = nRowCount;
            dt.Rows.Add(dataRow);
            dt.AcceptChanges();
        }

        private string ParseDBErrorMsg(string errorMsg)
        {
            string str;
            try
            {
                int num = errorMsg.ToUpper().IndexOf("ORA-");
                if (num <= -1)
                {
                    str = errorMsg;
                }
                else
                {
                    int num1 = errorMsg.ToUpper().IndexOf(":", num);
                    string str1 = errorMsg.Substring(num, num1 - num);
                    try
                    {
                        //str = this.rm.GetString(str1) ?? errorMsg;
                        str = errorMsg;
                    }
                    catch (Exception exception)
                    {
                        str = exception.ToString();
                        str = errorMsg;
                    }
                }
            }
            catch (Exception exception1)
            {
                string message = exception1.Message;
                str = errorMsg;
            }
            return str;
        }

        private DataTable createReturnInfo(string dtname)
        {
            DataTable dataTable = new DataTable(dtname);
            DataColumn dataColumn = new DataColumn("TransResult", typeof(string));
            dataTable.Columns.Add(dataColumn);
            DataColumn dataColumn1 = new DataColumn("ReturnCode", typeof(string));
            dataTable.Columns.Add(dataColumn1);
            DataColumn dataColumn2 = new DataColumn("RecordsAffected", typeof(int));
            dataTable.Columns.Add(dataColumn2);
            DataColumn dataColumn3 = new DataColumn("Message", typeof(string));
            dataTable.Columns.Add(dataColumn3);
            DataColumn dataColumn4 = new DataColumn("RowCount", typeof(int))
            {
                DefaultValue = 0
            };
            dataTable.Columns.Add(dataColumn4);
            dataTable.AcceptChanges();
            return dataTable;
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                string sql = System.IO.File.ReadAllText(@"C:\1.SQL");
                dbAccessLite a = new dbAccessLite("FIS");
                var b = a.runExecuteQuery("aa", sql);

                
                var c = 0;
            }

            {
                dbConfig a = new dbConfig();
                a.setFileName(@"C:\Projects\EvaToolkits\ConsoleApplication1\lib\dbConfig.xml");
                var caa = a.init("UNIFIS");
                var b = a.getConnectionString();
                Console.WriteLine(b);
            }

            {
                dbConnection a = new dbConnection("UNIFIS", @"C:\Projects\EvaToolkits\ConsoleApplication1\lib\dbConfig.xml");
                var b = a.getConnectionString();
                Console.WriteLine(b);

//                System.Data.OracleClient.OracleConnectionStringBuilder builder =
//   new System.Data.OracleClient.OracleConnectionStringBuilder();
//builder["Data Source"] = "OracleDemo";
//builder["integrated Security"] = true;
//builder["User ID"] = "Mary;NewValue=Bad";
//System.Diagnostics.Debug.WriteLine(builder.ConnectionString);

                //OracleConnectionStringBuilder
            }

            {
                /*
string sql = System.IO.File.ReadAllText(@"C:\1.SQL");
                dbAccess a = new dbAccess("UNIFIS", @"C:\Projects\EvaToolkits\ConsoleApplication1\lib\dbConfig.xml");
                var b = a.runExecuteQuery("tableName", sql);
                //var c = b.Tables["tableName"];
                //var d = 0;

                dbConnection aa = new dbConnection("UNIFIS", @"C:\Projects\EvaToolkits\ConsoleApplication1\lib\dbConfig.xml");
                var bb = aa.getConnectionString();

                var oracleClientConnection = new OracleConnection(bb);
                //var oracleClientConnection = aa.getOracleClientConnection();
                oracleClientConnection.Open();
                try
                {
                    DataSet dataSet = new DataSet("dataset");
                    var oracleDataAdapter = new OracleDataAdapter(sql, oracleClientConnection);
                    oracleDataAdapter.Fill(dataSet, "dtname");
                    if (dataSet.Tables["dtname"].Rows.Count <= 0)
                    {
                        var s1 = 0;
                        //this.setReturnInfo(dataTable, dtname, "100", 0, "");
                    }
                    else
                    {
                        var s2 = 0;
                        //this.setReturnInfo(dataTable, dtname, "000", 0, "", dataSet.Tables[dtname].Rows.Count);
                    }
                }
                catch (Exception exception)
                {
                    
                }
                 */


            }
        }
    }
}
