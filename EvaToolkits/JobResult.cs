using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaToolkits
{
    class JobResult
    {
        //  開始時間
        public DateTime StartTime { get; set; }
        
        //  花費時間
        public TimeSpan Duration { get; set; }

        //  執行結果(是否執行成功)
        public bool Success { get; set; }

        //  備註說明
        public string Remark { get; set; }

        //  執行歷程
        public List<string> Logs { get; set; }

        //  其他內容
        public List<string> EmailBodies { get; set; }
    }
}
