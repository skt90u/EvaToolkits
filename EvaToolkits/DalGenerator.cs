using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits
{
    public class DalGenerator
    {
        public DalGenerator(string filePath, string outputPath)
        {
            Parse(System.IO.File.ReadAllLines(filePath));

            Generate(outputPath);
        }
        private bool bracketL = false;
        private bool bracketR = false;
        private string tableName = null;
        private List<string> fields = new List<string>();

        private void Parse(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(tableName))
                {
                    ParseTableName(line);

                    continue;
                }

                string field = ParseField(line);
                if (field != null) fields.Add(field);
            }
        }

        private void Generate(string outptuPath)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("using System;");
            sb.AppendLine();
            sb.AppendFormat("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendFormat("using System.Data;");
            sb.AppendLine();
            sb.AppendFormat("using System.Linq;");
            sb.AppendLine();
            sb.AppendFormat("using System.Text;");
            sb.AppendLine();
            sb.AppendFormat("using System.Threading.Tasks;");
            sb.AppendLine();

            sb.AppendLine();

            sb.AppendFormat("namespace PSNF020");
            sb.AppendLine();
            sb.Append("{");
            sb.AppendLine();

            sb.AppendFormat("    internal class {0}", tableName);
            sb.AppendLine();
            sb.Append("    {");
            sb.AppendLine();

            for(int i=0; i<fields.Count; i++)
            {
                string field = fields[i].Trim();
                sb.AppendFormat("        public string {0};", field);
                sb.AppendLine();

                if((i+1)%5==0)
                    sb.AppendLine();
            }

            sb.AppendLine();

            sb.AppendFormat("        public {0}(DataRow row)", tableName);
            sb.AppendLine();
            sb.Append("        {");
            sb.AppendLine();

            for(int i=0; i<fields.Count; i++)
            {
                string field = fields[i].Trim();
                sb.AppendFormat("            {0} = DatabaseHelper.GetFieldStr(row, \"{0}\");", field);
                sb.AppendLine();

                if ((i + 1) % 5 == 0)
                    sb.AppendLine();
            }

            sb.Append("        }");
            sb.AppendLine();
            sb.Append("    }");
            sb.AppendLine();
            sb.Append("}");
            sb.AppendLine();

            System.IO.File.WriteAllText(outptuPath, sb.ToString());
        }

        private bool ParseTableName(string line)
        {
            if (line.StartsWith("CREATE TABLE"))
            {
                var tokens = line.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                tableName = tokens[tokens.Length - 1].Trim();

                return true;
            }

            return false;
        }

        private string ParseField(string line)
        {
            if (line == "(")
            {
                bracketL = true;
                return null;
            }

            if (line == ")")
            {
                bracketR = true;
                return null;
            }

            if (bracketL == false) return null;
            if (bracketR == true) return null;

            var tokens = line.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            return tokens[0].Trim();
        }
    }
}
/*
DROP TABLE SCS.PSN_OPEN_DATA_ORG CASCADE CONSTRAINTS;

CREATE TABLE SCS.PSN_OPEN_DATA_ORG
(
  EMPLOYEE_NO           VARCHAR2(6 BYTE)        NOT NULL,
  CHINESE_NAME          VARCHAR2(12 BYTE),
  ENGLISH_NAME          VARCHAR2(60 BYTE),
  NICKNAME              VARCHAR2(16 BYTE),
  COUNTER               NUMBER(3)               NOT NULL,
  EFFECTIVE_DATE        NUMBER(8)               NOT NULL,
  INEFFECTIVE_DATE      NUMBER(8)               NOT NULL,
  TRANS_MARK1           VARCHAR2(1 BYTE),
  TRANS_MARK2           VARCHAR2(1 BYTE),
  TRANS_MARK3           VARCHAR2(1 BYTE),
  TRANS_MARK4           VARCHAR2(1 BYTE),
  TRANS_MARK5           VARCHAR2(1 BYTE),
  TRANS_REASON          VARCHAR2(1 BYTE),
  COMPANY               VARCHAR2(5 BYTE),
  PART_TIME_COMPANY     VARCHAR2(5 BYTE),
  DEPARTMENT_12         VARCHAR2(12 BYTE),
  DEPARTMENT_PRINT_SEQ  VARCHAR2(10 BYTE),
  DEPTCODE1             VARCHAR2(3 BYTE),
  DEPTCODE2             VARCHAR2(3 BYTE),
  DEPTCODE3             VARCHAR2(3 BYTE),
  DEPTCODE4             VARCHAR2(3 BYTE),
  DEPARTMENT            VARCHAR2(4 BYTE),
  DEPARTMENT_4          VARCHAR2(4 BYTE),
  DEPT_DESC             VARCHAR2(60 BYTE),
  POSITION_CODE         VARCHAR2(3 BYTE),
  POSITION_DESC         VARCHAR2(36 BYTE),
  TRANS_STATUS          VARCHAR2(3 BYTE),
  TRANS_DESCRIPTION     VARCHAR2(16 BYTE),
  MANAGER               VARCHAR2(1 BYTE),
  POS_SEQ               NUMBER(3),
  EXT_NO                VARCHAR2(12 BYTE),
  BUILDING              VARCHAR2(20 BYTE),
  FLOOR                 VARCHAR2(3 BYTE),
  BUILD_CODE            VARCHAR2(4 BYTE),
  GROUP_CODE            VARCHAR2(5 BYTE),
  EMAIL                 VARCHAR2(87 BYTE),
  EMPLOYEE_NAME         VARCHAR2(77 BYTE),
  CRT_ID                VARCHAR2(15 BYTE),
  CRT_DATE              VARCHAR2(8 BYTE),
  CRT_TIME              VARCHAR2(6 BYTE)
)
TABLESPACE SCS_DATA1
RESULT_CACHE (MODE DEFAULT)
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
            FLASH_CACHE      DEFAULT
            CELL_FLASH_CACHE DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;
*/
