using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace winAjanda
{



    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form2 loginForm = new Form2();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Form1 mainForm = new Form1();
                Application.Run(mainForm);
            }
        }
    }


}
