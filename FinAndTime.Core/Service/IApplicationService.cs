using FinAndTime.Core.Models;
using FinAndTime.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinAndTime.Core.Service
{
    public partial interface IApplicationService
    {
        event NotifyDataChangesEvent<UserEntity> CurrentUserOnChange;
        UserEntity CurrentUser { get; }

        event NotifyDataChangesListEvent<TransactionLogEntity> TransactionLogsOnChange;
        IEnumerable<TransactionLogEntity> TransactionLogs { get; }

        event NotifyDataChangesListEvent<TransactionEntity> TransactionsOnChange;
        IEnumerable<TransactionEntity> Transactions { get; }
        event NotifyDataChangesListEvent<TransactionPartyEntity> TransactionPartiesOnChange;
        IEnumerable<TransactionPartyEntity> TransactionParties { get; }

        Task InitialLoadingProcessAsync(Action<string> setProgressStatusTextAction, Action loadMainForm, Action showUserRegistraion);
        void ReleaseResourcesToExit(Action<string> SetProgressStatusText, Action preventApplicationExitAction, Action exitApplicationAction);
        Task<UserEntity> InsertUserEntityAsync(UserEntity userEntity);


        Task<TransactionPartyEntity> InsertTransactionPartyAsync(TransactionPartyEntity transactionParty);
        bool IsTransactionPartyCodeUsed(string code);
        bool IsTransactionPartyCodeUsedWithoutCurrent(string code, int currentId);
        Task<TransactionPartyEntity> UpdateTransactionPartyAsync(TransactionPartyEntity transactionParty);
        Task DeleteTransactionPartyAsync(int id);

        Task<TransactionEntity> InsertTransactionAsync(TransactionEntity transaction, bool isUserPerformed = false);
        Task<TransactionEntity> UpdateTransactionAsync(TransactionEntity transaction);
        Task DeleteTransactionAsync(int id);

        bool IsAvailableEnoughtData(int monthBack);
        Task<PredictionEntity> GetPredictionsAsync(int monthsBack, DateTime predictDate);
    }
}
