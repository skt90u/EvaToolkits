using gudusoft.gsqlparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using SmasToolkit_v2;

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
    internal class PSN_OPEN_DATA_ORG
    {
        public string EMPLOYEE_NO;
        public string CHINESE_NAME;
        public string ENGLISH_NAME;
        public string NICKNAME;
        public string COUNTER;

        public string EFFECTIVE_DATE;
        public string INEFFECTIVE_DATE;
        public string TRANS_MARK1;
        public string TRANS_MARK2;
        public string TRANS_MARK3;

        public string TRANS_MARK4;
        public string TRANS_MARK5;
        public string TRANS_REASON;
        public string COMPANY;
        public string PART_TIME_COMPANY;

        public string DEPARTMENT_12;
        public string DEPARTMENT_PRINT_SEQ;
        public string DEPTCODE1;
        public string DEPTCODE2;
        public string DEPTCODE3;

        public string DEPTCODE4;
        public string DEPARTMENT;
        public string DEPARTMENT_4;
        public string DEPT_DESC;
        public string POSITION_CODE;

        public string POSITION_DESC;
        public string TRANS_STATUS;
        public string TRANS_DESCRIPTION;
        public string MANAGER;
        public string POS_SEQ;

        public string EXT_NO;
        public string BUILDING;
        public string FLOOR;
        public string BUILD_CODE;
        public string GROUP_CODE;

        public string EMAIL;
        public string EMPLOYEE_NAME;
        public string CRT_ID;
        public string CRT_DATE;
        public string CRT_TIME;

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new DalGeneratorConfig("Provider=OraOLEDB.Oracle; Data Source=SMAST; User Id=scs; Password=p35scs2015;Pooling = false;", "PSN_OPEN_DATA_ORG");

            DalGenerator g = new DalGenerator(cfg);
            g.Build(@"C:\GeneratorResult");

            return;
            EvaToolkits.DalGenerator sbas = new EvaToolkits.DalGenerator(@"C:\1.txt", @"C:\2.out");

            string txt = EvaToolkits.SqlGenerator.GenFunction_GetInsertSql(typeof(PSN_OPEN_DATA_ORG));
            System.IO.File.WriteAllText(@"C:\3.txt", txt);

            return;

            string linse = "  PART_TIME_COMPANY     VARCHAR2(5 BYTE),";
            var sss = linse.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            var sa = typeof(Program);
            var aa = sa.Name;
            //EvaToolkits.SqlGenerator

            //             EMPLOYEE_NO = DatabaseHelper.GetFieldStr(row, "EMPLOYEE_NO");
            // EMPLOYEE_NO

            /*
            sb.AppendFormat("VALUES(");
            sb.AppendFormat("'{0}', ", data.EMPLOYEE_NO);
            sb.AppendFormat("'{0}', ", data.CHINESE_NAME);
            sb.AppendFormat("'{0}', ", data.ENGLISH_NAME);
            sb.AppendFormat("'{0}', ", data.NICKNAME);
            sb.AppendFormat("'{0}', ", data.COUNTER);
            sb.AppendFormat("'{0}', ", data.EFFECTIVE_DATE);
            sb.AppendFormat("'{0}', ", data.INEFFECTIVE_DATE);
            sb.AppendFormat("'{0}', ", data.COMPANY);
            sb.AppendFormat("'{0}', ", data.DEPTCODE1);
            sb.AppendFormat("'{0}', ", data.DEPTCODE2);
            sb.AppendFormat("'{0}', ", data.DEPTCODE3);
            sb.AppendFormat("'{0}', ", data.DEPTCODE4);
            sb.AppendFormat("'{0}', ", data.DEPARTMENT_4);
            sb.AppendFormat("'{0}', ", data.DEPT_DESC);
            sb.AppendFormat("'{0}', ", data.POSITION_CODE);
            sb.AppendFormat("'{0}', ", data.POSITION_DESC);
            sb.AppendFormat("'{0}', ", data.MANAGER);
            sb.AppendFormat("'{0}'  ", data.POS_SEQ);
            sb.AppendFormat(" ) ");
             */
            foreach (string line in System.IO.File.ReadAllLines(@"C:\in.txt"))
            {
                string token = line.Trim();
                string output = string.Format("            sb.AppendFormat(\"'{{0}}', \", data.{0});", token);
                System.IO.File.AppendAllText(@"C:\out.txt", output + "\r\n");
            }

            string aaaaa = Path.GetTempFileName();

            return;

            SmasToolkit_v2.Utils.FormatSqlFile(@"C:\1.SQL", @"C:\2.SQL", "            sb.AppendFormat(\" ", "\");");

            return;

            string a = @"C:\GeneratorResult\..\..\js\PSDM0091.js";
            string aaa = @"C:\GeneratorResult\js\PSDM0091.js";

            Sasa.IO.FilePath f = new Sasa.IO.FilePath(aaa);

            Console.WriteLine(f.ToString());

            Console.WriteLine(Path.GetDirectoryName(a));

            return;
            var b = Path.GetDirectoryName(a);

            var c = Directory.EnumerateFiles(b);

            foreach (var d in c)
            {
                Console.WriteLine(d);
            }
            
            //List<string> b = a.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            //string c = b[0];
            //Console.WriteLine(c);
            return;
            //PageGenerator generator = new PageGenerator(new PSDM0090(), new PSDM0091());
            //generator.Build(@"C:\GeneratorResult");

            //SmasToolkit_v2.PageGenerator.UT();

            //string input = @"C:\formatMe.sql";
            //string output = @"C:\formatMe.Result.sql";
            //SmasToolkit_v2.Utils.FormatSql(input, output);
        }
    }
}
