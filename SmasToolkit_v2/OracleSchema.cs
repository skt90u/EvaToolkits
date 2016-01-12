using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmasToolkit_v2
{
    public class OracleSchema
    {
        public string TABLE_CATALOG { get; set; }
        public string TABLE_SCHEMA { get; set; }
        public string TABLE_NAME { get; set; }
        public string TABLE_TYPE { get; set; }
        public string TABLE_GUID { get; set; }

        public string DESCRIPTION { get; set; }
        public string TABLE_PROPID { get; set; }
        public DateTime DATE_CREATED { get; set; }
        public DateTime DATE_MODIFIED { get; set; }
        
    }
}
