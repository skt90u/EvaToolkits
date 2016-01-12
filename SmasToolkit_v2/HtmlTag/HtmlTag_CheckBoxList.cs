using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class CheckBoxList : IHtmlTag
    {
        private string _DbColumn;
        public string DbColumn
        {
            get
            {
                if (!string.IsNullOrEmpty(_DbColumn))
                    return _DbColumn;
                else
                    return Name;
            }
            set
            {
                _DbColumn = value;
            }
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsRequired { get; set; }
        public Dictionary<string, string> DataSource { get; set; }

        public string GetInputId()
        {
            return string.Format("qc{0}", Name);
        }

        public string RenderHtml()
        {
            string id = GetInputId();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<asp:CheckBoxList id='{0}' runat='server'>", id);

            if (DataSource != null)
            {
                foreach (var key in DataSource.Keys)
                {
                    var val = DataSource[key];

                    sb.AppendFormat("<asp:ListItem Value='{0}'>{1}</asp:ListItem>", val, key);
                }
            }

            sb.AppendFormat("</asp:CheckBoxList>");
            return sb.ToString().SetQuotation("\"");
        }

        public string RenderLabel()
        {
            if (this.IsPrimaryKey)
            {
                return string.Format("<asp:Label ID='lbl{0}' ForeColor='Red' BackColor='Transparent' runat='server'>{1}</asp:Label>",
                    Name,
                    Desc + "x").SetQuotation("\"");
            }
            else
            {
                return string.Format("<asp:Label ID='lbl{0}' runat='server'>{1}</asp:Label>",
                    Name,
                    Desc + "x").SetQuotation("\"");
            }
        }

        public string JsGetValue()
        {
            string id = GetInputId();

            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            sb.Append("function(selector){");
            sb.Append("var list = [], delimiter = ',';");
            sb.Append("$(selector).find('input:checked').each(function(){list.push($(this).val());});");
            sb.Append("return list.join(delimiter);");
            sb.Append("}");
            sb.AppendFormat(")('#{0}')", id);

            return sb.ToString();
        }

        public string RenderWritablity(string action)
        {
            bool writable = Utils.GetWritablity(action, this);

            return string.Format("{0}.Enabled = {1};", GetInputId(), writable ? "true" : "false");
        }

        public string RenderInitValue(string action)
        {
            string initValue = Utils.GetInitValue(action, this);

            if (!string.IsNullOrEmpty(initValue))
            {
                initValue = string.Format("{0}.Text = {1};", GetInputId(), initValue);
            }

            return initValue;
        }

        public string JsSetValue(string value)
        {
            string id = GetInputId();

            return string.Format("$('#{0}').val('{1}')", id, value);
        }
    }
}
