using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SmasToolkit_v2
{
    public class SelectSqlGenerator
    {
        public List<IHtmlTag> QueryConditions = new List<IHtmlTag>();
        public string TableName { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentException("TableName");

            DatabaseHelper databaseHelper = new DatabaseHelper();

            DataTable dt = databaseHelper.Query(string.Format("SELECT * FROM {0}", TableName));

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT");

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn column = dt.Columns[i];

                if(i != dt.Columns.Count-1)
                    sb.AppendFormat(" {0},", column.ColumnName);
                else
                    sb.AppendFormat(" {0}", column.ColumnName);
            }

            sb.AppendFormat(" FROM {0}", TableName);
            sb.AppendFormat(" WHERE 1=1");

            foreach (IHtmlTag queryCondition in QueryConditions)
            {
                sb.AppendFormat(" AND {0} = :{1}", queryCondition.DbColumn, queryCondition.Name);
            }

            return sb.ToString();
        }
    }
}
