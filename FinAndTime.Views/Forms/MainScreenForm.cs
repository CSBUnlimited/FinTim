using FinAndTime.Core.Views.Forms;
using FinAndTime.Entities;
using FinAndTime.Enums;
using FinAndTime.Views;
using FinAndTime.Views.Forms;
using FinAndTime.Views.UserControls;
using FinAndTime.Views.UserControls.Log;
using FinAndTime.Views.UserControls.Passbook;
using FinAndTime.Views.UserControls.Summary;
using FinAndTime.Views.UserControls.Task;
using FinAndTime.Views.UserControls.Transaction;
using FinAndTime.Views.UserControls.TransactionParty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinAndTime.Views.Forms
{
    public partial class MainScreenForm : Form, IMainScreenForm
    {
        private DashboardUserControl _summaryUserControl;
        private TransactionPartyUserControl _transactionPartyUserControl;
        private TransactionUserControl _transactionUserControl;
        private TaskUserControl _taskUserControl;
        private LogUserControl _logUserControl;
        private PassbookUserControl _passbookUserControl;

        private ContentItemEnum _selectedContentItemEnum;
        private ISplashScreenForm _splashScreenFrom;
        private BaseForm _baseForm;

        public MainScreenForm()
        {
            _baseForm = new BaseForm(this, SynchronizationContext.Current);
            _splashScreenFrom = FinTimApplication.DependancyContainer.GetInstance<ISplashScreenForm>();
            InitializeComponent();
            InitializeInterfaceComonents();
        }

        private void InitializeInterfaceComonents()
        {
            #region Menu Items

            MenuItemUserControl CreateMenuItem(ContentItemEnum itemButtonEnum, Image menuItemImage, string itemButtonText)
            {
                return new MenuItemUserControl(itemButtonEnum, OnMenuItemButton_Click, menuItemImage, itemButtonText)
                {
                    Size = new Size(280, 50)
                };
            }
            //Image image = global::FinAndTime.Views.Properties.Resources.summary_icon;
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Summary, Properties.Resources.summary_icon, "Dashboard"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Passbook, Properties.Resources.Passbook_icon, "Passbook"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.TransactionParty, Properties.Resources.Transaction_party_icon, "Transaction Party"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Transaction, Properties.Resources.Transaction_icon, "Transactions"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Task, Properties.Resources.Tasks_icon, "Tasks"));

            #endregion

            #region Content section

            _summaryUserControl = new DashboardUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _passbookUserControl = new PassbookUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _transactionPartyUserControl = new TransactionPartyUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _transactionUserControl = new TransactionUserControl(OnMenuItemButton_Click)
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _taskUserControl = new TaskUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _logUserControl = new LogUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _selectedContentItemEnum = ContentItemEnum.Summary;
            mainContentPanel.Controls.Add(_summaryUserControl);
            #endregion
        }

        private void OnMenuItemButton_Click(ContentItemEnum itemButtonEnum)
        {
            OnMenuItemButton_Click(itemButtonEnum, null);
        }

        private void OnMenuItemButton_Click(ContentItemEnum itemButtonEnum, object parameter)
        {
            if (_selectedContentItemEnum == itemButtonEnum)
            {
                return;
            }
            _selectedContentItemEnum = itemButtonEnum;
            mainContentPanel.Controls.Clear();

            switch (itemButtonEnum)
            {
                case ContentItemEnum.Summary:
                    mainContentPanel.Controls.Add(_summaryUserControl);
                    break;
                case ContentItemEnum.Passbook:
                    mainContentPanel.Controls.Add(_passbookUserControl);
                    break;
                case ContentItemEnum.TransactionParty:
                    mainContentPanel.Controls.Add(_transactionPartyUserControl);
                    break;
                case ContentItemEnum.Transaction:
                    mainContentPanel.Controls.Add(_transactionUserControl);
                    break;
                case ContentItemEnum.ManageTransaction:
                    mainContentPanel.Controls.Add
                    (
                        new ManageTransactionUserControl(OnMenuItemButton_Click, parameter as TransactionEntity)
                        {
                            Dock = DockStyle.Fill,
                            Visible = true,
                            Padding = new Padding(0),
                            Margin = new Padding(0)
                        }
                    );
                    break;
                case ContentItemEnum.Task:
                    mainContentPanel.Controls.Add(_taskUserControl);
                    break;
                case ContentItemEnum.LogAlert:
                    mainContentPanel.Controls.Add(_logUserControl);
                    break;
                default:
                    throw new NotImplementedException($"ContentItemEnum - {itemButtonEnum}, not implemented");
            }
        }

        /// <summary>
        /// Show Form
        /// </summary>
        public void ShowForm() => _baseForm.ShowForm();

        /// <summary>
        /// Hide Form
        /// </summary>
        public void HideForm() => _baseForm.HideForm();

        /// <summary>
        /// Close Form
        /// </summary>
        public void CloseForm() => _baseForm.CloseForm();

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with no parameter</param>
        public void RunOnMainThread(Action actionToPerform)
            => _baseForm.RunOnMainThread(actionToPerform);

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with one parameter</param>
        /// <param name="parameter">Parameter Value</param>
        public void RunOnMainThread(Action<object> actionToPerform, object parameter = null)
            => _baseForm.RunOnMainThread(actionToPerform, parameter);

        private void MainScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainScreenForm_Load(object sender, EventArgs e)
        {
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            int mainMenuWidth = FinTimApplication.AppSettings.MainMenuWidth;

            TableLayoutColumnStyleCollection coulms = contentTableLayoutPanel.ColumnStyles;
            // This coulmn has the menu
            ColumnStyle firstCoulmn = coulms[0];
            firstCoulmn.Width = (firstCoulmn.Width == 0) ? mainMenuWidth : 0;
        }

        private void logAlertButton_Click(object sender, EventArgs e)
        {
            OnMenuItemButton_Click(ContentItemEnum.LogAlert);
        }
    }
}
