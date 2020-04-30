using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinAndTime.Entities;
using FinAndTime.Core.Service;

namespace FinAndTime.Views.UserControls.Passbook
{
    public partial class PassbookUserControl : UserControl, IDisposable
    {
        private BindingList<TransactionLogBinder> _transactionLogs;
        private IApplicationService _applicationService;

        public PassbookUserControl()
        {
            _applicationService = FinTimApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();

            _applicationService.TransactionLogsOnChange += TransactionLogsOnChange;
            _applicationService.TransactionPartiesOnChange += TransactionPartiesOnChange; ;
            UpdateTransactionLogBinders();
        }

        private void TransactionPartiesOnChange(IEnumerable<TransactionPartyEntity> currentValueList)
        {
            UpdateTransactionLogBinders();
        }

        public void TransactionLogsOnChange(IEnumerable<TransactionLogEntity> transactionLogEntities)
        {
            UpdateTransactionLogBinders();
        }

        public void UpdateTransactionLogBinders()
        {
            IList<TransactionLogBinder> transactionLogBinders = new List<TransactionLogBinder>();

            IEnumerable<TransactionLogEntity> tranLogs = _applicationService.TransactionLogs.OrderBy(t => t.TransactionDateTime);
            foreach (TransactionLogEntity transactionLog in tranLogs)
            {
                TransactionPartyEntity transactionParty = _applicationService.TransactionParties.First(tp => tp.Id == transactionLog.TransactionPartyId);
                transactionLogBinders.Add(new TransactionLogBinder(transactionLog, transactionParty));
            }

            _transactionLogs = new BindingList<TransactionLogBinder>(transactionLogBinders);
            dataGridView.DataSource = _transactionLogs;
        }

        public new void Dispose()
        {
            _applicationService.TransactionLogsOnChange -= TransactionLogsOnChange;
            base.Dispose();
        }
    }

    class TransactionLogBinder
    {
        public TransactionLogBinder()
        { }

        public TransactionLogBinder(TransactionLogEntity transactionLog, TransactionPartyEntity transactionParty)
        {
            TransactionDate = transactionLog.TransactionDateTime;
            Remarks = transactionLog.Remarks;
            Amount = (transactionLog.IsIncome ? transactionLog.Amount : -1.0 * transactionLog.Amount).ToString("0.00");
            Balance = (transactionLog.FinalBalance).ToString("0.00");
            TransactionPartyCode = transactionParty.Code;
        }

        public DateTime TransactionDate { get; set; }
        public string Remarks { get; set; }
        public string TransactionPartyCode { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
