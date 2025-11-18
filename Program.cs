using Serilog;
namespace Menu_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // Khai báo m?t logger cho Program.cs 
        [STAThread]
        static void Main()
        {
             // Khởi tạo Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:/Users/PC/OneDrive/Máy tính/Demo_GitFlow/logs/app_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("----- ỨNG DỤNG KHỞI ĐỘNG -----");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            // Đóng log khi tắt app
            Log.CloseAndFlush();
        }
    }
}