using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
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

    public class Button
    {
        public string g_ButtonType
        {
            get {
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

        public string RenderMasterAspx() 
        {
            string output = string.Empty;

            switch (ButtonType)
            {
                case ButtonTypes.btnSEARCH:
                    output = string.Format("<input id='{0}' class='BtnOn' type='button' value='{1}' onclick='return {0}_Click()' />",
                        Id,
                        Text);
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

        public string RenderVisibility(string action)
        {
            bool visible = false;

            switch(ButtonType)
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

            if(ButtonType == ButtonTypes.btnHelp)
                return string.Format("{0}.Visible = bSupportHelp;", Id);
            else
                return string.Format("{0}.Visible = {1};", Id, visible ? "true" : "false");
        }

        public string RenderDetailAspx()
        {
            /*
            <asp:Button ID='btnSave'   class='BtnOn' runat='server' Text='存檔x' OnClientClick='return btnSave_Click()' OnClick='btnSave_Click' />
            <asp:Button ID='btnDELETE' class='BtnOn' runat='server' Text='刪除x' OnClientClick='return btnDELETE_Click()' OnClick='btnDELETE_Click'/>  
            <asp:Button ID='btnCLEAR'  class='BtnOn' runat='server' Text='清除x' OnClientClick='return btnCLEAR_Click()' />  
            <asp:Button ID='btnHelp'   class='BtnOn' runat='server' Text='說明x' />
            <asp:Button ID='btnExit'   class='BtnOn' runat='server' Text='離開x' PostBackUrl='~/BAS/BASM0070.aspx' />
             */
            string output = string.Empty;

            switch (ButtonType)
            {
                case ButtonTypes.btnSave:
                case ButtonTypes.btnDELETE:
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' OnClientClick='return {0}_Click()' OnClick='{0}_Click' />",
                        Id,
                        Text);
                    break;

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
                    output = string.Format("<asp:Button ID='{0}' class='BtnOn' runat='server' Text='{1}' PostBackUrl='{2}' OnClientClick='return {0}_Click()' OnClick='{0}_Click' />",
                        Id,
                        Text,
                        PostBackUrl,
                        Id);
                    break;
            }

            return output.Replace("'", "\"");
        }

        public ButtonTypes ButtonType { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string PostBackUrl { get; set; }

        public Button(ButtonTypes ButtonType, string PostBackUrl)
        {
            this.ButtonType = ButtonType;
            this.Id = ButtonType.ToString();
            this.Text = Utils.GetDescription <ButtonTypes>(ButtonType) + "x";
            this.PostBackUrl = PostBackUrl;
        }

    }
}
