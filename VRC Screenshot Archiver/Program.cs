using System;
using System.Windows.Forms;

namespace VRC_Screenshot_Archiver
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var archiver = new Archiver();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(archiver));
        }
    }
}