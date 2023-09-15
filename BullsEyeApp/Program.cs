using System;
using System.Windows.Forms;

namespace BullsEyeApp
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameManager.RunGame();
        }
    }
}
