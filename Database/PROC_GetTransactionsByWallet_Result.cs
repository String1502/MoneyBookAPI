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
    
    public partial class PROC_GetTransactionsByWallet_Result
    {
        public int Id { get; set; }
        public Nullable<int> WalletId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> EventId { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}
