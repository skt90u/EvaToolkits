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
    
    public partial class MMG_MESSAGE_SEND
    {
        public System.DateTime MMG_DATETIME { get; set; }
        public string MMG_SUBJECT { get; set; }
        public string MMG_TEXT { get; set; }
        public string MMG_SENDTO { get; set; }
        public string MMG_COPYTO { get; set; }
        public string MMG_BLINDCOPY { get; set; }
        public string MMG_SENDER { get; set; }
        public string MMG_DB_USER { get; set; }
        public Nullable<System.DateTime> MMG_LASTUPDATE { get; set; }
        public Nullable<System.DateTime> MMG_COMPLETED_DATETIME { get; set; }
        public string MMG_PROCESSOR { get; set; }
        public Nullable<long> MMG_ID { get; set; }
        public string MMG_LOG { get; set; }
        public Nullable<int> TELEX_SEND_SEQ { get; set; }
        public string TELEX_DBLSIG { get; set; }
        public string TELEX_MSGID { get; set; }
        public string MMG_SENDER_ADDRESS { get; set; }
        public Nullable<short> MMG_PRIORITY { get; set; }
    }
}
