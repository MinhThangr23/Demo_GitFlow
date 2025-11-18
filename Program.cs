using log4net;
using log4net.Config;
namespace Menu_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // Khai báo m?t logger cho Program.cs 
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        [STAThread]
        static void Main()
        {
            // Yêu c?u Log4net ??c file config 
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            // Ghi m?t dòng log test ngay khi app kh?i ??ng
            log.Info("--- UNG DUNG BAT DAU---");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());

        }
    }
}