using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public class DetailPageGeneratorConfig
    {
        private MasterPageGeneratorConfig _MasterConfig;
        public MasterPageGeneratorConfig MasterConfig
        {
            get
            {
                return _MasterConfig;
            }
            set
            {
                _MasterConfig = value;
            }
        }

        public string ParentPageId
        {
            get
            {
                return MasterConfig.PageId;
            }
        }

        private string _PageId;
        public string PageId
        {
            get
            {
                return _PageId;
            }
            set
            {
                _PageId = value;
            }
        }

        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                //config.Columns
                // var data = JSON.stringify({ p_FORWARDER_NO: $('#FORWARDER_NO').val() });
            
                //this.Columns.Select(col => col
                _Title = value;
            }
        }

        private string _TableName;
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        public List<Button> Buttons = new List<Button>();
        public List<HtmlControl> Columns = new List<HtmlControl>();
        /*
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

                    config.QueryConditions.Add(new QueryCondition(QueryConditionTypes.TextBox, "DELIVERY_TYPE", "運送方式"));

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
         */
    }
}
