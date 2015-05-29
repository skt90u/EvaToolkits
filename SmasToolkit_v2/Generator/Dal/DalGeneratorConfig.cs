using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class DalGeneratorConfig
    {
        public string TableName { get; set; }
        public List<string> ColumnNames = new List<string>();
        public List<string> PrimaryKeys = new List<string>();

        static DataTable GetSchemaTable(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }

        public DalGeneratorConfig(string connectionString, string tableName)
        {
            DatabaseHelper databaseHelper = new DatabaseHelper(connectionString);

            this.TableName = tableName;
            this.PrimaryKeys = databaseHelper.GetPrimaryKeys(tableName);
            this.ColumnNames = databaseHelper.GetColumnNames(tableName);

            for (int i = 0; i < ColumnNames.Count; i++)
            {
                var ColumnName = ColumnNames[i];

                

                if (PrimaryKeys.Contains(ColumnName))
                {
                }

                //WriteLine("public string {0} {{ get; set; }}", ColumnName);

                if ((i + 1) % 5 == 0)
                {
                    //WriteLine("");
                }
            }
        }

        
    }
}
