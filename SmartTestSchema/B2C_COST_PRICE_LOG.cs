//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartTestSchema
{
    using System;
    using System.Collections.Generic;
    
    public partial class B2C_COST_PRICE_LOG
    {
        public string B2C_CODE { get; set; }
        public short SEQ { get; set; }
        public Nullable<int> PROPOSE_PRICE { get; set; }
        public Nullable<int> ACT_PRICE { get; set; }
        public string CSGMT_VENDOR { get; set; }
        public Nullable<int> CSGMT_COST { get; set; }
        public string EFF_DATE { get; set; }
        public string CHANGE_ID { get; set; }
        public string CHANGE_DATE { get; set; }
        public string STATUS { get; set; }
        public Nullable<int> REF_AVG_PRICE { get; set; }
        public Nullable<int> REF_AD_PRICE { get; set; }
        public Nullable<int> REF_COST { get; set; }
        public Nullable<int> MBR_PRICE { get; set; }
    }
}
