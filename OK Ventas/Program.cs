using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.Formas;
using System.Data.Entity.Migrations;
using HK.Migrations;

namespace HK
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
            DatosEntities data = new DatosEntities();
            data.CheckDatabase();
            data = null;
            FrmLogin login = new FrmLogin() { Sistema = "OK VENTAS Y FACTURACION" };
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                if (OK.usuario != null)
                {
                    Application.Run(new  Formas.Administrativo_Ventas());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

    }
}
