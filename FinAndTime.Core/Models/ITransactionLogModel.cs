using FinAndTime.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinAndTime.Core.Models
{
    public interface ITransactionLogModel : IModel
    {
        Task<TransactionLogEntity> GetTransactionLogByIdAsync(int id);
        Task<IEnumerable<TransactionLogEntity>> GetTransactionLogsAsync();
        Task<int> InsertTransactionLogAsync(TransactionLogEntity transactionLogEntity);
    }
}
