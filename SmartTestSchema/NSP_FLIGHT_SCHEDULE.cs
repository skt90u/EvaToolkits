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
    
    public partial class NSP_FLIGHT_SCHEDULE
    {
        public string DEPT_DATE { get; set; }
        public string DEPT_TIME { get; set; }
        public string FLT_NO { get; set; }
        public string DEPT_STN { get; set; }
        public string ARIV_STN { get; set; }
        public string AIRCRAFT_TYPE { get; set; }
        public Nullable<short> PAX_AVAILABLE_F { get; set; }
        public Nullable<short> PAX_AVAILABLE_C { get; set; }
        public Nullable<short> PAX_AVAILABLE_ED { get; set; }
        public Nullable<short> PAX_AVAILABLE_Y { get; set; }
        public Nullable<short> PAX_BOOKING_F { get; set; }
        public Nullable<short> PAX_BOOKING_C { get; set; }
        public Nullable<short> PAX_BOOKING_ED { get; set; }
        public Nullable<short> PAX_BOOKING_Y { get; set; }
        public string AC_NO { get; set; }
        public string AIRCRAFT_PAX_CARGO { get; set; }
        public string FLIGHT_REGION { get; set; }
        public string ORIGINAL_STD_LOCAL { get; set; }
        public string ORIGINAL_STD_TIME { get; set; }
    }
}
