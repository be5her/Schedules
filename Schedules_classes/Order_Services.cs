//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    

    public partial class Order_Services
    {

        public int Order_id { get; set; }
        public int Service_id { get; set; }
        public Nullable<decimal> Current_price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
