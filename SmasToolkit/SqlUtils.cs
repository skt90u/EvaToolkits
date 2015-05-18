using gudusoft.gsqlparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public static class SqlUtils
    {
        public static string GenerateDoesDataAlreadyExistSql(DetailPageGeneratorConfig config)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" SELECT");
            sb.AppendFormat(" *");
            sb.AppendFormat(" FROM {0} WHERE", config.TableName);

            var columns = config.Columns.Where(col => col.IsPrimaryKey).ToList();
            for (var i = 0; i < columns.Count; i++)
            {
                var column = columns[i];

                if (i != columns.Count - 1)
                {
                    sb.AppendFormat(" {0} = :{0} AND", column.Name);
                }
                else
                {
                    sb.AppendFormat(" {0} = :{0}", column.Name);
                }
            }

            return sb.ToString();
        }

        public static string GenerateFetchDataSql(DetailPageGeneratorConfig config)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" SELECT");

            //foreach (var column in config.Columns)
            for(var i=0; i<config.Columns.Count; i++)
            {
                var column = config.Columns[i];

                if (i != config.Columns.Count - 1)
                {
                    sb.AppendFormat(" {0} AS {1},", column.Name, column.GetInputId());
                }
                else
                {
                    sb.AppendFormat(" {0} AS {1}", column.Name, column.GetInputId());
                }
            }

            sb.AppendFormat(" FROM {0} WHERE", config.TableName);

            var fields = SqlUtils.GetFields(config.MasterConfig.SearchSql);
            for (var i = 0; i < fields.Count; i++)
            {
                var field = fields[i];

                if (i != fields.Count - 1)
                {
                    sb.AppendFormat(" {0} = :{0} AND", field);
                }
                else
                {
                    sb.AppendFormat(" {0} = :{0}", field);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 檢測SQL語法是否正確
        /// </summary>
        public static void Validate(string sql)
        {
            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            int ret = sqlparser.Parse();
            if (ret != 0)
                throw new Exception(sqlparser.ErrorMessages);
        }

        // 格式化SQL
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

        /// <summary>
        /// 取得Field
        /// </summary>
        public static List<string> GetFields(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                throw new ArgumentException("sql");

            List<string> retVal = new List<string>();

            Validate(sql);

            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            sqlparser.Parse();

            var fields = sqlparser.SqlStatements[0].Fields;

            foreach (TLzField fd in fields)
            {
                retVal.Add(fd.AsText);
            }

            return retVal;
        }

          
    }
}
