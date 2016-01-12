using SmasToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0071 : DetailPageGeneratorConfig
    {
        public PSDM0071()
        {
            this.PageId = "PSDM0071";
            this.Title = "TODO";
            this.TableName = "PSD_LEADTIME_ITEM";

            this.Buttons.Add(new Button(ButtonTypes.btnSave, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnDELETE, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnCLEAR, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnHelp, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnExit, "~/PSD/PSDM0070.aspx"));

            /*
  SEQ       VARCHAR2(10 BYTE),
  STATUS    VARCHAR2(1 BYTE),
  EFF_DATE  VARCHAR2(8 BYTE),
  EXP_DATE  VARCHAR2(8 BYTE),
  AC_TYPE   VARCHAR2(4 BYTE),
  ITEM      VARCHAR2(1024 BYTE),
  LEADTIME  VARCHAR2(6 BYTE),
  CRT_ID    VARCHAR2(15 BYTE),
  CRT_DATE  VARCHAR2(8 BYTE),
  CRT_TIME  VARCHAR2(6 BYTE),
  UPD_ID    VARCHAR2(15 BYTE),
  UPD_DATE  VARCHAR2(8 BYTE),
  UPD_TIME  VARCHAR2(6 BYTE)
             */
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "SEQ", Desc = "序號", IsPrimaryKey = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.RadioButtonList, Name = "STATUS", Desc = "狀態", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.Date, Name = "EFF_DATE", Desc = "日期區間", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.Date, Name = "EXP_DATE", Desc = "日期區間1", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.CheckBoxList, Name = "AC_TYPE", Desc = "機型", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.DropDownList, Name = "ITEM", Desc = "作業項目", IsRequired = true });
            this.Columns.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.DropDownList, Name = "LEADTIME", Desc = "距班機起飛時間"});
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
