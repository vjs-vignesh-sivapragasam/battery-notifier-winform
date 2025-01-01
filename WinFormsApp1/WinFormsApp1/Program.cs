using Microsoft.Win32;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Console.WriteLine("Application Started");
            Application.Run(new Form1());
        }

        private static void SetStartup()
        {
            string appName = "BatteryNotifier";
            string exePath = Application.ExecutablePath;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key.GetValue(appName) == null)
                {
                    key.SetValue(appName, exePath);
                }
            }
        }
    }
}