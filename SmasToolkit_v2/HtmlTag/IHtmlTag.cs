using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public interface IHtmlTag
    {
        string DbColumn { get; set; } // 實際對應的資料庫欄位
        string Name { get; set; }
        string Desc { get; set; }
        bool IsPrimaryKey { get; set; }
        bool IsRequired { get; set; }

        string GetInputId();
        string RenderHtml();
        string RenderLabel();

        string JsGetValue();
        string JsSetValue(string value);

        string RenderWritablity(string action);
        string RenderInitValue(string action);
    }
}
