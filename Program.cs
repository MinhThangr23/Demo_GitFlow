ï»¿using Serilog;
namespace Menu_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // Khai bÃ¡o m?t logger cho Program.cs 
        [STAThread]
        static void Main()
        {
             // Khá»i táº¡o Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose() // Thiáº¿t láº­p má»©c log tá»i thiá»u lÃ  Verbose Äá» ghi láº¡i táº¥t cáº£ cÃ¡c má»©c log
                .WriteTo.File("C:/Users/PC/OneDrive/MÃ¡y tÃ­nh/Demo_GitFlow/logs/app_log.txt", 
                    rollingInterval: RollingInterval.Day, 
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")// Äá»nh dáº¡ng log vá»i timestamp, má»©c Äá» log, vÃ  thÃ´ng Äiá»p
                .CreateLogger();
            Log.Information("----- á»¨NG Dá»¤NG KHá»I Äá»NG -----");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            // ÄÃ³ng log khi táº¯t app
            Log.CloseAndFlush();
        }
    }
}