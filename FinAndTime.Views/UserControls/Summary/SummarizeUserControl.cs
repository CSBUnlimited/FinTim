using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinAndTime.Core.Service;
using FinAndTime.Entities;

namespace FinAndTime.Views.UserControls.Summary
{
    public partial class SummarizeUserControl : UserControl
    {
        private IApplicationService _applicationService;
        private BindingList<TransactionBinder> _transactionBinders;

        public SummarizeUserControl()
        {
            _applicationService = FinTimApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionsOnChange += TransactionsOnChange;
            _applicationService.CurrentUserOnChange += CurrentUserOnChange;
            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange;
        }

        private void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void CurrentUserOnChange(UserEntity userEntity)
        {
            greetingLabel.Text = $"Hello, {userEntity.FirstName}";
            currentBalanceLabel.Text = userEntity.CurrentBalance.ToString("0.00");
        }

        private void TransactionsOnChange(IEnumerable<TransactionEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void UpdateTransactionBinders()
        {
            BindingList<TransactionBinder> transactionBinders = new BindingList<TransactionBinder>();

            IEnumerable<TransactionEntity> trans = _applicationService.Transactions.OrderByDescending(t => t.TransactionDateTime).Take(10);
            foreach (TransactionEntity transaction in trans)
            {
                if (transaction.IsActive)
                {
                    TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == transaction.TransactionPartyId);
                    transactionBinders.Add(new TransactionBinder(transaction, transactionParty));
                }
            }

            _transactionBinders = transactionBinders;
            dataGridView.DataSource = _transactionBinders;
        }

        public new void Dispose()
        {
            _applicationService.TransactionsOnChange -= TransactionsOnChange;
            _applicationService.CurrentUserOnChange -= CurrentUserOnChange;
            _applicationService.TransactionPartiesOnChange -= TransactionPartiesOnChange;
            base.Dispose();
        }

        private void SummarizeUserControl_Load(object sender, EventArgs e)
        {
            CurrentUserOnChange(_applicationService.CurrentUser);
            UpdateTransactionBinders();
        }
    }

    class TransactionBinder
    {
        public TransactionBinder()
        { }

        public TransactionBinder(TransactionEntity transactionEntity, TransactionPartyEntity transactionPartyEntity)
        {
            ReferenceNumber = transactionEntity.ReferenceNumber;
            TransactionPartyCode = transactionPartyEntity.Code;
            Amount = ((transactionEntity.IsIncome ? 1 : -1) * transactionEntity.Amount).ToString("0.00");
            TransactionDateTime = transactionEntity.TransactionDateTime;
        }

        public string ReferenceNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionPartyCode { get; set; }
        public string Amount { get; set; }
    }
}
