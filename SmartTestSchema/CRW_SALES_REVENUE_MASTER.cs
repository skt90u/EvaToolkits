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
    
    public partial class CRW_SALES_REVENUE_MASTER
    {
        public CRW_SALES_REVENUE_MASTER()
        {
            this.CRW_SALES_REVENUE_DETAILS = new HashSet<CRW_SALES_REVENUE_DETAILS>();
        }
    
        public string RVNU_DATE { get; set; }
        public string CA_NO { get; set; }
        public Nullable<int> PAY_TWD { get; set; }
        public Nullable<decimal> PAY_USD { get; set; }
        public Nullable<decimal> SALE_USD { get; set; }
        public Nullable<decimal> RVNU_USD { get; set; }
        public Nullable<decimal> ERASE_RVNU_USD { get; set; }
        public string CLEAR_MARK { get; set; }
        public Nullable<short> SEQ { get; set; }
        public string TRANS_LOCK { get; set; }
        public Nullable<decimal> DISC_USD { get; set; }
        public Nullable<decimal> DISC_TWD { get; set; }
        public Nullable<decimal> COMPANY_USD { get; set; }
        public Nullable<decimal> COMPANY_TWD { get; set; }
        public Nullable<decimal> POS_USD { get; set; }
        public Nullable<decimal> FUND_USD { get; set; }
        public Nullable<decimal> FUND_TWD { get; set; }
        public Nullable<decimal> DFS_OVER_USD { get; set; }
        public Nullable<decimal> DFS_OVER_TWD { get; set; }
        public Nullable<decimal> DFS_UNDER_USD { get; set; }
        public Nullable<decimal> DFS_UNDER_TWD { get; set; }
        public Nullable<decimal> CASH_OVER_USD { get; set; }
        public Nullable<decimal> CASH_OVER_TWD { get; set; }
        public Nullable<decimal> CASH_UNDER_USD { get; set; }
        public Nullable<decimal> CASH_UNDER_TWD { get; set; }
        public string STATUS { get; set; }
        public string CRT_ID { get; set; }
        public string CRT_DATE { get; set; }
        public string CRT_TIME { get; set; }
        public string UPD_ID { get; set; }
        public string UPD_DATE { get; set; }
        public string UPD_TIME { get; set; }
        public string IS_DISC { get; set; }
        public string NATIONALITY { get; set; }
        public string CASH_USERID { get; set; }
        public Nullable<decimal> ORIGINAL_POS_USD { get; set; }
        public Nullable<decimal> RATE_DIFFERENCE { get; set; }
        public Nullable<int> UG_POS_USD { get; set; }
        public Nullable<int> UG_RVNU_USD { get; set; }
        public Nullable<decimal> LATE_RVNU_TWD { get; set; }
        public string ERASE_REMARK { get; set; }
        public Nullable<int> CREW_OVER_PAY { get; set; }
        public string COMPANY { get; set; }
    
        public virtual ICollection<CRW_SALES_REVENUE_DETAILS> CRW_SALES_REVENUE_DETAILS { get; set; }
    }
}
