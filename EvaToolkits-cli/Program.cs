using gudusoft.gsqlparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using SmasToolkit_v2;
using SMAS.Cryptography;

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

    public class Item
    {
        public string a { get; set; }
        public string b { get; set; }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            //PageGenerator generator = new PageGenerator(new PSDM0090(), new PSDM0091());
            //generator.Build(@"C:\GeneratorResult");

            SmasToolkit_v2.PageGenerator.UT();

            //string input = @"C:\formatMe.sql";
            //string output = @"C:\formatMe.Result.sql";
            //SmasToolkit_v2.Utils.FormatSql(input, output);
        }
    }
}
