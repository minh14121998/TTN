using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy.GUI;

namespace QuanLy
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fLog = new frmLogin();
            Application.Run(fLog);
            //frmConnection frmcon = new frmConnection();
           // Application.Run(frmcon);
        }
    }
}
