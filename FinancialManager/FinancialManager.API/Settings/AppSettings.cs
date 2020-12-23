using System;
using System.Threading;

namespace FinancialManager.API.Settings
{
    public class AppSettings
    {
        private static readonly Lazy<AppSettings> Factory = new Lazy<AppSettings>(
            () => new AppSettings(), LazyThreadSafetyMode.PublicationOnly
        );

        public static AppSettings Instance => Factory.Value;

        public DatabaseSettings Database { get; set; }
    }
}
