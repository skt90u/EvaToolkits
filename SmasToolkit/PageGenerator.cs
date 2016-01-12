using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public partial class PageGenerator : IGenerator
    {
        private MasterPageGeneratorConfig masterConfig;
        private DetailPageGeneratorConfig detailConfig;

        public PageGenerator(MasterPageGeneratorConfig masterConfig, DetailPageGeneratorConfig detailConfig) 
        {
            masterConfig.DetailConfig = detailConfig;
            detailConfig.MasterConfig = masterConfig;

            this.masterConfig = masterConfig;
            this.detailConfig = detailConfig;
        }

        public void Build(string dir)
        {
            new MasterPageGenerator(masterConfig).Build(dir);
            new DetailPageGenerator(detailConfig).Build(dir);
        }
    }
}
