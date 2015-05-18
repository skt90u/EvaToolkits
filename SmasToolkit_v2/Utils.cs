using gudusoft.gsqlparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public static class Utils
    {
        public static void MakeSureDirExists(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
        }

        public static void WriteAllText(string contents, params string[] paths)
        {
            string path = Path.Combine(paths);

            MakeSureDirExists(Path.GetDirectoryName(path));
            
            File.WriteAllText(path, contents);
        }

        public static string GetPageCategory(string pageId)
        {
            // pageId = BASM0020
            // pageIdNoNumber = BASM
            // category = BAS

            string pageIdNoNumber = Regex.Replace(pageId, @"[\d-]", string.Empty);

            string category = pageIdNoNumber.Substring(0, pageIdNoNumber.Length > 3 ? 3 : pageIdNoNumber.Length);

            return category;
        }

        #region SQL Utils

        /// <summary>
        /// 檢測SQL語法是否正確
        /// </summary>
        public static void ValidateSql(string sql)
        {
            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            int ret = sqlparser.Parse();
            if (ret != 0)
                throw new Exception(sqlparser.ErrorMessages);
        }

        public static string GenerateDoesDataAlreadyExistSql(string tableName, List<IHtmlTag> columns)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" SELECT");
            sb.AppendFormat(" *");
            sb.AppendFormat(" FROM {0} WHERE 1 = 1", tableName);

            var whereConditions = columns.Where(col => col.IsPrimaryKey).ToList();

            for (var i = 0; i < whereConditions.Count; i++)
            {
                var column = columns[i];

                sb.AppendFormat("AND {0} = :{0} ", column.Name);
            }

            return sb.ToString();
        }

        public static string GenerateFetchDataSql(MasterPageGeneratorConfig masterConfig, DetailPageGeneratorConfig detailConfig)
        {
            List<IHtmlTag> Columns = detailConfig.Columns;
            string TableName = detailConfig.TableName;
            string MasterSql = masterConfig.Sql;

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" SELECT");

            for (var i = 0; i < Columns.Count; i++)
            {
                var column = Columns[i];

                if (i != Columns.Count - 1)
                {
                    sb.AppendFormat(" {0} AS {1},", column.Name, column.GetInputId());
                }
                else
                {
                    sb.AppendFormat(" {0} AS {1}", column.Name, column.GetInputId());
                }
            }

            sb.AppendFormat(" FROM {0} WHERE 1 = 1", TableName);

            var MasterSqlFields = Utils.GetFields(MasterSql);

            for (var i = 0; i < MasterSqlFields.Count; i++)
            {
                var field = MasterSqlFields[i];

                sb.AppendFormat(" AND {0} = :{0}", field);
            }

            return sb.ToString();
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

            ValidateSql(sql);

            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            sqlparser.Parse();

            var fields = sqlparser.SqlStatements[0].Fields;

            foreach (TLzField fd in fields)
            {
                string text1 = fd.AsText;
                int idx = text1.IndexOf("AS", StringComparison.CurrentCultureIgnoreCase);
                string text2 = text1.Substring(idx + 2 /* AS */);
                retVal.Add(text2.Trim());

                //retVal.Add(fd.AsText);
            }

            return retVal;
        }

        #endregion
        

        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static IHtmlTag GetMatchedQueryCondition(string aSqlLine, List<IHtmlTag> queryConditions)
        {
            foreach (var queryCondition in queryConditions)
            {
                if (aSqlLine.Contains(":" + queryCondition.Name))
                    return queryCondition;
            }

            return null;
        }

        

        public static bool GetWritablity(string action, IHtmlTag column)
        {
            bool writable = false;
            string Name = column.Name;
            bool IsPrimaryKey = column.IsPrimaryKey;

            switch (action)
            {
                case "ADD":
                    writable = !(Name == "UPD_ID" || Name == "UPD_DATE" || Name == "UPD_TIME") &&
                               !IsPrimaryKey;
                    break;
                case "UPD":
                    writable = !(Name == "UPD_ID" || Name == "UPD_DATE" || Name == "UPD_TIME") &&
                               !IsPrimaryKey;
                    break;
                case "DEL":
                    writable = false;
                    break;
                case "COPY":
                    writable = !(Name == "UPD_ID" || Name == "UPD_DATE" || Name == "UPD_TIME") &&
                               !IsPrimaryKey;
                    break;
                case "QRY":
                    writable = false;
                    break;
            }

            return writable;
        }

        public static string GetInitValue(string action, IHtmlTag column)
        {
            string initValue = string.Empty;
            string Name = column.Name;
            bool IsPrimaryKey = column.IsPrimaryKey;

            switch (action)
            {
                case "ADD":
                case "COPY":
                    {
                        switch (Name)
                        {
                            case "SEQ":
                                initValue = "GetNextVal()";
                                break;
                            case "UPD_ID":
                                initValue = "OnUser.ID";
                                break;
                            case "UPD_DATE":
                                initValue = "SystemDate";
                                break;
                            case "UPD_TIME":
                                initValue = "SystemTime";
                                break;
                        }
                    } break;
            }

            return initValue;
        }

        public static void FormatSql(string input, string output)
        {
            if (!System.IO.File.Exists(input))
                return;

            StringBuilder sb = new StringBuilder();
            foreach (string line in System.IO.File.ReadAllLines(input))
            {
                sb.Append(line);
                sb.Append(" ");
            }

            string sql = sb.ToString();

            if (System.IO.File.Exists(output))
                System.IO.File.Delete(output);

            //             sb.AppendFormat("

            foreach (string line in Utils.GetFormattedSqlLines(sql))
            {
                string str = string.Format("             sb.AppendFormat(\" {0}\");\r\n", line);
                System.IO.File.AppendAllText(output, str);
            }
        }
    }
}
