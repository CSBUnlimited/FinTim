using SimpleInjector;

namespace FinAndTime.Entities
{
    public static class FinTimApplication
    {
        public static Container DependancyContainer { get; set; }
        public static AppSettingsEntity AppSettings { get; set; }
        public static UserEntity CurrentUser { get; set; }
    }
}
