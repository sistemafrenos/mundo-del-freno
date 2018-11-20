using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;
using System.Drawing;
using System.Text;
using DevExpress.XtraBars;

namespace HK.Formas
{
    public partial class FrmVentas_UsuariosItem : Form
    {
        Usuario usuario;
        Administrativo data;
        public DevExpress.XtraBars.Ribbon.RibbonControl MyRibbon { set; get; }
        public FrmVentas_UsuariosItem()
        {
            InitializeComponent();
            usuario = new Usuario();
            data = new Administrativo();
            this.Load += new EventHandler(FrmUsuariosItem_Load);
        }
        void FrmUsuariosItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.ribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ribbon_ItemClick);
            this.toolProductos.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolClientes.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolProveedores.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolCompras.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolLibroVentas.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolLibroCompras.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolLibroInventarios.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolCotizar.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolFacturar.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolNotaEntrega.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
            this.toolVerFacturas.ItemClicked += new ToolStripItemClickedEventHandler(toolBar_ItemClicked);
        }
        void toolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            e.ClickedItem.Tag = e.ClickedItem.Tag == null ? e.ClickedItem.Text : null;
            e.ClickedItem.Font = !e.ClickedItem.Font.Strikeout ? new Font("Tahoma", 8.25f, FontStyle.Strikeout) : new Font("Tahoma", 8.25f, FontStyle.Bold);
        }
        void ribbon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            e.Item.Tag = e.Item.Tag == null ? e.Item.Caption : null;
            e.Item.Appearance.Font = !e.Item.Appearance.Font.Strikeout ? new Font("Tahoma", 8.25f, FontStyle.Strikeout) : new Font("Tahoma", 8.25f, FontStyle.Bold);
        }
        private void Limpiar()
        {
            usuario = new Usuario();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string id)
        {
            usuario = data.FindUsuario(id);
            if (usuario.disabled == null)
                usuario.disabled = string.Empty;
            foreach (var item in ribbon.Items)
            { 
                System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Caption");
                if (caption.GetValue(item, null) != null)
                {
                    if (usuario.disabled.Contains('[' + caption.GetValue(item, null).ToString() + ']'))
                    {
                        ((BarItem)item).Tag = ((BarItem)item).Caption;
                        ((BarItem)item).Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Strikeout);
                    }
                }
            }
            ValidarToolStrip(new object[] { toolProductos,toolClientes,toolProveedores,toolCompras,toolLibroVentas,toolLibroCompras,toolLibroInventarios,toolVerFacturas,toolCotizar,toolFacturar,toolNotaEntrega });
            Enlazar();
            this.ShowDialog();
        }
        private void ValidarToolStrip(object[] toolStrips)
        {
            foreach (ToolStrip toolStrip in toolStrips)
            {
                foreach (var item in toolStrip.Items)
                {
                    System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Text");
                    if (caption.GetValue(item, null) != null)
                    {
                        string Texto = string.Format("[{0}.{1}]", toolStrip.Text, caption.GetValue(item, null));
                        if (usuario.disabled.Contains(Texto))
                        {
                            ((ToolStripItem)item).Tag = ((ToolStripItem)item).Text;
                            ((ToolStripItem)item).Font = new Font("Tahoma", 8.25f, FontStyle.Strikeout);
                        }
                    }
                }
            }
        }
        private void Enlazar()
        {
            this.usuarioBindingSource.DataSource = usuario;
            this.usuarioBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            StringBuilder invalidos = new StringBuilder();
            usuarioBindingSource.EndEdit();
            usuario = (Usuario)usuarioBindingSource.Current;
            foreach (var item in ribbon.Items)
            {
                System.Reflection.PropertyInfo tag = item.GetType().GetProperty("Tag");
                if (tag.GetValue(item, null) != null)
                {
                    invalidos.Append('['+tag.GetValue(item, null).ToString() + ']');
                }
            }
            ToolStrip(new object[] { toolProductos, toolClientes, toolProveedores, toolCompras, toolLibroVentas,toolLibroCompras, toolLibroInventarios, toolCotizar, toolFacturar, toolNotaEntrega, toolVerFacturas }, invalidos);
            usuario.disabled = invalidos.ToString();
            string resultado = data.GuardarUsuario(usuario, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ToolStrip(object[] toolStrips, StringBuilder invalidos)
        {
            foreach(ToolStrip toolStrip in toolStrips)
            {
                foreach (var item in toolStrip.Items)
                {
                    System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Tag");
                    if (caption.GetValue(item, null) != null)
                    {
                        string Texto = string.Format("[{0}.{1}]", toolStrip.Text, caption.GetValue(item, null));
                        invalidos.Append(Texto);
                    }
                }
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.ResetCurrentItem();
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
    }
}
