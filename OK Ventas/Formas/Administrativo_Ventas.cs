using DevExpress.XtraBars;
using HK.BussinessLogic;
using HK.Fiscales;
using System;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class Administrativo_Ventas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Administrativo_Ventas()
        {
            InitializeComponent();
            this.Load += new EventHandler(Administrativo_LightLoad);
            AsegurarPantalla();
        }

        private void AsegurarPantalla()
        {
            var usuario = OK.usuario;
            if (usuario.disabled == null)
                usuario.disabled = string.Empty;
            foreach (var item in ribbon.Items)
            {
                System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Caption");
                if (caption.GetValue(item, null) != null)
                {
                    if (usuario.disabled.Contains('[' + caption.GetValue(item, null).ToString() + ']'))
                    {
                        ((BarItem)item).Visibility = BarItemVisibility.Never;
                    }
                }
            }
        }

        void Administrativo_LightLoad(object sender, EventArgs e)
        {
            // Tablas
            this.barButtonClientes.ItemClick += new ItemClickEventHandler(barButtonClientes_ItemClick);
            this.barButtonProveedores.ItemClick += new ItemClickEventHandler(barButtonProveedores_ItemClick);
            this.barButtonProductos.ItemClick += new ItemClickEventHandler(barButtonProductos_ItemClick);
            this.barButtonVendedores.ItemClick += new ItemClickEventHandler(barButtonVendedores_ItemClick);
            // Ventas 
            this.barButtonCotizaciones.ItemClick += new ItemClickEventHandler(barButtonCotizaciones_ItemClick);
            this.barButtonNotasEntrega.ItemClick += new ItemClickEventHandler(barButtonNotasEntrega_ItemClick);
            this.barButtonConsultarFacturas.ItemClick += new ItemClickEventHandler(barButtonConsultarFacturas_ItemClick);
            this.barButtonFacturacion.ItemClick += new ItemClickEventHandler(barButtonFacturacion_ItemClick);
            this.barButtonVentasxGrupos.ItemClick += new ItemClickEventHandler(barButtonVentasxGrupos_ItemClick);
            this.barButtonVentasxProducto.ItemClick += new ItemClickEventHandler(barButtonVentasxProducto_ItemClick);
            // Compras
            this.barButtonCompras.ItemClick += new ItemClickEventHandler(barButtonCompras_ItemClick);
            this.barButtonCargarProducto.ItemClick += new ItemClickEventHandler(barButtonCargarProducto_ItemClick);
            this.barButtonDescargar.ItemClick += new ItemClickEventHandler(barButtonDescargar_ItemClick);
            this.barButtonRecalculoExistencias.ItemClick += new ItemClickEventHandler(barButtonRecalculoExistencias_ItemClick);
            this.barComprasxProducto.ItemClick += new ItemClickEventHandler(barComprasxProducto_ItemClick);
            this.barComprasxGrupos.ItemClick += new ItemClickEventHandler(barComprasxGrupos_ItemClick);
            // Seniat
            this.barButtonLibroCompras.ItemClick += new ItemClickEventHandler(barButtonLibroCompras_ItemClick);
            this.barButtonLibroVentas.ItemClick += new ItemClickEventHandler(barButtonLibroVentas_ItemClick);
            this.barButtonLibroInventarios.ItemClick += new ItemClickEventHandler(barButtonLibroInventarios_ItemClick);
            //
            this.barButtonCierreDeCaja.ItemClick += new ItemClickEventHandler(barButtonCierreDeCaja_ItemClick);
            this.barButtonListadoFacturasMensuales.ItemClick += new ItemClickEventHandler(barButtonListadoFacturasMensuales_ItemClick);
            // Cobranzas
            this.barButtonCuentasxCobrar.ItemClick+=new ItemClickEventHandler(barButtonCuentasxCobrar_ItemClick);
            this.barButtonListadoGeneralCxC.ItemClick += new ItemClickEventHandler(barButtonListadoGeneralCxC_ItemClick);
            this.btnResumenCxC.ItemClick += new ItemClickEventHandler(btnListadoTotalesCxC_ItemClick);
            // Inventarios
            this.barButtonCargarProductos.ItemClick += barButtonCargarProductos_ItemClick;
            this.barButtonListadoInventarios.ItemClick += new ItemClickEventHandler(barButtonListadoInventarios_ItemClick);
            this.barButtonListadoMinimos.ItemClick += new ItemClickEventHandler(barButtonListadoMinimos_ItemClick);
            this.barButtonInventariosxProveedor.ItemClick+=barButtonInventariosxProveedor_ItemClick;
            // Utilitarios
            this.barButtonConfigurarFiscal.ItemClick += new ItemClickEventHandler(barButtonConfigurarFiscal_ItemClick);
            this.barButtonConfigurarServidor.ItemClick += new ItemClickEventHandler(barButtonConfigurarServidor_ItemClick);
            this.barConfigurarSistema.ItemClick += barConfigurarSistema_ItemClick;
            this.barConfigurarDirectorios.ItemClick += barConfigurarDirectorios_ItemClick;
            this.barConfigurarPuntoDeVenta.ItemClick += new ItemClickEventHandler(barConfigurarPuntoDeVenta_ItemClick);
            this.barButtonUsuarios.ItemClick += barButtonUsuarios_ItemClick;
            this.barButtonRespaldo.ItemClick += new ItemClickEventHandler(barButtonRespaldo_ItemClick);
            this.barButtonRecuperacion.ItemClick += new ItemClickEventHandler(barButtonRecuperacion_ItemClick);
            this.barButtonConfigurarCorreo.ItemClick += new ItemClickEventHandler(barButtonConfigurarCorreo_ItemClick);
            
            //
            this.barButtonReporteX.ItemClick+=new ItemClickEventHandler(barButtonReporteX_ItemClick);
            this.barButtonReporteZ.ItemClick+=new ItemClickEventHandler(barButtonReporteZ_ItemClick);
            this.WindowState = FormWindowState.Maximized;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        void btnListadoTotalesCxC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_ResumenCuentasxCobrar();
        }

        void barButtonListadoGeneralCxC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_ListadoGeneral();
        }

        void barButtonRecalculoExistencias_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.barButtonRecalculoExistencias.Caption = "Calculando...!";
            this.barButtonRecalculoExistencias.Enabled = false;
            Application.DoEvents();
            object result = Jacksonsoft.WaitWindow.Show(this.CalcularExistenciasWorkerMethod, "Actualizando Movimientos de Inventarios");
            this.Cursor = Cursors.Default;
            this.barButtonRecalculoExistencias.Caption = "Calcular Existencias";
            this.barButtonRecalculoExistencias.Enabled = true;

        }
        private void CalcularExistenciasWorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            Administrativo data = new Administrativo();
            data.ProductosCalcularExistencias();
            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                e.Result = "Ok";
            }
        }

        void barButtonDescargar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = new Administrativo();
            do
            {
                FrmTablas_ProductosDescargar f = new FrmTablas_ProductosDescargar();
                f.data = data;
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            while (true);
        }

        void barButtonCargarProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = new Administrativo();
            do
            {
                FrmTablas_ProductosCargar f = new FrmTablas_ProductosCargar();
                f.data = data;
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            while (true);
        }

        void barButtonVendedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Vendedores"))
            {
                var Clientes = new FrmTablas_Vendedores();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Vendedores";
                Clientes.Show();
            }
        }

        void barButtonNotasEntrega_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmVentasNotasEntrega"))
            {
                var Clientes = new FrmVentasNotasEntrega();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmVentasNotasEntrega";
                Clientes.Show();
            }
        }

        void barButtonCotizaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmVentasCotizaciones"))
            {
                var forma = new FrmVentasCotizaciones();
                forma.MdiParent = this;
                forma.Tag = "FrmVentasCotizaciones";
                forma.Show();
            }
        }

        void barButtonConsultarFacturas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmConsultarFacturas facturas = new FrmConsultarFacturas();
            facturas.ShowDialog();
        }

        void barButtonFacturacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmVentasFacturasItem"))
            {
                var form = new FrmVentasFacturas();
                form.MdiParent = this;
                form.Tag = "FrmVentasFacturasItem";
                form.Show();
            }
        }

        void barConfigurarPuntoDeVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmConfigurarPuntoDeVenta())
            {
                f.ShowDialog();
            }
        }

        void barConfigurarSistema_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_Parametros())
            {
                f.ShowDialog();
            }
        }

        void barButtonCargarProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmTablas_ProductosCargar())
            {
                f.ShowDialog();
            }
        }

        void barConfigurarDirectorios_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_Configurar())
            {
                f.ShowDialog();
            }
        }

        void barButtonConfigurarServidor_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_ConfigurarServidor())
            {
                f.ShowDialog();
            }
        }

        void barButtonConfigurarFiscal_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_Fiscal())
            {
                f.ShowDialog();
            }
        }

        void barButtonListadoMinimos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_ListadoMinimos();
        }

        void barButtonInventariosxProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_InventariosxProveedor();
        }
        void barComprasxProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almacen_ComprasxProductos();
            }
        }

        void barComprasxGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almacen_ComprasxGrupos();
            }
        }

        void barButtonCuentasxPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmCuentasxPagar"))
            {
                var form = new FrmCuentasxPagar();
                form.MdiParent = this;
                form.Tag = "FrmCuentasxPagar";
                form.Show();
            }
        }

        void barButtonCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmCompras"))
            {
                var form = new FrmCompras();
                form.MdiParent = this;
                form.Tag = "FrmCompras";
                form.Show();
            }
        }

        void barButtonCuentasxCobrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmCuentasxCobrar"))
            {
                var form = new FrmCuentasxCobrar();
                form.MdiParent = this;
                form.Tag = "FrmCuentasxCobrar";
                form.Show();
            }
        }

        void barButtonListadoFacturasMensuales_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.ReporteFacturasNaturalesyJuridicas();
            }
        }
        void barButtonCierreDeCaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmCierreDeCaja();
                f.ShowDialog();
        }

        void barButtonListadoInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almancen_ListadoInventarios();
            }
        }

        void barButtonProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Proveedores"))
            {
                var form = new FrmTablas_Proveedores();
                form.MdiParent = this;
                form.Tag = "FrmTablas_Proveedores";
                form.Show();
            }
        }
        void barButtonReporteZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de imprimir el Reporte Z", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteZ();
            Fiscal.CerrarPuerto();
        }
        void barButtonReporteX_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteX();
            Fiscal.CerrarPuerto();
        }
        void barButtonLibroInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmSeniat_LibroInventarios"))
            {
                var form = new FrmSeniat_LibroInventarios();
                form.MdiParent = this;
                form.Tag = "FrmSeniat_LibroInventarios";
                form.Show();
            }
        }

        void barButtonLibroVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmSeniat_LibroVentas"))
            {
                var form = new FrmSeniat_LibroVentas();
                form.MdiParent = this;
                form.Tag = "FrmSeniat_LibroVentas";
                form.Show();
            }
        }

        void barButtonLibroCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmSeniat_LibroCompras"))
            {
                var form = new FrmSeniat_LibroCompras();
                form.MdiParent = this;
                form.Tag = "FrmSeniat_LibroCompras";
                form.Show();
            }
        }

        void barButtonContadorDinero_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmContarDinero())
            {
                f.ShowDialog();
            }
        }

        void barButtonConfigurarCorreo_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_ConfigurarCorreo())
            {
                f.ShowDialog();
            }

        }

        void barButtonRecuperacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilitarios_Restore())
            {
                f.ShowDialog();
            }
        }

        void barButtonRespaldo_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilitarios_Backup())
            {
                f.ShowDialog();
            }
        }

        void barButtonUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmPuntoDeVentas_Usuarios"))
            {
                var form = new FrmVentas_Usuarios();
                form.MdiParent = this;
                form.Tag = "FrmVentas_Usuarios";
                form.Show();
            }
        }

        void barButtonInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almancen_ListadoInventarios();
            }
        }

        void barButtonVentasxProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almacen_VentasxProductos();
            }
        }

        void barButtonVentasxGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Almacen_VentasxDepartamento();
            }
        }

        void barButtonClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Clientes"))
            {
                var Clientes = new FrmTablas_Clientes();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Clientes";
                Clientes.Show();
            }
        }

        void barButtonAjustePreciosProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmTablas_ProductosAjustePrecios())
            {
                f.ShowDialog();
            }
        }

        void barButtonProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Productos"))
            {
                var Clientes = new FrmTablas_Productos();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Productos";
                Clientes.Show();
            }
        }
        private bool ExisteTab(string tag)
        {
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage x in Tabs.Pages)
            {
                if ((string)x.MdiChild.Tag == tag)
                {
                    Tabs.SelectedPage = x;
                    return true;
                }
            }
            return false;
        }

        private void barButtonCotizaciones_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }
    }
}
