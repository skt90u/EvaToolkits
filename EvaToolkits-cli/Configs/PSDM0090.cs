using SmasToolkit_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0090 : MasterPageGeneratorConfig
    {
        public PSDM0090()
        {
            this.Title = "宣導維護";
            this.PageId = "PSDM0090";
            this.DetailPageId = "PSDM0091";

            this.Buttons = Button.GetDefaultMasterPageButtons(this.DetailPageId);

            // 日期區間	檔案狀態
            this.QueryConditions.Add(new Date { Name = "DATE1", Desc = "日期", DbColumn = "EFF_DATE" });
            this.QueryConditions.Add(new Date { Name = "DATE2", Desc = "日期", DbColumn = "EXP_DATE" });
            Dictionary<string, string> DataSource = new Dictionary<string, string>();
            DataSource.Add("全部", "");
            DataSource.Add("啟用", "1");
            DataSource.Add("停用", "0");
            this.QueryConditions.Add(new RadioButtonList { Name = "STATUS", Desc = "狀態", DataSource = DataSource });

            SelectSqlGenerator selectSqlGenerator = new SelectSqlGenerator();
            selectSqlGenerator.TableName = "PSD_LED_PPT_ITEM";
            selectSqlGenerator.QueryConditions = this.QueryConditions;
            this.Sql = selectSqlGenerator.ToString();

                //            if (!string.IsNullOrEmpty(p_DATE1))
                //{
                //    sb.Append("        AND EFF_DATE >= :DATE1");
                //}
                //if (!string.IsNullOrEmpty(p_DATE2))
                //{
                //    sb.Append("        AND EXP_DATE <= :DATE2");
                //}
                //if (!string.IsNullOrEmpty(p_STATUS))
                //{
                //    sb.Append("        AND STATUS = :STATUS");

            this.OrderBy = "SEQ";

            this.Hidecolumn = new string[] { 
                "FILENAMES", 
                "FILEPATHS", 
                "CRT_ID", 
                "CRT_DATE", 
                "CRT_TIME", 
                "UPD_ID", 
                "UPD_DATE", 
                "UPD_TIME", 
            };

            this.DetailSql = "";
        }
    }
}
