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

            masterConfig.Title = "航行管制部作業手冊";
            masterConfig.PageId = "PSDM0070";
            masterConfig.DetailPageId = "PSDM0071";

            masterConfig.Buttons = Button.GetDefaultMasterPageButtons(masterConfig.DetailPageId);

            masterConfig.QueryConditions.Add(new DropDownList { Name = "ITEM", Desc = "作業項目" });
            masterConfig.QueryConditions.Add(new Date { Name = "DATE1", Desc = "日期" });
            masterConfig.QueryConditions.Add(new Date { Name = "DATE2", Desc = "日期" });
            masterConfig.QueryConditions.Add(new RadioButtonList { Name = "STATUS", Desc = "狀態" });
            masterConfig.QueryConditions.Add(new CheckBoxList { Name = "AC_TYPE", Desc = "機型" });

            masterConfig.Sql = "SELECT SEQ,STATUS,EFF_DATE,EXP_DATE,AC_TYPE,ITEM,LEADTIME,CRT_ID,CRT_DATE,CRT_TIME,UPD_ID,UPD_DATE,UPD_TIME   FROM PSD_LEADTIME_ITEM WHERE 1=1 AND ITEM = :ITEM AND EFF_DATE >= :DATE1 AND EXP_DATE <= :DATE2 AND STATUS = :STATUS AND AC_TYPE = :AC_TYPE";
            masterConfig.OrderBy = "SEQ";

            masterConfig.Hidecolumn = new string[] { 
                "SEQ", 
                "STATUS", 
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

            detailConfig.Buttons = Button.GetDefaultDetailageButtons(detailConfig.ParentPageId);

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
