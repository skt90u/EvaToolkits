using SmasToolkit_v2.Generator.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class DalGenerator : IGenerator
    {
        private DalGeneratorConfig config;

        public DalGenerator(DalGeneratorConfig config) 
        {
            this.config = config;
        }

        public void Build(string dirPath)
        {
            DalTemplate tpl = new DalTemplate();

            tpl.Session = new Dictionary<string, object>();
            tpl.Session.Add("config", config);
            tpl.Initialize();

            var contents = tpl.TransformText();

            Utils.WriteAllText(contents, dirPath, config.TableName + ".cs");
        }
    }
}
