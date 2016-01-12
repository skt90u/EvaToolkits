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

            detailConfig.ParentPageId = "PSDM0070";
            detailConfig.PageId = "PSDM0071";
            detailConfig.Title = "TODO";
            detailConfig.TableName = "PSD_LEADTIME_ITEM";

            detailConfig.Buttons = Button.GetDefaultDetailButtons(detailConfig.ParentPageId);

            detailConfig.Columns.Add(new TextBox { Name = "SEQ", Desc = "序號", IsPrimaryKey = true });
            detailConfig.Columns.Add(new RadioButtonList { Name = "STATUS", Desc = "狀態", IsRequired = true });
            detailConfig.Columns.Add(new Date { Name = "EFF_DATE", Desc = "日期區間", IsRequired = true });
            detailConfig.Columns.Add(new Date { Name = "EXP_DATE", Desc = "日期區間", IsRequired = true });
            detailConfig.Columns.Add(new CheckBoxList { Name = "AC_TYPE", Desc = "機型", IsRequired = true });
            detailConfig.Columns.Add(new DropDownList { Name = "ITEM", Desc = "作業項目", IsRequired = true });
            detailConfig.Columns.Add(new DropDownList { Name = "LEADTIME", Desc = "距班機起飛時間", IsRequired = true });
            detailConfig.Columns.Add(new TextBox { Name = "UPD_ID", Desc = "更新者" });
            detailConfig.Columns.Add(new TextBox { Name = "UPD_DATE", Desc = "更新日期" });
            detailConfig.Columns.Add(new TextBox { Name = "UPD_TIME", Desc = "更新時間" });

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
