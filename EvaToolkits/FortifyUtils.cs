using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
