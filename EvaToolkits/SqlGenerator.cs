using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits
{
    public class SqlGenerator
    {
        public static string GenFunction_GetDeleteSql(Type type, string primaryKey)
        {
            string tableName = type.Name;

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("        private string GetDeleteSql({0} data)", tableName);
            sb.AppendLine();

            sb.Append("{");
            sb.AppendLine();

            sb.AppendFormat("            return string.Format(\"DELETE FROM {0} WHERE {1} = '{{0}}'\", data.{1});", tableName, primaryKey);
            sb.AppendLine();

            sb.Append("}");
            sb.AppendLine();

            return sb.ToString();
        }

        public static string GenFunction_GetInsertSql(Type type)
        {
            string tableName = type.Name;
            List<string> fields = type.GetFields().Select(p => p.Name).ToList();
            
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("private string GetInsertSql({0} data)", tableName);
            sb.AppendLine();

            sb.Append("{");
            sb.AppendLine();

            sb.AppendFormat("	StringBuilder sb = new StringBuilder();");
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendFormat("	sb.AppendFormat(\"INSERT INTO {0} (\");", tableName);
            sb.AppendLine();

            for(int i=0; i<fields.Count; i++)
            {
                string field = fields[i];
                if (i == fields.Count - 1)
                {
                    sb.AppendFormat("	sb.AppendFormat(\"{0}  \");", field);
                }
                else
                {
                    sb.AppendFormat("	sb.AppendFormat(\"{0}, \");", field);
                }
                
                sb.AppendLine();
            }

            sb.AppendFormat("	sb.AppendFormat(\" ) \");");
            sb.AppendLine();

            sb.AppendFormat("	sb.AppendFormat(\"VALUES(\");");
            sb.AppendLine();

            for (int i = 0; i < fields.Count; i++)
            {
                string field = fields[i];
                if (i == fields.Count - 1)
                {
                    sb.AppendFormat("	sb.AppendFormat(\"'{{0}}'  \", data.{0});", field);
                }
                else
                {
                    sb.AppendFormat("	sb.AppendFormat(\"'{{0}}', \", data.{0});", field);
                }

                sb.AppendLine();
            }

            sb.AppendFormat("	sb.AppendFormat(\" ) \");");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendFormat("	return sb.ToString();");
            sb.AppendLine();

            sb.Append("}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
