//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyBookAPI.Database
{
    using System;
    
    public partial class PROC_GetDefaultTransactionTypes_Result
    {
        public int Id { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> IconId { get; set; }
        public string Name { get; set; }
        public Nullable<int> IsExpense { get; set; }
        public Nullable<int> IsDefault { get; set; }
        public string Tag { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}
