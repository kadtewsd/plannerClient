using PlannerClient.Forms;
using System;
using System.Windows.Forms;

namespace PlannerClient
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new O365ServiceForm());
        }
    }
}
