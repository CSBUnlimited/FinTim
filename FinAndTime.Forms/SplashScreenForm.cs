using FinAndTime.Core.Views;
using FinAndTime.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinAndTime.Forms
{
    public partial class SplashScreenForm : Form, ISplashScreenForm
    {
        private bool _isReadyToClose = false;
        private SynchronizationContext _currentSynchronizationContext;

        public SplashScreenForm()
        {
            _currentSynchronizationContext = SynchronizationContext.Current;
            InitializeComponent();

            bwInitialWorker.RunWorkerAsync();
        }

        private void bwInitialWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;

            SimpleInjector.Container container = FinTimApplication.DependancyContainer;
            ITest test = container.GetInstance<ITest>();
            string t = test.Testing();
            Thread.Sleep(2000);
            RunOnMainThread(() =>
            {
                new MainScreenForm(this).Show();
                this.Hide();
            });
        }

        private void bwInitialWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            SetProgressStatusText("Loading...");
        }

        private void SplashScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isReadyToClose)
            {
                e.Cancel = true;
                this.Show();
                SetProgressStatusText("Closing...");
                ReleaseResourcesToExit();
            }
        }

        public void SetProgressStatusText(string text)
        {
            RunOnMainThread(() => lblProgressStatus.Text = text);
        }

        private void ReleaseResourcesToExit()
        {
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                RunOnMainThread(() =>
                {
                    _isReadyToClose = true;
                    this.Close();
                });
            });
        }

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with one parameter</param>
        /// <param name="parameter">Parameter Value</param>
        private void RunOnMainThread(Action<object> actionToPerform, object parameter = null)
        {
            _currentSynchronizationContext.Post((object ob) => actionToPerform(parameter), parameter);
        }

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with no parameter</param>
        private void RunOnMainThread(Action actionToPerform)
        {
            _currentSynchronizationContext.Post((object ob) => actionToPerform(), null);
        }

        public void ShowForm()
        {
            RunOnMainThread(() =>
            {
                this.Show();
            });
        }

        public void HideForm()
        {
            RunOnMainThread(() =>
            {
                this.Hide();
            });
        }
    }
}
