using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class DetailPageGeneratorConfig
    {
        public string ParentPageId { get; set; }
        public string PageId { get; set; }
        public string Title { get; set; }

        public List<Button> Buttons = new List<Button>();
        public List<IHtmlTag> Columns = new List<IHtmlTag>();

        public string TableName { get; set; }

        public bool SupportHelp { get; set; }
    }
}
