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
        public string GetFieldStr(DataTable dataTable, int index, string columnName)
        {
            object obj = GetField(dataTable, index, columnName);

            return obj == null ? string.Empty : obj.ToString().Trim();
        }

        public object GetField(DataTable dataTable, int index, string columnName)
        {
            if (dataTable == null)
                throw new ArgumentNullException("dataTable");

            if ((index < 0) || (index >= dataTable.Rows.Count))
                throw new ArgumentOutOfRangeException(string.Format("index, (index: {0}, Count: {1})", index, dataTable.Rows.Count));

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException("columnName");

            if (!dataTable.Columns.Contains(columnName))
                throw new Exception(string.Format("ColumnNotFound({0})", columnName));

            return dataTable.Rows[index][columnName];
        }
    }
}
