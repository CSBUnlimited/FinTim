using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinAndTime.Core.Views.UserControls;
using FinAndTime.Enums;
using FinAndTime.Entities;
using FinAndTime.Core.Service;

namespace FinAndTime.Views.UserControls.Transaction
{
    public partial class TransactionUserControl : UserControl, ITransactionUserControl
    {
        private Action<ContentItemEnum, object> _changeContentMainFormAction;
        private IApplicationService _applicationService;
        private BindingList<TransactionBinder> _transactionBinders;

        public TransactionUserControl(Action<ContentItemEnum, object> changeContentMainFormAction)
        {
            _changeContentMainFormAction = changeContentMainFormAction;
            _applicationService = FinTimApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange;
            _applicationService.TransactionsOnChange += TransactionsOnChange;
        }

        private void TransactionsOnChange(IEnumerable<TransactionEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> currentValueList)
        {
            UpdateTransactionBinders();
        }

        private void UpdateTransactionBinders()
        {
            BindingList<TransactionBinder> transactionBinders = new BindingList<TransactionBinder>();

            IEnumerable<TransactionEntity> trans = _applicationService.Transactions.OrderByDescending(t => t.TransactionDateTime);
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

        private void contentHeaderUserControl_AddButtonOnClick(object sender, EventArgs e)
        {
            _changeContentMainFormAction(ContentItemEnum.ManageTransaction, null);
        }

        public new void Dispose()
        {
            _applicationService.TransactionPartiesOnChange -= TransactionPartiesOnChange;
            _applicationService.TransactionsOnChange -= TransactionsOnChange;
            base.Dispose();
        }

        private void TransactionUserControl_Load(object sender, EventArgs e)
        {
            UpdateTransactionBinders();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TransactionBinder transactionBinder = _transactionBinders[e.RowIndex];
                TransactionEntity transaction = _applicationService.Transactions.First(t => t.ReferenceNumber == transactionBinder.ReferenceNumber);
                _changeContentMainFormAction(ContentItemEnum.ManageTransaction, transaction);
            }
        }

        private async void reportButton_Click(object sender, EventArgs e)
        {
            await _applicationService.GenarateTransactionReportAsync();
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
            IsScheduledTransaction = transactionEntity.ScheduledTransactionId == null ? "No" : "Yes";
            TransactionDateTime = transactionEntity.TransactionDateTime;
            Remarks = transactionEntity.Remarks;
            PerformedBy = transactionEntity.IsUserPerformed ? "User" : "System";
        }

        public string ReferenceNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionPartyCode { get; set; }
        public string IsScheduledTransaction { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string PerformedBy { get; set; }
    }
}
