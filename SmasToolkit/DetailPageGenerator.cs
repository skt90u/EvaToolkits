using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public class DetailPageGenerator : IGenerator
    {
        public static void UT()
        {
            DetailPageGeneratorConfig config = new DetailPageGeneratorConfig();

            config.PageId = "BASM0071";
            config.Title = "TODO";

            config.Buttons.Add(new Button(ButtonTypes.btnSave, string.Empty));
            config.Buttons.Add(new Button(ButtonTypes.btnDELETE, string.Empty));
            config.Buttons.Add(new Button(ButtonTypes.btnCLEAR, string.Empty));
            config.Buttons.Add(new Button(ButtonTypes.btnHelp, string.Empty));
            config.Buttons.Add(new Button(ButtonTypes.btnExit, "~/bas/BASM0070.aspx"));

            //config.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "DELIVERY_TYPE", Desc = "運送方式" });

            //config.Columns.Add(new HtmlControl(HtmlControlTypes.DropDownList, "DELIVERY_TYPE", "運送方式"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "FORWARDER_NO", "運輸代理商代號"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "COMPANY_NAME", "運輸代理商名稱"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "ADDRESS", "地址"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "TEL1", "電話1"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "TEL2", "電話2"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "FAX1", "傳真號碼1"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "FAX2", "傳真號碼2"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "E_MAIL1", "E-MAIL1"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "E_MAIL2", "E-MAIL2"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "PIC", "連絡人"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "UPD_ID", "更新者"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "UPD_DATE", "更新日期"));
            //config.Columns.Add(new HtmlControl(HtmlControlTypes.TextBox, "UPD_TIME", "更新時間"));

            IGenerator generator = new DetailPageGenerator(config);
            generator.Build(@"C:\GeneratorResult");
        }

        private DetailPageGeneratorConfig config;

        public DetailPageGenerator(DetailPageGeneratorConfig config)
        {
            this.config = config;
        }

        public void Build(string dirPath)
        {
            Utils.MakeSureDirExists(dirPath);

            //BuildBLL(dirPath);
            BuildJavascript(dirPath);
            BuildAspx(dirPath);
            BuildAspxCs(dirPath);
        }

        private void BuildAspx(string dirPath)
        {
            DetailPageGenerator_AspxTemplate tpl = new DetailPageGenerator_AspxTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx");
        }

        private void BuildAspxCs(string dirPath)
        {
            DetailPageGenerator_AspxCsTemplate tpl = new DetailPageGenerator_AspxCsTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx.cs");
        }

        private void BuildJavascript(string dirPath)
        {
            DetailPageGenerator_JavascriptTemplate tpl = new DetailPageGenerator_JavascriptTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "js", config.PageId + ".js");
        }

        private void BuildBLL(string dirPath)
        {
            DetailPageGenerator_BLLTemplate tpl = new DetailPageGenerator_BLLTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "BLL", "BLL_" + config.PageId + ".cs");
        }
    }
}
