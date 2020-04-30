using FinAndTime.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinAndTime.Core.Models
{
    public interface ITransactionModel : IModel
    {
        Task<TransactionEntity> GetTransactionByIdAsync(int id);
        Task<IEnumerable<TransactionEntity>> GetTransactionsAsync();
        Task<int> InsertTransactionAsync(TransactionEntity transactionEntity, bool isUserPerformed = false);
        Task<int> UpdateTransactionAsync(TransactionEntity transactionEntity);
        Task<int> DeleteTransactionAsync(int id);
    }
}
