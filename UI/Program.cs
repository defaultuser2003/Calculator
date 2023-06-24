using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CaculatorUI());
        }
    }
}
