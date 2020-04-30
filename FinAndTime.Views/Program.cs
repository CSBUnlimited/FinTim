using FinAndTime.Core.Models;
using FinAndTime.Core.Service;
using FinAndTime.Core.Views.Forms;
using FinAndTime.Entities;
using FinAndTime.Models;
using FinAndTime.Service;
using FinAndTime.Views.Forms;
using SimpleInjector;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FinAndTime.Views
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterDependancies();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((SplashScreenForm)FinTimApplication.DependancyContainer.GetInstance<ISplashScreenForm>());
        }

        static void RegisterDependancies()
        {
            FinTimApplication.DependancyContainer = new Container();

            // App Settings register
            FinTimApplication.AppSettings = new AppSettingsEntity()
            {
                MainMenuWidth = int.Parse(ConfigurationManager.AppSettings["MainMenuWidth"]),
                UserInfoXmlPath = ConfigurationManager.AppSettings["UserInfoXmlPath"],
                SQLiteDatabasePath = ConfigurationManager.AppSettings["SQLiteDatabasePath"],
                LogFileFolderPath = ConfigurationManager.AppSettings["LogFileFolderPath"],
                SQLiteDatabaseConnectionString = ConfigurationManager.ConnectionStrings["SQLiteDatabase"].ConnectionString
            };

            FinTimApplication.DependancyContainer.Register(() => FinTimApplication.AppSettings, Lifestyle.Singleton);

            // Data access
            FinTimApplication.DependancyContainer.Register(() => new SQLiteConnection(FinTimApplication.AppSettings.SQLiteDatabaseConnectionString), Lifestyle.Transient);

            // Models
            FinTimApplication.DependancyContainer.Register<IApplicationModel, ApplicationModel>(Lifestyle.Singleton);
            FinTimApplication.DependancyContainer.Register<IUserModel, UserModel>(Lifestyle.Singleton);
            FinTimApplication.DependancyContainer.Register<ITransactionLogModel, TransactionLogModel>(Lifestyle.Singleton);
            FinTimApplication.DependancyContainer.Register<ITransactionPartyModel, TransactionPartyModel>(Lifestyle.Singleton);
            FinTimApplication.DependancyContainer.Register<ITransactionModel, TransactionModel>(Lifestyle.Singleton);

            // Services
            FinTimApplication.DependancyContainer.Register<IApplicationService, ApplicationService>(Lifestyle.Singleton);

            // Form
            FinTimApplication.DependancyContainer.Register<ISplashScreenForm, SplashScreenForm>(Lifestyle.Singleton);
        }
    }
}
