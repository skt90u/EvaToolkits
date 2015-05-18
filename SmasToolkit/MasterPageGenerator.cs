using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public partial class MasterPageGenerator : IGenerator
    {
        public static void UT()
        {
            MasterPageGeneratorConfig config = new MasterPageGeneratorConfig();

            config.PageId = "BASM9990";

            config.Buttons.Add(new Button(ButtonTypes.btnSEARCH, string.Empty));
            config.Buttons.Add(new Button(ButtonTypes.btnADD, "~/bas/BASM0061.aspx"));
            config.Buttons.Add(new Button(ButtonTypes.btnEDIT, "~/bas/BASM0061.aspx"));
            config.Buttons.Add(new Button(ButtonTypes.btnDELETE, "~/bas/BASM0061.aspx"));
            config.Buttons.Add(new Button(ButtonTypes.btnCOPY, "~/bas/BASM0061.aspx"));
            config.Buttons.Add(new Button(ButtonTypes.btnFIND, "~/bas/BASM0061.aspx"));

            config.QueryConditions.Add(new HtmlControl { HtmlControlType = HtmlControlTypes.TextBox, Name = "DELIVERY_TYPE", Desc = "運送方式" });

            config.ChkBox = false;
            config.Gridwidth = new string[] { "20%", "20%", "30%" };
            config.Hidecolumn = new string[] { };
            config.TextAlign = new string[] { "L", "C", "L" };

            config.SearchSql = "SELECT DELIVERY_TYPE, DESCRIPTION, RATE FROM BAS_TRANSPORT_CHARGE_RATE  WHERE STATUS <> '0' AND DELIVERY_TYPE=:DELIVERY_TYPE";
            config.SearchSqlOrderBy = "DELIVERY_TYPE";
            config.SearchDetailSql = " SELECT DELIVERY_TYPE,         DESCRIPTION,         RATE  FROM   BAS_TRANSPORT_CHARGE_RATE  WHERE  status <> '0'         AND DELIVERY_TYPE = :DELIVERY_TYPE ";

            IGenerator generator = new MasterPageGenerator(config);
            generator.Build(@"C:\GeneratorResult");
        }

        private MasterPageGeneratorConfig config;

        public MasterPageGenerator(MasterPageGeneratorConfig config)
        {
            this.config = config;
        }

        public void Build(string dirPath)
        {
            Utils.MakeSureDirExists(dirPath);

            BuildBLL(dirPath);
            BuildJavascript(dirPath);
            BuildAspx(dirPath);
            BuildAspxCs(dirPath);
        }

        private void BuildAspx(string dirPath)
        {
            MasterPageGenerator_AspxTemplate tpl = new MasterPageGenerator_AspxTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx");
        }

        private void BuildAspxCs(string dirPath)
        {
            MasterPageGenerator_AspxCsTemplate tpl = new MasterPageGenerator_AspxCsTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx.cs");
        }

        private void BuildJavascript(string dirPath)
        {
            MasterPageGenerator_JavascriptTemplate tpl = new MasterPageGenerator_JavascriptTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "js", config.PageId + ".js");
        }

        private void BuildBLL(string dirPath)
        {
            MasterPageGenerator_BLLTemplate tpl = new MasterPageGenerator_BLLTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "BLL", "BLL_" + config.PageId + ".cs");
        }
    }
}
