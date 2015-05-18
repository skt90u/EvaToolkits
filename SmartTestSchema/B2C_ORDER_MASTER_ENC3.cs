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
    
    public partial class B2C_ORDER_MASTER_ENC3
    {
        public B2C_ORDER_MASTER_ENC3()
        {
            this.B2C_ORDER_PAYMENT_LOG = new HashSet<B2C_ORDER_PAYMENT_LOG>();
        }
    
        public string ORDER_NO { get; set; }
        public string ORDER_DATE { get; set; }
        public string ORDER_TIME { get; set; }
        public string CONFIRM_DATE { get; set; }
        public string CARD_FUND_DATE { get; set; }
        public string GL_DATE { get; set; }
        public string TRANS_DATE { get; set; }
        public string LAST_SHPR_DATE { get; set; }
        public string INVOICE_DATE { get; set; }
        public string INVOICE_NO { get; set; }
        public string CANCEL_DATE { get; set; }
        public Nullable<int> RCV_AMT { get; set; }
        public Nullable<int> ACT_RCV_AMT { get; set; }
        public Nullable<int> ACT_RTN_AMT { get; set; }
        public Nullable<int> TTL_WO_TAX { get; set; }
        public Nullable<int> TTL_TAX { get; set; }
        public string ORDER_FROM { get; set; }
        public string REMARK { get; set; }
        public Nullable<int> TTL_AMT { get; set; }
        public Nullable<short> FREIGHT_CHARAGE { get; set; }
        public string CUST_NBR { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_ID { get; set; }
        public string CUST_SEX { get; set; }
        public string CUST_BIRTH { get; set; }
        public string CUST_TEL_O { get; set; }
        public string CUST_TEL_H { get; set; }
        public string CUST_TEL_M { get; set; }
        public string CUST_FAX { get; set; }
        public string CUST_EMAIL { get; set; }
        public string CUST_ZIP_CODE { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string RCVR_NAME { get; set; }
        public string RCVR_TEL_O { get; set; }
        public string RCVR_TEL_H { get; set; }
        public string RCVR_TEL_M { get; set; }
        public string RCVR_ZIP_CODE { get; set; }
        public string RCVR_ADDRESS { get; set; }
        public string COMPANY_NAME { get; set; }
        public string COMPANY_ID { get; set; }
        public string DELIVERY_TIME { get; set; }
        public string RTN_FLAG { get; set; }
        public string ORIGIN_NO { get; set; }
        public string STATUS { get; set; }
        public string CRT_ID { get; set; }
        public string CRT_DATE { get; set; }
        public string CRT_TIME { get; set; }
        public string UPD_ID { get; set; }
        public string UPD_DATE { get; set; }
        public string UPD_TIME { get; set; }
        public Nullable<int> INVOICE_AMT { get; set; }
        public Nullable<int> INVOICE_WO_TAX { get; set; }
        public Nullable<int> INVOICE_TAX { get; set; }
        public string ORIGIN_INVOICE_NO { get; set; }
        public string RCVR_SEX { get; set; }
        public string CA_NO { get; set; }
        public Nullable<int> MILEAGE { get; set; }
        public string DEDUCT_MILEAGE_ID { get; set; }
        public string FFP_CARD_TYPE { get; set; }
        public Nullable<int> ACT_RTN_MILEAGE { get; set; }
        public string RTN_MILEAGE_FLAG { get; set; }
        public string SEND_MAIL_FLAG { get; set; }
        public string ECOUPON_NO { get; set; }
        public Nullable<int> ECOUPON_AMT { get; set; }
        public string FULL_ECOUPON_NO { get; set; }
        public Nullable<short> FULL_ECOUPON_MONEY { get; set; }
        public string EMAIL_MARK { get; set; }
        public string PRE_MARK { get; set; }
        public string PRE_STATUS { get; set; }
        public Nullable<int> MILEAGE_QTY { get; set; }
        public string AUT_FLAG { get; set; }
        public string AUT_DATE { get; set; }
        public Nullable<int> STAR_CNT { get; set; }
        public Nullable<int> RTN_STAR_CNT { get; set; }
        public Nullable<int> AVL_STAR_CNT { get; set; }
        public string STAR_EFF_DATE { get; set; }
    
        public virtual ICollection<B2C_ORDER_PAYMENT_LOG> B2C_ORDER_PAYMENT_LOG { get; set; }
    }
}
