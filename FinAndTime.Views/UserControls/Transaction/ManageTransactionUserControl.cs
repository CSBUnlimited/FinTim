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
using FinAndTime.Enums;
using FinAndTime.Core.Service;

namespace FinAndTime.Views.UserControls.Transaction
{
    public partial class ManageTransactionUserControl : UserControl
    {
        private TransactionEntity _transactionEntity;
        private Action<ContentItemEnum> _changeContentMainFormAction;
        private IApplicationService _applicationService;
        private BindingList<TransactionPartyBinder> _transactionParties;

        //[Browsable(true)]
        //[Description("Trigger when back button clicked"), Category("Action"),]
        //public event EventHandler BackButtonOnClick;

        //[Browsable(true)]
        //[Description("Trigger when delete button clicked"), Category("Action"),]
        //public event EventHandler DeleteButtonOnClick;

        //[Browsable(true)]
        //[Description("Trigger when save button clicked"), Category("Action"),]
        //public event EventHandler SaveButtonOnClick;

        public ManageTransactionUserControl(Action<ContentItemEnum> changeContentMainFormAction)
        {
            _changeContentMainFormAction = changeContentMainFormAction;
            _applicationService = FinTimApplication.DependancyContainer.GetInstance<IApplicationService>();
            _transactionEntity = null;
            InitializeComponent();
        }

        public ManageTransactionUserControl(Action<ContentItemEnum> changeContent, TransactionEntity transactionEntity) : this(changeContent)
        {
            _transactionEntity = transactionEntity;
        }

        private void SetTransactionEntity(TransactionEntity transactionEntity = null)
        {
            _transactionEntity = transactionEntity ?? new TransactionEntity()
            {
                IsIncome = true,
                Amount = 0D,
                ReferenceNumber = "",
                Remarks = "",
                TransactionPartyId = 0
            };

            if (_transactionEntity.Id == 0)
            {
                referenceNumberPanel.Visible = false;
                transactionPartyComboBox.SelectedIndex = -1;
            }
            else
            {
                referenceNumberPanel.Visible = true;
                referenceNumberTextBox.Text = _transactionEntity.ReferenceNumber;
                transactionPartyComboBox.SelectedItem = _transactionParties.First(tp => tp.Id == _transactionEntity.TransactionPartyId);
            }

            transactionPartErrorLabel.Text = "";

            amountNumericUpDown.Text = _transactionEntity.Amount.ToString();
            amountErrorLabel.Text = "";
            remarksTextBox.Text = _transactionEntity.Remarks;
            remarksErrorLabel.Text = "";
            incomeCheckBox.Checked = _transactionEntity.IsIncome;
        }

        private void contentHeaderUserControl_BackButtonOnClick(object sender, EventArgs e)
        {
            _changeContentMainFormAction(ContentItemEnum.Transaction);
        }

        private void ManageTransactionUserControl_Load(object sender, EventArgs e)
        {
            _transactionParties = new BindingList<TransactionPartyBinder>();

            foreach (TransactionPartyEntity tranParty in _applicationService.TransactionParties)
            {
                if (tranParty.IsActive)
                {
                    _transactionParties.Add(new TransactionPartyBinder(tranParty));
                }
            }

            transactionPartyComboBox.DataSource = _transactionParties;
            transactionPartyComboBox.DisplayMember = "DisplayValue";
            transactionPartyComboBox.ValueMember = "Id";

            SetTransactionEntity(_transactionEntity);

            if (_transactionEntity.Id == 0)
            {
                actionsUserControl.DeleteButtonVisible = false;
                actionsUserControl.ResetButtonVisible = true;
                contentHeaderUserControl.MainTitle = "Add Transaction";
            }
            else
            {
                actionsUserControl.DeleteButtonVisible = true;
                actionsUserControl.ResetButtonVisible = false;
                contentHeaderUserControl.MainTitle = "Update Transaction";
            }
        }

        private bool IsFormDataValid()
        {
            bool isValid = true;

            int id = _transactionEntity.Id;
            string remarks = remarksTextBox.Text;
            string amount = amountNumericUpDown.Text;
            double amountDouble;
            int transactionParty = transactionPartyComboBox.SelectedIndex;

            if (string.IsNullOrWhiteSpace(remarks))
            {
                isValid = false;
                remarksErrorLabel.Text = "Remark is required";
            }
            else
            {
                remarksErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(amount))
            {
                isValid = false;
                amountErrorLabel.Text = "Amount is required";
            }
            else if (!double.TryParse(amount, out amountDouble))
            {
                isValid = false;
                amountErrorLabel.Text = "Amount need to be numeric";
            }
            else if (amountDouble <= 0)
            {
                isValid = false;
                amountErrorLabel.Text = "Amount should greater than zero";
            }
            else
            {
                amountErrorLabel.Text = "";
            }

            if (transactionParty < 0)
            {
                isValid = false;
                transactionPartErrorLabel.Text = "Transaction Party is required";
            }
            else
            {
                transactionPartErrorLabel.Text = "";
            }

            return isValid;
        }

        private async void actionsUserControl_SaveButtonOnClick(object sender, EventArgs e)
        {
            if (IsFormDataValid())
            {
                tableLayoutPanel.Enabled = false;
                actionsUserControl.IsEnabledButtons = false;

                int id = _transactionEntity.Id;
                string remarks = remarksTextBox.Text;
                double amount = double.Parse(amountNumericUpDown.Text);
                TransactionPartyBinder transactionParty = transactionPartyComboBox.SelectedItem as TransactionPartyBinder;

                TransactionEntity transactionEntity = new TransactionEntity()
                {
                    Id = id,
                    Amount = amount,
                    IsIncome = incomeCheckBox.Checked,
                    Remarks = remarks,
                    TransactionPartyId = transactionParty.Id,
                    IsUserPerformed = true,
                    ScheduledTransactionId = null,
                    TransactionDateTime = DateTime.Now
                };

                if (id == 0)
                {
                    await _applicationService.InsertTransactionAsync(transactionEntity, true);
                }
                else
                {
                    await _applicationService.UpdateTransactionAsync(transactionEntity);
                }

                _changeContentMainFormAction(ContentItemEnum.Transaction);
            }
        }

        private async void actionsUserControl_DeleteButtonOnClick(object sender, EventArgs e)
        {
            if (_transactionEntity.Id > 0)
            {
                tableLayoutPanel.Enabled = false;
                actionsUserControl.IsEnabledButtons = false;

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this transaction?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    await _applicationService.DeleteTransactionAsync(_transactionEntity.Id);
                    _changeContentMainFormAction(ContentItemEnum.Transaction);
                }

                tableLayoutPanel.Enabled = true;
                actionsUserControl.IsEnabledButtons = true;
            }
        }

        private void actionsUserControl_ResetButtonOnClick(object sender, EventArgs e)
        {
            if (_transactionEntity.Id == 0)
            {
                SetTransactionEntity();
            }
        }
    }

    class TransactionPartyBinder
    {
        public TransactionPartyBinder()
        { }

        public TransactionPartyBinder(TransactionPartyEntity transactionPartyEntity)
        {
            Id = transactionPartyEntity.Id;
            DisplayValue = $"{transactionPartyEntity.Code} - {transactionPartyEntity.Description}";
        }

        public int Id { get; set; }
        public string DisplayValue { get; set; }
    }
}

