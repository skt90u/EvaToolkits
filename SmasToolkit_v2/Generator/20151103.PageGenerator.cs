using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class PageGenerator : IGenerator
    {
        public static void UT()
        {
            #region MasterPageGeneratorConfig
            MasterPageGeneratorConfig masterConfig = new MasterPageGeneratorConfig();

            masterConfig.Title = "貴賓室現場流通量設定";
            masterConfig.PageId = "OUTM0150";
            masterConfig.DetailPageId = "OUTM0151";

            masterConfig.Buttons = Button.GetDefaultMasterPageButtons(masterConfig.DetailPageId);

            masterConfig.QueryConditions.Add(new TextBox { Name = "CODE1", Desc = "料號一" });
            masterConfig.QueryConditions.Add(new TextBox { Name = "CODE2", Desc = "料號二" });

            masterConfig.Sql = "SELECT 	CODE, 	DESCRIPTION, 	QTY, 	CRT_ID, 	CRT_DATE, 	CRT_TIME, 	UPD_ID, 	UPD_DATE, 	UPD_TIME FROM 	OUT_VIP_FLOATING_SETTING WHERE 1=1 AND CODE >= :CODE1 AND CODE <= :CODE2";
            masterConfig.OrderBy = "CODE";

            masterConfig.Hidecolumn = new string[] { 
                "CRT_ID", 
                "CRT_DATE", 
                "CRT_TIME", 
                "UPD_ID", 
                "UPD_DATE", 
                "UPD_TIME", 
            };

            masterConfig.DetailSql = "";
            #endregion

            #region DetailPageGeneratorConfig

            DetailPageGeneratorConfig detailConfig = new DetailPageGeneratorConfig();

            detailConfig.ParentPageId = "OUTM0150";
            detailConfig.PageId = "OUTM0151";
            detailConfig.Title = "貴賓室現場流通量設定";
            detailConfig.TableName = "OUT_VIP_FLOATING_SETTING";

            detailConfig.Buttons = Button.GetDefaultDetailButtons(detailConfig.ParentPageId);

            detailConfig.Columns.Add(new TextBox { Name = "SEQ", Desc = "序號", IsPrimaryKey = true });
            detailConfig.Columns.Add(new TextBox { Name = "CODE", Desc = "料號" });
            detailConfig.Columns.Add(new TextBox { Name = "DESCRIPTION", Desc = "物品描述" });
            detailConfig.Columns.Add(new TextBox { Name = "QTY", Desc = "現場流通量" });

            #endregion

            PageGenerator generator = new PageGenerator(masterConfig, detailConfig);

            generator.Build(@"C:\GeneratorResult");
        }

        private MasterPageGeneratorConfig masterConfig;
        private DetailPageGeneratorConfig detailConfig;

        public PageGenerator(
            MasterPageGeneratorConfig masterConfig,
            DetailPageGeneratorConfig detailConfig)
        {
            this.masterConfig = masterConfig;
            this.detailConfig = detailConfig;
        }

        public void Build(string dirPath)
        {
            List<IGenerator> generators = new List<IGenerator>();

            generators.Add(new MasterPageGenerator(masterConfig, detailConfig));
            generators.Add(new DetailPageGenerator(masterConfig, detailConfig));

            foreach (var generator in generators)
                generator.Build(dirPath);
        }
    }
}
