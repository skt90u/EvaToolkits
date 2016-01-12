using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWeb
{
    public partial class BulletImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Penguins.jpg");
            list.Add("Desert.jpg");
            list.Add("Chrysanthemum.jpg");
            InitImages(Literal1, list);
        }
        private void InitImages(Literal literal, List<string> fileNames)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<div>");
            for(int i=0; i<fileNames.Count; i++)
            {
                string fileName = fileNames[i];
                sb.AppendFormat(RenderImage(i, fileName));
            }
            sb.Append("</div>");

            literal.Text = sb.ToString();
        }

        private string RenderImage(int index, string fileName)
        {
            int width = 204;
            int height = 204;
            string src = "Uploads/" + fileName;
            string title = fileName;
            string alt = fileName;
            string description = string.Format("{0}. {1}", index+1, fileName);
            
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<div class='indexItem MainBrowerItem_magin'>");
            sb.AppendFormat("	  <div class='item-image'>");
            sb.AppendFormat("		<div style='width:{0}px; height:{1}px; position:relative; '>", width, height);
            sb.AppendFormat("			<img src='{0}' class='img-responsive' border='0' width='{1}' height='{2}' alt='{3}' title='{4}' />", src, width, height, alt, title);
            sb.AppendFormat("		</div>");
            sb.AppendFormat("	  </div>");
            sb.AppendFormat("	  <div class='item-details'>", description);
            sb.AppendFormat("		 <h5>{0}</h5>", description);
            sb.AppendFormat("	  </div>");
            sb.AppendFormat("</div>");

            return sb.ToString();
        }
    }
}