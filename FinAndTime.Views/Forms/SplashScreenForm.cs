using FinAndTime.Core.Models;
using FinAndTime.Core.Service;
using FinAndTime.Core.Views.Forms;
using FinAndTime.Entities;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinAndTime.Views.Forms
{
    public partial class SplashScreenForm : Form, ISplashScreenForm
    {
        private BaseForm _baseForm;
        private IApplicationService _applicationService;

        public SplashScreenForm()
        {
            _baseForm = new BaseForm(this, SynchronizationContext.Current);
            _applicationService = FinTimApplication.DependancyContainer.GetInstance<IApplicationService>();

            InitializeComponent();
            userRegistrationPanel.Visible = false;
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

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            SetProgressStatusText("Loading...");
        }

        private void SplashScreenForm_Shown(object sender, EventArgs e)
        {
            InitialLoadingProcess();
        }

        private void InitialLoadingProcess()
        {
            SetProgressStatusText("Loading...");
            _applicationService.InitialLoadingProcessAsync
            (
                SetProgressStatusText,
                () =>
                {
                    RunOnMainThread(() =>
                    {
                        MainScreenForm main = new MainScreenForm();
                        main.Show();
                        HideForm();
                    });
                },
                () =>
                {
                    SetUserRegistrationPanelVisible(true);
                    SetProgressStatusText("Waiting for provide user information...");
                }
            );
        }

        private void SetUserRegistrationPanelVisible(bool visible)
        {
            RunOnMainThread(() =>
            {
                userRegistrationPanel.Visible = visible;
            });
        }

        private void SplashScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowForm();
            SetUserRegistrationPanelVisible(false);

            _applicationService.ReleaseResourcesToExit
            (
                SetProgressStatusText,
                () => e.Cancel = true,
                () =>
                {
                    RunOnMainThread(() =>
                    {
                        Application.Exit();
                    });
                }
            );
        }

        public void SetProgressStatusText(string text)
        {
            RunOnMainThread(() => lblProgressStatus.Text = text);
        }

        private void contentHeaderUserControl_BackButtonOnClick(object sender, EventArgs e)
        {
            SetProgressStatusText("User information not provided...");
            Application.Exit();
        }

        private void EnableUserRegistrationForm(bool isEnabled)
        {
            RunOnMainThread(() =>
            {
                userDetailsSaveButton.Enabled = isEnabled;
                userFirstNameTextBox.Enabled = isEnabled;
                userLastNameTextBox.Enabled = isEnabled;
                userStartingBalanceTextBox.Enabled = isEnabled;
                userRegistrationContentHeaderUserControl.BackButtonVisible = isEnabled;
            });
        }

        private void userDetailsSaveButton_Click(object sender, EventArgs e)
        {
            EnableUserRegistrationForm(false);
            userRegistrationErrorLabel.Text = string.Empty;

            string firstName = userFirstNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(firstName))
            {
                userRegistrationErrorLabel.Text = "First name cannot be empty...";
                EnableUserRegistrationForm(true);
                return;
            }

            string lastName = userLastNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                userRegistrationErrorLabel.Text = "Last name cannot be empty...";
                EnableUserRegistrationForm(true);
                return;
            }

            if (!double.TryParse(userStartingBalanceTextBox.Text, out double startingAmount))
            {
                userRegistrationErrorLabel.Text = "Starting balance should be numerical...";
                EnableUserRegistrationForm(true);
                return;
            }

            UserEntity userEntity = new UserEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                StartingAmount = startingAmount
            };

            Task.Run(() =>
            {
                SetProgressStatusText("Saving user information...");
                _applicationService.InsertUserEntityAsync(userEntity);
                Thread.Sleep(250);
                SetUserRegistrationPanelVisible(false);
                EnableUserRegistrationForm(true);
                InitialLoadingProcess();
            });
        }
    }
}
