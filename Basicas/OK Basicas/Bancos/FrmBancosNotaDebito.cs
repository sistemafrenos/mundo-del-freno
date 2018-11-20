using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmBancosNotaDebito : Form
    {
        public Banco banco;
        Administrativo data;
        public BancosMovimiento registro = new BancosMovimiento();


        public FrmBancosNotaDebito()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmBancosNotaDebito_Load);
        }
        void  FrmBancosNotaDebito_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }
        private void Limpiar()
        {
            registro = new BancosMovimiento();
            if (banco.ID != null)
            {
                this.cuentaBancaria.Enabled = false;
                this.cuentaBancaria.Text = banco.Cuenta;
            }
            registro.Tipo = "NOTA DB";
            registro.Fecha = DateTime.Today;
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            if (registro == null)
            {
                Limpiar();
            }
            else
            {
                if (string.IsNullOrEmpty(this.cuentaBancaria.Text))
                {
                    if (registro.Banco != null)
                    {
                        if (registro.Banco.Cuenta != null)
                        {
                            this.cuentaBancaria.Text = registro.Banco.Cuenta;
                        }
                    }
                }
            }
            this.bancosMovimientoBindingSource.DataSource = registro;
            this.bancosMovimientoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            bancosMovimientoBindingSource.EndEdit();
            registro = (BancosMovimiento)bancosMovimientoBindingSource.Current;
            // registro.Banco = banco;
            registro.Numero = this.NumeroTextEdit.Text;
            if (!Guardar())
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool Guardar()
        {
            try
            {
                //if (!db.Entry(registro).GetValidationResult().IsValid)
                //{
                //    Basicas.ErroresDeValidacion(db.Entry(registro).GetValidationResult());
                //    return false;
                //}
                //if (db.Entry(registro).State == EntityState.Detached)
                //{
                //    db.BancosMovimientos.Add(registro);
                //}
                //db.SaveChanges();
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
                return false;
            }
            return true;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.bancosMovimientoBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }

        public void Ver()
        {
            Enlazar();
            this.datos.Enabled = false;
            this.ShowDialog();
        }
    }
}
