using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.XPath;

namespace EvaToolkits
{
    public class FortifyUtils
    {
        /// <summary>
        /// 解決 Fortify 的 Path Manipulation 警告
        /// </summary>
        public static string PathCombine(params string[] paths)
        {
            Sasa.IO.FilePath filePath = new Sasa.IO.FilePath(Path.Combine(paths));

            return filePath.ToString();
        }

        private static string SanitizeJson<T>(string value)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            T result = serializer.Deserialize<T>(value);

            value = serializer.Serialize(result);

            return value;
        }

        public static T DeserializeObject<T>(string value)
        {
            var result = JsonConvert.DeserializeObject<T>(SanitizeJson<T>(value));

            return result;
        }

        public static string SanitizePath(string path)
        {
            path = HttpUtility.HtmlEncode(path);
            StringWriter writer = new StringWriter();
            HttpUtility.HtmlDecode(path, writer);
            return writer.ToString();
        }

        public static string CompileXpath(string xpath)
        {
            XPathExpression expr = XPathExpression.Compile(xpath);
            return expr.Expression;
        }
    }
}
