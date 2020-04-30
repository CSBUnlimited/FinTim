using FinAndTime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinAndTime.Service
{
    public partial class ApplicationService
    {
        static SemaphoreSlim _insertTransactionSemaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task<TransactionEntity> InsertTransactionAsync(TransactionEntity transaction, bool isUserPerformed = false)
        {
            await _insertTransactionSemaphoreSlim.WaitAsync();
            try
            {
                int tId = await _transactionModel.InsertTransactionAsync(transaction, isUserPerformed);
                transaction = await _transactionModel.GetTransactionByIdAsync(tId);

                IList<TransactionEntity> transactions = Transactions.ToList();
                transactions.Add(transaction);

                double startingBalance = CurrentUser.CurrentBalance;
                double newBalance = startingBalance + ((transaction.IsIncome ? 1 : -1) * transaction.Amount);

                await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
                UserEntity userEntity = await _userModel.GetUserDetailsAsync();

                TransactionLogEntity transactionLog = new TransactionLogEntity()
                {
                    Amount = transaction.Amount,
                    IsIncome = transaction.IsIncome,
                    IsDeletedTransaction = false,
                    ScheduledTransactionId = transaction.ScheduledTransactionId,
                    TransactionDateTime = DateTime.Now,
                    CreatedDateTime = DateTime.Now,
                    IsUserPerformed = isUserPerformed,
                    TransactionId = transaction.Id,
                    TransactionPartyId = transaction.TransactionPartyId,
                    Remarks = $"Transaction: {transaction.ReferenceNumber} Added",
                    StartingBalance = startingBalance,
                    FinalBalance = newBalance,
                };

                int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
                transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

                IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
                transactionLogs.Add(transactionLog);

                Transactions = transactions;
                TransactionLogs = transactionLogs;
                CurrentUser = userEntity;

                return transaction;
            }
            finally
            {
                _insertTransactionSemaphoreSlim.Release();
            }
        }

        public async Task<TransactionEntity> UpdateTransactionAsync(TransactionEntity transaction)
        {
            TransactionEntity beforeTransaction = await _transactionModel.GetTransactionByIdAsync(transaction.Id);
            await _transactionModel.UpdateTransactionAsync(transaction);
            TransactionEntity afterTransaction = await _transactionModel.GetTransactionByIdAsync(transaction.Id);

            double differenceIncome = (afterTransaction.IsIncome ? 1 : -1) * afterTransaction.Amount - (beforeTransaction.IsIncome ? 1 : -1) * beforeTransaction.Amount;

            double startingBalance = CurrentUser.CurrentBalance;
            double newBalance = startingBalance + differenceIncome;

            await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            TransactionLogEntity transactionLog = new TransactionLogEntity()
            {
                Amount = Math.Abs(differenceIncome),
                IsIncome = differenceIncome > 0,
                IsDeletedTransaction = false,
                ScheduledTransactionId = transaction.ScheduledTransactionId,
                TransactionDateTime = DateTime.Now,
                CreatedDateTime = DateTime.Now,
                IsUserPerformed = true,
                TransactionId = transaction.Id,
                TransactionPartyId = transaction.TransactionPartyId,
                Remarks = $"Transaction: {beforeTransaction.ReferenceNumber} Updated; Diff: {differenceIncome}",
                StartingBalance = startingBalance,
                FinalBalance = newBalance,
            };

            int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
            transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

            IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
            transactionLogs.Add(transactionLog);

            IEnumerable<TransactionEntity> transactions = await _transactionModel.GetTransactionsAsync();

            Transactions = transactions;
            TransactionLogs = transactionLogs;
            CurrentUser = userEntity;

            return afterTransaction;
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionModel.DeleteTransactionAsync(id);
            TransactionEntity transaction = await _transactionModel.GetTransactionByIdAsync(id);

            double startingBalance = CurrentUser.CurrentBalance;
            double newBalance = startingBalance + (transaction.IsIncome ? -1 : 1) * transaction.Amount; // Reversed because transaction deleted

            await _userModel.UpdateUserCurrentBalanceAsync(newBalance);
            UserEntity userEntity = await _userModel.GetUserDetailsAsync();

            TransactionLogEntity transactionLog = new TransactionLogEntity()
            {
                Amount = transaction.Amount,
                IsIncome = !transaction.IsIncome,
                IsDeletedTransaction = true,
                ScheduledTransactionId = transaction.ScheduledTransactionId,
                TransactionDateTime = DateTime.Now,
                CreatedDateTime = DateTime.Now,
                IsUserPerformed = true,
                TransactionId = transaction.Id,
                TransactionPartyId = transaction.TransactionPartyId,
                Remarks = $"Transaction: {transaction.ReferenceNumber} Deleted",
                StartingBalance = startingBalance,
                FinalBalance = newBalance,
            };

            int tlId = await _transactionLogModel.InsertTransactionLogAsync(transactionLog);
            transactionLog = await _transactionLogModel.GetTransactionLogByIdAsync(tlId);

            IList<TransactionLogEntity> transactionLogs = TransactionLogs.ToList();
            transactionLogs.Add(transactionLog);

            IList<TransactionEntity> transactions = Transactions.ToList();
            TransactionEntity deletedTransaction = transactions.First(tp => tp.Id == id);
            deletedTransaction.IsActive = false;

            Transactions = transactions;
            TransactionLogs = transactionLogs;
            CurrentUser = userEntity;
        }

        public async Task GenarateTransactionReportAsync()
        {
            IList<string> lines = new List<string>();
            IEnumerable<TransactionEntity> transactions = Transactions.Where(t => t.IsActive).OrderByDescending(t => t.TransactionDateTime);

            lines.Add("ReferenceNumber,TransactionDateTime,TransactionPartyCode,Amount,PerformedBy,Remarks");
            foreach (TransactionEntity transaction in transactions)
            {
                TransactionPartyEntity partyEntity = TransactionParties.First(tp => tp.Id == transaction.TransactionPartyId);
                lines.Add($"{transaction.ReferenceNumber},{transaction.TransactionDateTime.ToString("yyyy-MM-dd h:mm:ss tt")},{partyEntity.Code},{(transaction.Amount * (transaction.IsIncome ? 1 : -1)).ToString("0.00")},{(transaction.IsUserPerformed ? "User" : "System")},{transaction.Remarks}");
            }
            await _transactionModel.GenarateTransactionReportAsync(lines);
        }
    }
}
