using FinAndTime.Core.Models;
using FinAndTime.Core.Service;
using FinAndTime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinAndTime.Service
{
    public partial class ApplicationService : IApplicationService
    {
        private IApplicationModel _applicationModel;
        private IUserModel _userModel;
        private ITransactionLogModel _transactionLogModel;
        private ITransactionPartyModel _transactionPartyModel;
        private ITransactionModel _transactionModel;

        public event NotifyDataChangesEvent<UserEntity> CurrentUserOnChange;
        public UserEntity CurrentUser
        {
            get => FinTimApplication.CurrentUser;
            private set
            {
                FinTimApplication.CurrentUser = value;
                CurrentUserOnChange?.Invoke(FinTimApplication.CurrentUser);
            }
        }

        public event NotifyDataChangesListEvent<TransactionLogEntity> TransactionLogsOnChange;
        private IEnumerable<TransactionLogEntity> _transactionLogs = new List<TransactionLogEntity>();
        public IEnumerable<TransactionLogEntity> TransactionLogs { 
            get => _transactionLogs; 
            private set
            {
                _transactionLogs = value?.OrderByDescending(tl => tl.TransactionDateTime).ToList() ?? new List<TransactionLogEntity>();
                TransactionLogsOnChange?.Invoke(_transactionLogs);
            }
        }

        public event NotifyDataChangesListEvent<TransactionEntity> TransactionsOnChange;
        private IEnumerable<TransactionEntity> _transactions = new List<TransactionEntity>();
        public IEnumerable<TransactionEntity> Transactions
        {
            get => _transactions;
            private set
            {
                _transactions = value?.OrderByDescending(tl => tl.TransactionDateTime).ToList() ?? new List<TransactionEntity>();
                TransactionsOnChange?.Invoke(_transactions);
            }
        }

        public event NotifyDataChangesListEvent<TransactionPartyEntity> TransactionPartiesOnChange;
        private IEnumerable<TransactionPartyEntity> _transactionParties = new List<TransactionPartyEntity>();
        public IEnumerable<TransactionPartyEntity> TransactionParties
        {
            get => _transactionParties;
            private set
            {
                _transactionParties = value ?? new List<TransactionPartyEntity>();
                TransactionPartiesOnChange?.Invoke(_transactionParties);
            }
        }

        public ApplicationService()
        {
            _applicationModel = FinTimApplication.DependancyContainer.GetInstance<IApplicationModel>();
            _userModel = FinTimApplication.DependancyContainer.GetInstance<IUserModel>();
            _transactionLogModel = FinTimApplication.DependancyContainer.GetInstance<ITransactionLogModel>();
            _transactionPartyModel = FinTimApplication.DependancyContainer.GetInstance<ITransactionPartyModel>();
            _transactionModel = FinTimApplication.DependancyContainer.GetInstance<ITransactionModel>();
        }

        public async Task InitialLoadingProcessAsync(Action<string> setProgressStatusTextAction, Action loadMainForm, Action showUserRegistraion)
        {
            if (!_applicationModel.IsApplicationRunning)
            {
                await Task.Run(async () =>
                {
                    setProgressStatusTextAction("Loading...");
                    Thread.Sleep(500);

                    setProgressStatusTextAction("Checking database...");
                    Thread.Sleep(500);

                    if (!_applicationModel.IsDatabaseInitialized)
                    {
                        setProgressStatusTextAction("Initializing database...");
                        Thread.Sleep(500);
                        _applicationModel.InitializeDatabase();
                    }

                    setProgressStatusTextAction("Initializing application data...");
                    await InitializeApplicationData();
                    Thread.Sleep(500);

                    setProgressStatusTextAction("Checking user information...");
                    Thread.Sleep(500);
                    if (CurrentUser == null)
                    {
                        setProgressStatusTextAction("User information not found...");
                        Thread.Sleep(250);
                        showUserRegistraion();
                        return;
                    }

                    setProgressStatusTextAction($"Welcome, {CurrentUser.FirstName}...");
                    Thread.Sleep(1000);

                    loadMainForm();

                    _applicationModel.IsApplicationRunning = true;
                });

            }
        }

        private async Task InitializeApplicationData()
        {
            CurrentUser = await _userModel.GetUserDetailsAsync();
            TransactionLogs = await _transactionLogModel.GetTransactionLogsAsync();
            TransactionParties = await _transactionPartyModel.GetTransactionPartiesAsync();
            Transactions = await _transactionModel.GetTransactionsAsync();
        }

        public void ReleaseResourcesToExit(Action<string> SetProgressStatusText, Action preventApplicationExitAction, Action exitApplicationAction)
        {
            if (_applicationModel.IsApplicationRunning)
            {
                preventApplicationExitAction();

                Task.Run(() =>
                {
                    SetProgressStatusText("Closing...");
                    Thread.Sleep(1000);
                    _applicationModel.IsApplicationRunning = false;
                    exitApplicationAction();
                });
            }
        }
    }
}
