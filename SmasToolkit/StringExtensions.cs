using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit
{
    public static class StringExtensions
    {
        public static string SetQuotation(this String str, string quotation)
        {
            return str.Replace("'", "驫").Replace("\"", "驫").Replace("驫", quotation);
        }
    }  
}
