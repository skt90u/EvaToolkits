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

namespace SmasToolkit
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

        public static void ValidateSql(string sql)
        {
            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);

            sqlparser.SqlText.Text = sql;

            int ret = sqlparser.Parse();
            if (ret != 0)
                throw new Exception(sqlparser.ErrorMessages);
        }

        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
