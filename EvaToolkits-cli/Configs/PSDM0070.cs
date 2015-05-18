using SmasToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0070 : MasterPageGeneratorConfig
    {
        public PSDM0070()
        {
            this.PageId = "PSDM0070";

            this.Buttons.Add(new Button(ButtonTypes.btnSEARCH, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnADD, "~/PSD/PSDM0071.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnEDIT, "~/PSD/PSDM0071.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnDELETE, "~/PSD/PSDM0071.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnCOPY, "~/PSD/PSDM0071.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnFIND, "~/PSD/PSDM0071.aspx"));

            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.DropDownList, Name = "ITEM", Desc = "作業項目" });
            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.Date, Name = "DATE1", Desc = "日期" });
            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.Date, Name = "DATE2", Desc = "日期" });
            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.RadioButtonList, Name = "STATUS", Desc = "狀態" });
            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.CheckBoxList, Name = "AC_TYPE", Desc = "機型" });

            this.ChkBox = false;
            this.Gridwidth = new string[] { "20%", "20%", "20%", "20%", "20%"};
            this.Hidecolumn = new string[] { 
                "SEQ", 
                "STATUS", 
                "CRT_ID", 
                "CRT_DATE", 
                "CRT_TIME", 
                "UPD_ID", 
                "UPD_DATE", 
                "UPD_TIME", 
            };
            this.TextAlign = new string[] { "L", "L", "L", "L", "L"};

            this.SearchSql = "SELECT SEQ,STATUS,EFF_DATE,EXP_DATE,AC_TYPE,ITEM,LEADTIME,CRT_ID,CRT_DATE,CRT_TIME,UPD_ID,UPD_DATE,UPD_TIME   FROM PSD_LEADTIME_ITEM WHERE ITEM = :ITEM AND EFF_DATE >= :DATE1 AND EXP_DATE <= :DATE2 AND STATUS = :STATUS AND AC_TYPE = :AC_TYPE";
            this.SearchSqlOrderBy = "SEQ";
            this.SearchDetailSql = "";

            //IGenerator generator = new MasterPageGenerator(this);
            //generator.Build(dir);

        }
    }
}
