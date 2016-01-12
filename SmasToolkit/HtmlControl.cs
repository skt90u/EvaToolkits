using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public enum HtmlControlTypes
    {
        TextBox,
        RadioButtonList,
        DropDownList,
        Date,
        TextBoxWithQueryDialg, // TODO: OpenQueryDialg(id)
        CheckBoxList

        // public class InputBoxCtrl : System.Web.UI.WebControls.TextBox
        // text, date, dateR, time, number



        // DDSC.CustomServerControl
    }

    public class HtmlControl
    {
        // 是否為主鍵值欄位
        public bool IsPrimaryKey { get; set; }
        // 是否為必填欄位
        public bool IsRequired { get; set; }

        private string _Name;
        public string Name 
        { 
            get 
            { 
                return _Name; 
            } 
            set 
            {
                _Name = (value ?? string.Empty).Trim().ToUpper();
            } 
        }

        public string Desc { get; set; }
        public HtmlControlTypes HtmlControlType { get; set; }

        //public HtmlControl(HtmlControlTypes HtmlControlType, string Name, string Desc)
        //{
        //    this.HtmlControlType = HtmlControlType;
        //    this.Name = Name;
        //    this.Desc = Desc;
        //}

        public string GetInputId()
        {
            return string.Format("qc{0}", Name); 
        }

        public string RenderLabel()
        {
            // ForeColor="Red" BackColor="Transparent"

            if (this.IsRequired || this.IsPrimaryKey)
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

        public string RenderInput()
        {
            string id = GetInputId();

            switch (HtmlControlType)
            {
                case HtmlControlTypes.RadioButtonList:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("<asp:RadioButtonList id='{0}' runat='server' RepeatDirection='Horizontal'>", id);
                        sb.AppendFormat("<asp:ListItem Value='0' Selected='True'>全部</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='1'>主倉</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='2'>外站</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='3'>其他</asp:ListItem>");
                        sb.AppendFormat("</asp:RadioButtonList>");
                        return sb.ToString().SetQuotation("\"");
                    }

                case HtmlControlTypes.DropDownList:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("<asp:DropDownList id='{0}' runat='server'>", id);
                        sb.AppendFormat("<asp:ListItem Value='' Selected='True'>全部</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='N'>N-一般品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='U'>U-再製品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='A'>A-公關贈品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='C'>C-組員</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='G'>G-地勤</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='P'>P-航員</asp:ListItem>");
                        sb.AppendFormat("</asp:DropDownList>");
                        return sb.ToString().SetQuotation("\"");
                    }

                case HtmlControlTypes.CheckBoxList:
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("<asp:CheckBoxList id='{0}' runat='server' RepeatDirection='Horizontal'>", id);
                        sb.AppendFormat("<asp:ListItem Value='' Selected='True'>全部</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='N'>N-一般品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='U'>U-再製品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='A'>A-公關贈品</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='C'>C-組員</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='G'>G-地勤</asp:ListItem>");
                        sb.AppendFormat("<asp:ListItem Value='P'>P-航員</asp:ListItem>");
                        sb.AppendFormat("</asp:CheckBoxList>");
                        return sb.ToString().SetQuotation("\"");
                    }

                case HtmlControlTypes.Date:
                    {
                        return string.Format("<ddsc:InputBoxCtrl ID='{0}' runat='server' AllowEmpty='true' TypeMode='Date'></ddsc:InputBoxCtrl>", id).SetQuotation("\"");
                    }

                case HtmlControlTypes.TextBoxWithQueryDialg:
                    {
                        return string.Format("<cc1:QueryCtrl ID=\"{0}\" ScriptOnclick=\"OpenQueryDialg('{0}')\" runat=\"server\" MaxLength=\"10\"/>", id);
                    }

                default:
                    return string.Format("<ddsc:inputboxctrl id='{0}' runat='server' Width='100px' ></ddsc:inputboxctrl>", id).SetQuotation("\"");
                    //return string.Format("<asp:TextBox ID='{0}' runat='server'></asp:TextBox>", id).SetQuotation("\"");
            }
        }

        public string SetJsonValue(string value)
        {
            string id = GetInputId();

            switch (HtmlControlType)
            {
                case HtmlControlTypes.TextBox:
                    {
                        return string.Format("$('#{0}').val('{1}')", id, value);
                    }

                case HtmlControlTypes.RadioButtonList:
                    {
                        return string.Format("$('#{0} input:radio:checked').val()", id);
                    }

                case HtmlControlTypes.DropDownList:
                    {
                        return string.Format("$('#{0}').val('{1}')", id, value);
                    }

                case HtmlControlTypes.CheckBoxList:
                    {
                        /*
(
function(selector){
	var list = [], delimiter = ',';
	$(selector).find('input:checked').each(function(){list.push($(this).val());});
	return list.join(delimiter);	
}
)('#yourid');
                         */
                        // TODO
                        // 還沒實做如何設定數值
                        return string.Format("$('#{0}').val('{1}')", id, value);
                    }

                case HtmlControlTypes.Date:
                    {
                        return string.Format("$('#{0}').val('{1}')", id, value);
                    }

                case HtmlControlTypes.TextBoxWithQueryDialg:
                    {
                        return string.Format("$('#{0}').val('{1}')", id, value);
                    }
            }

            return string.Format("$('#{0}').val('{1}')", id, value);
        }

        public string GetJsonValue()
        {
            string id = GetInputId();

            switch (HtmlControlType)
            {
                case HtmlControlTypes.TextBox:
                    {
                        return string.Format("$('#{0}').val()", id);
                    } 

                case HtmlControlTypes.RadioButtonList:
                    {
                        return string.Format("$('#{0} input:radio:checked').val()", id);
                    } 

                case HtmlControlTypes.DropDownList:
                    {
                        return string.Format("$('#{0}').val()", id);
                    }

                case HtmlControlTypes.CheckBoxList:
                    {
                        /*
(
function(selector){
	var list = [], delimiter = ',';
	$(selector).find('input:checked').each(function(){list.push($(this).val());});
	return list.join(delimiter);	
}
)('#yourid');
                         */
                        //StringBuilder sb = new StringBuilder();
                        //sb.AppendFormat("(");
                        //sb.AppendFormat("function(selector){{");
                        //sb.AppendFormat("var list = [], delimiter = ',';");
                        //sb.AppendFormat("$(selector).find('input:checked').each(function(){{list.push($(this).val());}});");
                        //sb.AppendFormat("return list.join(delimiter);");
                        //sb.AppendFormat("}}");
                        //sb.AppendFormat(")('#{0}');", id);

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

                case HtmlControlTypes.Date:
                    {
                        return string.Format("$('#{0}').val()", id);
                    } 

                case HtmlControlTypes.TextBoxWithQueryDialg:
                    {
                        return string.Format("$('#{0}').val()", id);
                    } 
            }

            return string.Format("$('#{0}').val()", id);
        }

        public string RenderWritablity(string action)
        {
            bool writable = false;

            switch (action)
            {
                case "ADD":
                    writable = !(Name == "UPD_ID" || 
                                 Name == "UPD_DATE" || 
                                 Name == "UPD_TIME");
                    break;
                case "UPD":
                    writable = !(Name == "UPD_ID" ||
                                 Name == "UPD_DATE" ||
                                 Name == "UPD_TIME") && 
                               !IsPrimaryKey;
                    break;
                case "DEL":
                    writable = false;
                    break;
                case "COPY":
                    writable = !(Name == "UPD_ID" ||
                                 Name == "UPD_DATE" ||
                                 Name == "UPD_TIME");
                    break;
                case "QRY":
                    writable = false;
                    break;
            }

            switch (HtmlControlType)
            {
                case HtmlControlTypes.TextBox:
                    {
                        return string.Format("{0}.EnableView = {1};", GetInputId(), writable ? "false" : "true");
                    }

                case HtmlControlTypes.RadioButtonList:
                    {
                        return string.Format("{0}.Enabled = {1};", GetInputId(), writable ? "true" : "false");
                    }

                case HtmlControlTypes.DropDownList:
                    {
                        return string.Format("{0}.Enabled = {1};", GetInputId(), writable ? "true" : "false");
                    }

                case HtmlControlTypes.CheckBoxList:
                    {
                        return string.Format("{0}.Enabled = {1};", GetInputId(), writable ? "true" : "false");
                    }

                case HtmlControlTypes.Date:
                    {
                        return string.Format("{0}.EnableView = {1};", GetInputId(), writable ? "false" : "true");
                    }

                case HtmlControlTypes.TextBoxWithQueryDialg:
                    {
                        return string.Format("{0}.EnableView = {1};", GetInputId(), writable ? "false" : "true");
                    }
            }

            return string.Format("{0}.EnableView = {1};", GetInputId(), writable ? "false" : "true");
        }

        public string RenderInitValue(string action)
        {
            string initValue = string.Empty;

            switch (action)
            {
                case "ADD":
                case "COPY":
                    {
                        switch (Name)
                        {
                            case "UPD_ID":
                                initValue = "OnUser.ID";
                                break;
                            case "UPD_DATE":
                                initValue = "SystemDate";
                                break;
                            case "UPD_TIME":
                                initValue = "SystemTime";
                                break;
                        }
                    }break;
            }

            // return string.Format("{0}.Text = {1};", GetInputId(), initValue);

            switch (HtmlControlType)
            {
                case HtmlControlTypes.TextBox:
                case HtmlControlTypes.RadioButtonList:
                case HtmlControlTypes.DropDownList:
                case HtmlControlTypes.CheckBoxList:
                case HtmlControlTypes.Date:
                case HtmlControlTypes.TextBoxWithQueryDialg:
                default:
                    {
                        if (!string.IsNullOrEmpty(initValue))
                        {
                            initValue = string.Format("{0}.Text = {1};", GetInputId(), initValue);
                        }
                    }break;
            }

            

            return initValue;
        }
    }
}
