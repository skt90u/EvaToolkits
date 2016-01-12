using SmasToolkit_v2.Generator.MasterPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class MasterPageGenerator : IGenerator
    {
        private MasterPageGeneratorConfig masterConfig;
        private DetailPageGeneratorConfig detailConfig;

        public MasterPageGenerator(
            MasterPageGeneratorConfig masterConfig,
            DetailPageGeneratorConfig detailConfig)
        {
            this.masterConfig = masterConfig;
            this.detailConfig = detailConfig;
        }

        public void Build(string dirPath)
        {
            Utils.MakeSureDirExists(dirPath);

            BuildAspx(dirPath);
            BuildJavascript(dirPath);
            BuildAspxCs(dirPath);
            BuildBLL(dirPath);
        }

        private void BuildAspx(string dirPath)
        {
            MasterPage_AspxTemplate tpl = new MasterPage_AspxTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, masterConfig.PageId + ".aspx");
        }

        private void BuildAspxCs(string dirPath)
        {
            MasterPage_AspxCsTemplate tpl = new MasterPage_AspxCsTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, masterConfig.PageId + ".aspx.cs");
        }

        private void BuildJavascript(string dirPath)
        {
            MasterPage_JavascriptTemplate tpl = new MasterPage_JavascriptTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "js", masterConfig.PageId + ".js");
        }

        private void BuildBLL(string dirPath)
        {
            MasterPage_BLLTemplate tpl = new MasterPage_BLLTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("masterConfig", masterConfig);
            tpl.Session.Add("detailConfig", detailConfig);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "BLL", "BLL_" + masterConfig.PageId + ".cs");
        }
    }
}
