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
    
    public partial class CRW_CUST_PURCHASE_MASTER
    {
        public string DEPT_DATE { get; set; }
        public string DEPT_FLT_NO { get; set; }
        public string DOC_NO { get; set; }
        public string SECTOR_SEQ { get; set; }
        public short RECIPT_NO { get; set; }
        public Nullable<int> CREDIT_CARD_USD { get; set; }
        public Nullable<int> CREDIT_CARD_TWD { get; set; }
        public Nullable<int> CASH_USD { get; set; }
        public Nullable<int> CASH_TWD { get; set; }
        public Nullable<int> CASH_HKD { get; set; }
        public Nullable<int> CASH_JPY { get; set; }
        public Nullable<int> CASH_SGD { get; set; }
        public Nullable<int> CASH_GBP { get; set; }
        public Nullable<int> CASH_ATS { get; set; }
        public Nullable<int> TRAVEL_CHK { get; set; }
        public Nullable<int> COUPON { get; set; }
        public string BRDG_CLASS { get; set; }
        public string AGE { get; set; }
        public string SEX { get; set; }
        public string NATION { get; set; }
        public string STATUS { get; set; }
        public string CRT_ID { get; set; }
        public string CRT_DATE { get; set; }
        public string CRT_TIME { get; set; }
        public string UPD_ID { get; set; }
        public string UPD_DATE { get; set; }
        public string UPD_TIME { get; set; }
        public Nullable<int> DISCOUNT_COUPON_TWD { get; set; }
        public Nullable<int> CASH_CNY { get; set; }
        public string ORDER_NO { get; set; }
        public Nullable<decimal> RVNU_USD { get; set; }
        public string RTN_FLAG { get; set; }
        public string REFUND_NO { get; set; }
        public string REFUND_DATE { get; set; }
        public string ORIGIN_NO { get; set; }
        public string CURRENCY { get; set; }
        public Nullable<decimal> RCV_AMT { get; set; }
        public Nullable<decimal> RCV_AMT_USD { get; set; }
        public Nullable<decimal> ACT_RCV_AMT { get; set; }
        public Nullable<decimal> ACT_RCV_AMT_USD { get; set; }
        public Nullable<decimal> ACT_RTN_AMT_USD { get; set; }
        public Nullable<int> ACT_RTN_AMT_COUPON { get; set; }
        public string REMARK { get; set; }
        public string TRANS_DATE { get; set; }
        public string TRANS_NO { get; set; }
        public string CARD_FUND_DATE { get; set; }
        public string GL_DATE { get; set; }
        public string REQ_DATE { get; set; }
        public string IFE_ORDER_NO { get; set; }
        public string SEAT_NO { get; set; }
        public string IFE_ORDER_MARK { get; set; }
        public string IFE_ORDER_MARK_UPD { get; set; }
    
        public virtual APN_FLIGHT_ROUTE_SETTLEMENT APN_FLIGHT_ROUTE_SETTLEMENT { get; set; }
    }
}
