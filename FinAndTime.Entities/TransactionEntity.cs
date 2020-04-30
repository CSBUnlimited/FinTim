using System;

namespace FinAndTime.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public int TransactionPartyId { get; set; }
        public double Amount { get; set; }
        public int? ScheduledTransactionId { get; set; }
        public bool IsIncome { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Remarks { get; set; }
        public bool IsUserPerformed { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
