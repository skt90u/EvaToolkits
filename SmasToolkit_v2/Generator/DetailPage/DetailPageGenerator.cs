using SmasToolkit_v2.Generator.DetailPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class DetailPageGenerator : IGenerator
    {
        private MasterPageGeneratorConfig masterConfig;
        private DetailPageGeneratorConfig detailConfig;

        public DetailPageGenerator(
            MasterPageGeneratorConfig masterConfig,
            DetailPageGeneratorConfig detailConfig)
        {
            this.masterConfig = masterConfig;
            this.detailConfig = detailConfig;
        }

        public void Build(string dirPath)
        {
            Utils.MakeSureDirExists(dirPath);

            BuildAspxCs(dirPath);
            BuildAspx(dirPath);
            BuildJavascript(dirPath);
        }

        private void BuildAspx(string dirPath)
        {
            DetailPage_AspxTemplate tpl = new DetailPage_AspxTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, detailConfig.PageId + ".aspx");
        }

        private void BuildAspxCs(string dirPath)
        {
            DetailPage_AspxCsTemplate tpl = new DetailPage_AspxCsTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, detailConfig.PageId + ".aspx.cs");
        }

        private void BuildJavascript(string dirPath)
        {
            DetailPage_JavascriptTemplate tpl = new DetailPage_JavascriptTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "js", detailConfig.PageId + ".js");
        }
    }
}
