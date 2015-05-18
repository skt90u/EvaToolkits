using gudusoft.gsqlparser;
using SmasToolkit_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace EvaToolkits_cli
{
/*
            // HACK: 要調整的地方
            // UNDONE: 還沒做完的地方
            // TODO: 要做的事情
			
			
//+	'+	Large size	Normal text color, large size
//++	'++	Extra large zie	Normal text color, extra large size

//!	'!	Important comment	Red text color
//!+	'!+	Important comment, large	Red text color, large size
//!++	'!++	Important comment, extra large	Red text color, extra large size

//?	'?	Question	Magenta text color
//?+	'?+	Question, large	Magenta text color, large size
//?++	'?++	Question, extra large	Magenta text color, extra large size
//x	'x	Removed code	Light gray color, strikethrough			
*/
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> b = a.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            //string c = b[0];
            //Console.WriteLine(c);
            return;
            PageGenerator generator = new PageGenerator(new PSDM0090(), new PSDM0091());
            generator.Build(@"C:\GeneratorResult");

            //SmasToolkit_v2.PageGenerator.UT();

            //string input = @"C:\formatMe.sql";
            //string output = @"C:\formatMe.Result.sql";
            //SmasToolkit_v2.Utils.FormatSql(input, output);
        }
    }
}
