﻿namespace HK.Formas
{
    partial class FrmLapsoVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtVendedor = new DevExpress.XtraEditors.ButtonEdit();
            this.txtHasta = new DevExpress.XtraEditors.DateEdit();
            this.txtDesde = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemDesde = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemHasta = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemVendedor = new DevExpress.XtraLayout.LayoutControlItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVendedor)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtVendedor);
            this.layoutControl1.Controls.Add(this.txtHasta);
            this.layoutControl1.Controls.Add(this.txtDesde);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 22);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(310, 105);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(62, 60);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVendedor.Size = new System.Drawing.Size(236, 20);
            this.txtVendedor.StyleController = this.layoutControl1;
            this.txtVendedor.TabIndex = 38;
            // 
            // txtHasta
            // 
            this.txtHasta.EditValue = null;
            this.txtHasta.Location = new System.Drawing.Point(62, 36);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHasta.Size = new System.Drawing.Size(236, 20);
            this.txtHasta.StyleController = this.layoutControl1;
            this.txtHasta.TabIndex = 5;
            // 
            // txtDesde
            // 
            this.txtDesde.EditValue = null;
            this.txtDesde.Location = new System.Drawing.Point(62, 12);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDesde.Size = new System.Drawing.Size(236, 20);
            this.txtDesde.StyleController = this.layoutControl1;
            this.txtDesde.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemDesde,
            this.itemHasta,
            this.itemVendedor});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(310, 105);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // itemDesde
            // 
            this.itemDesde.Control = this.txtDesde;
            this.itemDesde.CustomizationFormText = "Desde";
            this.itemDesde.Location = new System.Drawing.Point(0, 0);
            this.itemDesde.Name = "itemDesde";
            this.itemDesde.Size = new System.Drawing.Size(290, 24);
            this.itemDesde.Text = "Desde";
            this.itemDesde.TextSize = new System.Drawing.Size(46, 13);
            // 
            // itemHasta
            // 
            this.itemHasta.Control = this.txtHasta;
            this.itemHasta.CustomizationFormText = "Hasta";
            this.itemHasta.Location = new System.Drawing.Point(0, 24);
            this.itemHasta.Name = "itemHasta";
            this.itemHasta.Size = new System.Drawing.Size(290, 24);
            this.itemHasta.Text = "Hasta";
            this.itemHasta.TextSize = new System.Drawing.Size(46, 13);
            // 
            // itemVendedor
            // 
            this.itemVendedor.Control = this.txtVendedor;
            this.itemVendedor.CustomizationFormText = "Vendedor";
            this.itemVendedor.Location = new System.Drawing.Point(0, 48);
            this.itemVendedor.Name = "itemVendedor";
            this.itemVendedor.Size = new System.Drawing.Size(290, 37);
            this.itemVendedor.Text = "Vendedor";
            this.itemVendedor.TextSize = new System.Drawing.Size(46, 13);
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 149);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(338, 54);
            this.BarraAcciones.TabIndex = 37;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(77, 51);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(82, 51);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(314, 129);
            this.groupControl1.TabIndex = 36;
            // 
            // FrmLapsoVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 203);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLapsoVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lapso y Vendedor";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVendedor)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit txtHasta;
        private DevExpress.XtraEditors.DateEdit txtDesde;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem itemDesde;
        private DevExpress.XtraLayout.LayoutControlItem itemHasta;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ButtonEdit txtVendedor;
        private DevExpress.XtraLayout.LayoutControlItem itemVendedor;
    }
}