using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class Date : IHtmlTag
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

        public string GetInputId()
        {
            return string.Format("qc{0}", Name);
        }

        public string RenderHtml()
        {
            string id = GetInputId();

            return string.Format("<ddsc:InputBoxCtrl ID='{0}' runat='server' AllowEmpty='{1}' TypeMode='Date'></ddsc:InputBoxCtrl>",
                id,
                (IsRequired || IsPrimaryKey) ? "false" : "true").SetQuotation("\"");
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

            return string.Format("$('#{0}').val()", id);
        }

        public string RenderWritablity(string action)
        {
            bool writable = Utils.GetWritablity(action, this);

            return string.Format("{0}.EnableView = {1};", GetInputId(), writable ? "false" : "true");
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
