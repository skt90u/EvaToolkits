using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public class MasterPageGeneratorConfig
    {
        public MasterPageGeneratorConfig()
        {
            this.SearchSqlOrderBy = string.Empty;
        }

        private DetailPageGeneratorConfig _DetailConfig;
        public DetailPageGeneratorConfig DetailConfig
        {
            get
            {
                return _DetailConfig;
            }
            set
            {
                _DetailConfig = value;
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
                _Title = value;
            }
        }

        public List<Button> Buttons = new List<Button>();

        public List<HtmlControl> QueryConditions = new List<HtmlControl>();

        //<div class="GridTableFooter" id="ProgramPageControl" detl="QueryDetl" ChkBox="N" gridwidth="20%,20%,30%" hidecolumn="" TextAlign="L,C,L">

        public HtmlControl GetMatchedQueryCondition(string aSqlLine, List<HtmlControl> queryConditions)
        {
            foreach (var hc in queryConditions)
            {
                if (aSqlLine.Contains(":" + hc.Name))
                    return hc;
            }

            return null;
        }

        public string RenderGridTableFooter()
        {
            string aSqlLine = string.Empty;

            var config = this;
            
            StringBuilder sb = new StringBuilder();

            // <div class='GridTableFooter' id='ProgramPageControl' detl='QueryDetl' ChkBox='N' gridwidth='20%,20%,30%' hidecolumn='' TextAlign='L,C,L'>
            string attrDetl = string.Format("detl='{0}'", string.IsNullOrEmpty(SearchDetailSql) ? string.Empty : "QueryDetl");
            string attrChkBox = string.Format("ChkBox='{0}'", ChkBox ? "Y" : "N");
            string attrGridwidth = string.Format("gridwidth='{0}'", string.Join(",", Gridwidth ?? GetDefaultGridwidth().ToArray()));
            string attrHidecolumn = string.Format("hidecolumn='{0}'", string.Join(",", Hidecolumn ?? new string[]{}));
            string attrTextAigln = string.Format("TextAlign='{0}'", string.Join(",", TextAlign ?? GetDefaultTextAlign().ToArray()));

            string template = "<div class='GridTableFooter' id='ProgramPageControl' @attr_detl @attr_ChkBox @attr_gridwidth @attr_hidecolumn @attr_TextAlign>";

            return template.Replace("@attr_detl", attrDetl)
                           .Replace("@attr_ChkBox", attrChkBox)
                           .Replace("@attr_gridwidth", attrGridwidth)
                           .Replace("@attr_hidecolumn", attrHidecolumn)
                           .Replace("@attr_TextAlign", attrTextAigln)
                           .SetQuotation("\"");
        }

        private List<string> GetDefaultTextAlign()
        {
            List<string> hidecolumns = new List<string>(Hidecolumn ?? new string[] { });

            // (1) 取得所有查詢到的欄位
            List<string> fields = SqlUtils.GetFields(SearchSql);

            // (2) 去除 Hidecolumn
            List<string> fieldsExceptHidecolumns = fields.Except(hidecolumns).ToList();

            string defaultTextAlign = "L";

            return fieldsExceptHidecolumns.Select(p => string.Format("{0}", defaultTextAlign)).ToList();
        }

        private List<string> GetDefaultGridwidth()
        {
            List<string> hidecolumns = new List<string>(Hidecolumn ?? new string[] { });

            // (1) 取得所有查詢到的欄位
            List<string> fields = SqlUtils.GetFields(SearchSql);
         
            // (2) 去除 Hidecolumn
            List<string> fieldsExceptHidecolumns = fields.Except(hidecolumns).ToList();

            // (3) 平均分配欄位寬度
            int width = (int)(100 / fieldsExceptHidecolumns.Count());

            return fieldsExceptHidecolumns.Select(p => string.Format("{0}%", width)).ToList();
        }

        public string _SearchSql;
        public string SearchSql
        {
            get
            {
                return _SearchSql;
            }
            set
            {
                _SearchSql = value;
            }
        }

        public string _SearchSqlOrderBy;
        public string SearchSqlOrderBy
        {
            get
            {
                return _SearchSqlOrderBy;
            }
            set
            {
                _SearchSqlOrderBy = value;
            }
        }

        public string _SearchDetailSql; // detl="QueryDetl"
        public string SearchDetailSql
        {
            get
            {
                return _SearchDetailSql;
            }
            set
            {
                _SearchDetailSql = value;
            }
        }

        private bool _ChkBox; // ChkBox="N"
        public bool ChkBox
        {
            get
            {
                return _ChkBox;
            }
            set
            {
                _ChkBox = value;
            }
        }

        private string[] _Gridwidth; // gridwidth="20%,20%,30%"
        public string[] Gridwidth
        {
            get
            {
                return _Gridwidth;
            }
            set
            {
                _Gridwidth = value;
            }
        }

        private string[] _Hidecolumn; // hidecolumn=""
        public string[] Hidecolumn
        {
            get
            {
                return _Hidecolumn;
            }
            set
            {
                _Hidecolumn = value;
            }
        }

        private string[] _TextAlign; // TextAlign="L,C,L"
        public string[] TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
            }
        }

        public string GetQueryCondition()
        {
            List<string> keyVals = QueryConditions.Select(hc => string.Format("{0}: {1}", hc.Name, hc.GetJsonValue()))
                                                  .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Join(", ", keyVals));
            sb.Append("}");
            return sb.ToString();

            //return "{ CURRENCY_TYPE: $('#txtCURRENCY_TYPE').val() }";
        }
    }
}
