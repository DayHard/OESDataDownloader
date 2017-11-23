using System;
using System.Windows.Forms;

namespace OESDataDownloader
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex == null) return;
            MessageBox.Show(ex.Message,@"Глобальное исключение: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
