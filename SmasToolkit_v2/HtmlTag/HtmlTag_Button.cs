using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public enum ButtonTypes
    {
        None,
        [Description("搜尋")]
        btnSEARCH,
        [Description("新增")]
        btnADD,
        [Description("修改")]
        btnEDIT,
        [Description("刪除")]
        btnDELETE,
        [Description("複製")]
        btnCOPY,
        [Description("查詢")]
        btnFIND,

        [Description("存檔")]
        btnSave,

        [Description("清除")]
        btnCLEAR,

        [Description("說明")]
        btnHelp,

        [Description("離開")]
        btnExit,
    }

    public class Button : IHtmlTag
    {
        public static List<Button> GetDefaultMasterPageButtons(string postBackPageId)
        {
            //<input id="btnSEARCH" class="BtnOn" type="button" value="搜尋x" onclick="return btnSEARCH_Click()" />
            //<asp:Button ID="btnADD" runat="server" Text="新增x" PostBackUrl="~/PSD/PSDM0071.aspx" class="BtnOn" OnClick="btnADD_Click"/>
            //<asp:Button ID="btnEDIT" runat="server" Text="修改x" PostBackUrl="~/PSD/PSDM0071.aspx" class="BtnOn" OnClick="btnEDIT_Click"/>
            //<asp:Button ID="btnDELETE" runat="server" Text="刪除x" PostBackUrl="~/PSD/PSDM0071.aspx" class="BtnOn" OnClick="btnDELETE_Click"/>
            //<asp:Button ID="btnCOPY" runat="server" Text="複製x" PostBackUrl="~/PSD/PSDM0071.aspx" class="BtnOn" OnClick="btnCOPY_Click"/>
            //<asp:Button ID="btnFIND" runat="server" Text="查詢x" PostBackUrl="~/PSD/PSDM0071.aspx" class="BtnOn" OnClick="btnFIND_Click"/>

            postBackPageId = postBackPageId.Trim().ToUpper();
            
            List<Button> Buttons = new List<Button>();

            string pageCategory = Utils.GetPageCategory(postBackPageId);
            string PostBackUrl = string.Format("~/{0}/{1}.aspx", pageCategory, postBackPageId);

            Buttons.Add(new Button { ButtonType = ButtonTypes.btnSEARCH });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnADD, PostBackUrl = PostBackUrl });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnEDIT, PostBackUrl = PostBackUrl });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnDELETE, PostBackUrl = PostBackUrl });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnCOPY, PostBackUrl = PostBackUrl });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnFIND, PostBackUrl = PostBackUrl });

            return Buttons;
        }

        public static List<Button> GetDefaultDetailButtons(string parentPageId)
        {
            //<asp:Button ID="btnSave" class="BtnOn" runat="server" Text="存檔x" OnClientClick="return btnSave_Click()" OnClick="btnSave_Click" />
            //<asp:Button ID="btnDELETE" class="BtnOn" runat="server" Text="刪除x" OnClientClick="return btnDELETE_Click()" OnClick="btnDELETE_Click" />
            //<asp:Button ID="btnCLEAR" class="BtnOn" runat="server" Text="清除x" OnClientClick="return btnCLEAR_Click()" />
            //<asp:Button ID="btnHelp" class="BtnOn" runat="server" Text="說明x" />
            //<asp:Button ID="btnExit" class="BtnOn" runat="server" Text="離開x" PostBackUrl="~/PSD/PSDM0070.aspx" />

            parentPageId = parentPageId.Trim().ToUpper();

            List<Button> Buttons = new List<Button>();

            string pageCategory = Utils.GetPageCategory(parentPageId);
            string PostBackUrl = string.Format("~/{0}/{1}.aspx", pageCategory, parentPageId);

            Buttons.Add(new Button { ButtonType = ButtonTypes.btnSave });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnDELETE });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnCLEAR });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnHelp });
            Buttons.Add(new Button { ButtonType = ButtonTypes.btnExit, PostBackUrl = PostBackUrl });

            return Buttons;
        }

        public ButtonTypes ButtonType { get; set; }
        public string PostBackUrl { get; set; }
        public string DbColumn { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsRequired { get; set; }
        

        public string g_ButtonType
        {
            get
            {
                switch (ButtonType)
                {
                    case ButtonTypes.btnEDIT:
                        return "UPD";

                    case ButtonTypes.btnFIND:
                        return "QRY";

                    case ButtonTypes.btnCOPY:
                        return "COPY";

                    case ButtonTypes.btnADD:
                        return "ADD";

                    case ButtonTypes.btnDELETE:
                        return "DEL";

                    default:
                        return Id;
                }
            }
        }

        public string GetInputId()
        {
            return Id;
        }

        public string Id { 
            get 
            {
                return ButtonType.ToString();
            } 
        }

        public string Text
        {
            get
            {
                return Utils.GetDescription<ButtonTypes>(ButtonType) + "x";
            }
        }

        public string RenderHtml()
        {
            string output = string.Empty;

            switch (ButtonType)
            {
                case ButtonTypes.btnSEARCH:
                    output = string.Format("<input id='{0}' class='BtnOn' type='button' value='{1}' onclick='return {0}_Click()' />",
                        Id,
                        Text);
                    break;

                case ButtonTypes.btnSave:
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' OnClientClick='return {0}_Click()' OnClick='{0}_Click' />",
                        Id,
                        Text);
                    break;

                case ButtonTypes.btnDELETE:
                    {
                        if (string.IsNullOrEmpty(PostBackUrl))
                        {
                            output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' OnClientClick='return {0}_Click()' OnClick='{0}_Click' />",
                                Id,
                                Text);
                        }
                        else
                        {
                            output = string.Format("<asp:Button ID='{0}' runat='server' Text='{1}' PostBackUrl='{2}' class='BtnOn' OnClick='{0}_Click'/>",
                                Id,
                                Text,
                                PostBackUrl);
                        }
                    }break;
                case ButtonTypes.btnCLEAR:
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' OnClientClick='return {0}_Click()' />",
                        Id,
                        Text);
                    break;

                case ButtonTypes.btnHelp:
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' />",
                        Id,
                        Text);
                    break;

                case ButtonTypes.btnExit:
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' PostBackUrl='{2}' />",
                        Id,
                        Text,
                        PostBackUrl);
                    break;

                default:
                    output = string.Format("<asp:Button ID='{0}' runat='server' Text='{1}' PostBackUrl='{2}' class='BtnOn' OnClick='{0}_Click'/>",
                        Id,
                        Text,
                        PostBackUrl);
                    break;
            }

            return output.Replace("'", "\"");
        }


        public string RenderLabel()
        {
            throw new NotImplementedException();
        }


        public string JsGetValue()
        {
            throw new NotImplementedException();
        }

        public string RenderVisibility(string action)
        {
            bool visible = false;

            switch (ButtonType)
            {
                case ButtonTypes.btnSave:
                    visible = action == "ADD" || action == "UPD" || action == "COPY";
                    break;

                case ButtonTypes.btnDELETE:
                    visible = action == "DEL";
                    break;

                case ButtonTypes.btnCLEAR:
                    visible = action == "ADD" || action == "COPY";
                    break;

                case ButtonTypes.btnHelp:
                    visible = false;
                    break;

                case ButtonTypes.btnExit:
                    visible = true;
                    break;
            }

            if (ButtonType == ButtonTypes.btnHelp)
                return string.Format("{0}.Visible = bSupportHelp;", Id);
            else
                return string.Format("{0}.Visible = {1};", Id, visible ? "true" : "false");
        }


        public string RenderWritablity(string action)
        {
            throw new NotImplementedException();
        }

        public string RenderInitValue(string action)
        {
            throw new NotImplementedException();
        }

        public string JsSetValue(string value)
        {
            throw new NotImplementedException();
        }



        public static List<Button> GetDefaultReportButtons()
        {
            throw new NotImplementedException();
        }
    }
}
