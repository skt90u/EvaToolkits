using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class ReportConfig
    {
        public string PageId { get; set; }
        public string Title { get; set; }
        public List<Button> Buttons = new List<Button>();
        public List<IHtmlTag> QueryConditions = new List<IHtmlTag>();

        public string Sql { get; set; }
    }
}
