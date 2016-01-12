using SmasToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0081 : DetailPageGeneratorConfig
    {
        public PSDM0081()
        {
            this.PageId = "PSDM0081";
            this.Title = "TODO";
            this.TableName = "PSD_LEADTIME_INFO";

            this.Buttons.Add(new Button(ButtonTypes.btnSave, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnDELETE, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnCLEAR, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnHelp, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnExit, "~/PSD/PSDM0080.aspx"));

            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "ITEM", Desc = "作業項目", IsRequired = true, IsPrimaryKey = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "DESCRIPTION", Desc = "說明描述", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "ADMIN", Desc = "負責單位", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "UPD_ID", Desc = "更新者" });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "UPD_DATE", Desc = "更新日期" });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "UPD_TIME", Desc = "更新時間" });
        }
    }

    /*
      <data name="ITEM" xml:space="preserve">
        <value>作業項目</value>
      </data>
      <data name="ADMIN" xml:space="preserve">
        <value>負責單位</value>
      </data>  
     * 

    */
}
