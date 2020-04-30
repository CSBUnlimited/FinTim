using FinAndTime.Core.Models;
using FinAndTime.DataAccess;

namespace FinAndTime.Models
{
    public class ApplicationModel : IApplicationModel
    {
        public bool IsApplicationRunning { get; set; } = false;
        public bool IsDatabaseInitialized => SqliteConnector.IsDatabaseInitialized;
        public void InitializeDatabase() => SqliteConnector.InitializeDatabase();
    }
}
