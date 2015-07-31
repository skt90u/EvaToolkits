using SmasToolkit_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0091 : DetailPageGeneratorConfig
    {
        public PSDM0091()
        {
            this.ParentPageId = "PSDM0090";
            this.PageId = "PSDM0091";
            this.Title = "TODO";
            this.TableName = "PSD_LED_PPT_ITEM";

            this.Buttons = Button.GetDefaultDetailButtons(this.ParentPageId);

            this.Columns.Add(new TextBox { Name = "SEQ", Desc = "序號", IsPrimaryKey = true });
            this.Columns.Add(new Date { Name = "EFF_DATE", Desc = "日期區間", IsRequired = true });
            this.Columns.Add(new Date { Name = "EXP_DATE", Desc = "日期區間", IsRequired = true });
            this.Columns.Add(new TextBox { Name = "DESCRIPTION", Desc = "標題", IsRequired = true });
            Dictionary<string, string> DataSource = new Dictionary<string, string>();
            DataSource.Add("啟用", "1");
            DataSource.Add("停用", "0");
            this.Columns.Add(new RadioButtonList { Name = "STATUS", Desc = "狀態", IsRequired = true, DataSource = DataSource });
            this.Columns.Add(new RadioButtonList { Name = "FILENAMES", Desc = "檔名" });
            this.Columns.Add(new TextBox { Name = "FILEPATHS", Desc = "檔案上傳", IsRequired = true });
            this.Columns.Add(new TextBox { Name = "UPD_ID", Desc = "更新者" });
            this.Columns.Add(new TextBox { Name = "UPD_DATE", Desc = "更新日期" });
            this.Columns.Add(new TextBox { Name = "UPD_TIME", Desc = "更新時間" });
        }
    }
}
