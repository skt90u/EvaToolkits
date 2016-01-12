using SmasToolkit_v2.Generator.MasterPage;
using SmasToolkit_v2.Generator.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class ReportGenerator : IGenerator
    {
        private ReportConfig config;

        public ReportGenerator(ReportConfig config)
        {
            this.config = config;
        }

        public void Build(string dirPath)
        {
            Utils.MakeSureDirExists(dirPath);

            BuildAspx(dirPath);
            BuildJavascript(dirPath);
            BuildAspxCs(dirPath);
            BuildBLL(dirPath);
            BuildReport(dirPath);
        }

        private void BuildReport(string dirPath)
        {
            
        }

        private void BuildAspx(string dirPath)
        {
            Report_AspxTemplate tpl = new Report_AspxTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx");
        }

        private void BuildAspxCs(string dirPath)
        {
            Report_AspxCsTemplate tpl = new Report_AspxCsTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.PageId + ".aspx.cs");
        }

        private void BuildJavascript(string dirPath)
        {
            Report_JavascriptTemplate tpl = new Report_JavascriptTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "js", config.PageId + ".js");
        }

        private void BuildBLL(string dirPath)
        {
            Report_BLLTemplate tpl = new Report_BLLTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, "BLL", "BLL_" + config.PageId + ".cs");
        }
    }
}
