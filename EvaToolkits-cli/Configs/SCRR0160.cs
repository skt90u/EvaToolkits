using SmasToolkit_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class SCRR0160 : ReportConfig
    {
        public class SqlDataSource
        {
            public SqlDataSource()
            {
                ExtraValues = new Dictionary<string, string>();
                DefaultValue = string.Empty;
            }

            public string Sql { get; set; }
            public string KeyName { get; set; }
            public string ValueName { get; set; }
            public Dictionary<string, string> ExtraValues { get; set; }
            public string DefaultValue { get; set; }
        }

        public SCRR0160()
        {
            this.PageId = "SCRR0160";
            this.Title = "機上免稅品新品圖";
            this.Buttons = Button.GetDefaultReportButtons();

            this.QueryConditions.Add(new Date { Name = "REQUEST_DATE_YM", Desc = "年月", DbColumn = "REQUEST_DATE_YM" });
            Dictionary<string, string> DataSource = new Dictionary<string, string>();
            DataSource.Add("W-酒類", "W");
            DataSource.Add("Y-菸類", "Y");
            DataSource.Add("P-化妝品類", "P");
            DataSource.Add("G-禮品類", "G");
            DataSource.Add("K-KITTY類", "K");
            DataSource.Add("L-LOGO類", "L");
            DataSource.Add("全部", "");
            this.QueryConditions.Add(new RadioButtonList { Name = "CLASS", Desc = "商品主類別", DataSource = DataSource });

            StringBuilder sb = new StringBuilder();
            sb.Append(" ");
            sb.Append(" SELECT * FROM PRE_PREORDER_MATERIAL WHERE CODE IN ");
            sb.Append(" (");
            sb.Append(" SELECT "); 
            sb.Append("     DISTINCT CODE ");
            sb.Append(" FROM ");
            sb.Append("     BAS_MATERIAL ");
            sb.Append(" WHERE ");
            sb.Append("     REQUEST_DATE BETWEEN '19000101' AND '19000131' ");
            sb.Append("     AND CLASS = :CLASS ");
            sb.Append(" )");

            this.Sql = sb.ToString();
        }
    }
}
