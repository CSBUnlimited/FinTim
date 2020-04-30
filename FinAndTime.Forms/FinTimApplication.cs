using FinAndTime.Entities;
using SimpleInjector;

namespace FinAndTime.Forms
{
    public static class FinTimApplication
    {
        public static Container DependancyContainer;

        static FinTimApplication()
        {
            FinTimApplication.DependancyContainer = new Container();

            DependancyContainer.Register<ITest, Test>(Lifestyle.Singleton);
        }
    }
}
