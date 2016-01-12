using SmasToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits_cli
{
    public class PSDM0080 : MasterPageGeneratorConfig
    {
        public PSDM0080()
        {
            this.PageId = "PSDM0080";

            this.Buttons.Add(new Button(ButtonTypes.btnSEARCH, string.Empty));
            this.Buttons.Add(new Button(ButtonTypes.btnADD, "~/PSD/PSDM0081.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnEDIT, "~/PSD/PSDM0081.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnDELETE, "~/PSD/PSDM0081.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnCOPY, "~/PSD/PSDM0081.aspx"));
            this.Buttons.Add(new Button(ButtonTypes.btnFIND, "~/PSD/PSDM0081.aspx"));

            this.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "ITEM", Desc = "作業項目" });

            this.ChkBox = false;
            this.Gridwidth = new string[] { "50%", "50%"};
            this.Hidecolumn = new string[] { 
                "DESCRIPTION", 
                "STATUS", 
                "CRT_ID", 
                "CRT_DATE", 
                "CRT_TIME", 
                "UPD_ID", 
                "UPD_DATE", 
                "UPD_TIME", 
            };
            this.TextAlign = new string[] { "L", "C"};

            //this.SearchSql = "SELECT * FROM PSD_LEADTIME_INFO WHERE ITEM = :ITEM";
            this.SearchSql = "SELECT ITEM, DESCRIPTION, ADMIN, CRT_ID, CRT_DATE, CRT_TIME, UPD_ID, UPD_DATE, UPD_TIME FROM PSD_LEADTIME_INFO WHERE ITEM = :ITEM";
            this.SearchSqlOrderBy = "ITEM";
            this.SearchDetailSql = "";

            //IGenerator generator = new MasterPageGenerator(this);
            //generator.Build(dir);

        }
    }
}
