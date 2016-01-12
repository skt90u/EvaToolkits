using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class DatabaseHelper
    {
        private const string DefaultConnectionString = "Provider=OraOLEDB.Oracle; Data Source=SMAST; User Id=UATTEST; Password=p35SMAST082;Pooling = false;";

        private readonly string connectionString;

        public DatabaseHelper(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public DatabaseHelper() : this(DefaultConnectionString){}

        public List<string> GetPrimaryKeys(string tableName)
        {
            List<string> result = new List<string>();
            
            DataTable dt = Query(string.Format("SELECT COLUMN_NAME FROM user_cons_columns WHERE TABLE_NAME = '{0}'", tableName));

            foreach (DataRow row in dt.Rows)
                result.Add(GetFieldStr(row, "COLUMN_NAME"));

            return result;
        }

        public DataTable Query(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                throw new ArgumentNullException("sql");

            DataSet result = new DataSet();

            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            adapter.Fill(result);

            conn.Close();

            return result.Tables[0];
        }

        /// <summary>
        /// 在DataRow中，取得指定的Column數值，並將之轉換成字串
        /// 
        /// 如果為NULL，回傳空字串
        /// 如果不為NULL，轉換成字串，並TRIM掉左右兩邊多餘空格
        /// </summary>
        public static string GetFieldStr(DataTable dataTable, int index, string columnName)
        {
            return GetFieldStr(dataTable.Rows[index], columnName);
        }

        public static string GetFieldStr(DataRow row, string columnName)
        {
            object obj = GetField(row, columnName);

            return obj == null ? string.Empty : obj.ToString().Trim();
        }


        public static object GetField(DataRow row, string columnName)
        {
            if (row == null)
                throw new ArgumentNullException("row");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException("columnName");

            DataTable dataTable = row.Table;

            if (!dataTable.Columns.Contains(columnName))
                throw new Exception(string.Format("ColumnNotFound({0})", columnName));

            return row[columnName];
        }

        public static object GetField(DataTable dataTable, int index, string columnName)
        {
            if (dataTable == null)
                throw new ArgumentNullException("dataTable");

            if ((index < 0) || (index >= dataTable.Rows.Count))
                throw new ArgumentOutOfRangeException(string.Format("index, (index: {0}, Count: {1})", index, dataTable.Rows.Count));

            return GetField(dataTable.Rows[index], columnName);
        }

        public List<string> GetColumnNames(string tableName)
        {
            DataTable dt = Query(string.Format("SELECT * FROM {0} WHERE 1 = 0", tableName));

            List<string> result = new List<string>();

            foreach (DataColumn column in dt.Columns)
            {
                EvaToolkits.Logger.D(column.ColumnName);
                EvaToolkits.Logger.D(column.DataType.ToString());
                result.Add(column.ColumnName);
            }

            return result;
        }
    }
}
