using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAndTime.Entities
{
    public class SkipTransactionEntity
    {
        public int Id { get; set; }
        public int ScheduledTransactionId { get; set; }
        public int SkipCount { get; set; }
        public int EffectedCount { get; set; }
        public int Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastEffectedDateTime { get; set; }
    }
}
