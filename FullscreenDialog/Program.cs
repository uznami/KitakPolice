using System;
using System.Windows.Forms;

namespace FullscreenDialog
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var message = args[0];
            var timeout = (args.Length >= 2) ? int.Parse(args[1]) : null as int?;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(message, timeout));
        }
    }
}
