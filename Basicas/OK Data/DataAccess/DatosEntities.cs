//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using HK.BussinessLogic;
using HK.Migrations;

namespace HK
{
    public class DatosEntities : DbContext
    {
        public DatosEntities() : base("name=DatosEntities")
        {
         //   Database.SetInitializer<DatosEntities>(new CreateDatabaseIfNotExists<DatosEntities>());
        }
        public void CheckDatabase()
        {
            try
            {
                Database.CreateIfNotExists();
                if(!IsReady())
                {
                    throw new Exception("Imposible conectar con la Base de datos");
                }
            }
            catch (Exception x)
            {
                var s = x.Message;
            }
        }
        public bool IsReady()
        {
            try
            {
                Database.Connection.Open();
                Database.Connection.Close();
                var config = new Migrations.Configuration();
                var migrator = new DbMigrator(config);
                migrator.Configuration.AutomaticMigrationsEnabled = true;
                var pending = migrator.GetPendingMigrations();
                if (pending.Count() > 0)
                {
                    migrator.Update();
                }   
                config.MySeed(this);
                return true;
            }
            catch (Exception x)
            {
                OK.ManejarException(x);
                return false;
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Sistema
            modelBuilder.Entity<Contador>().ToTable("Sist.Contadores");
            modelBuilder.Entity<Parametro>().ToTable("Sist.Parametros");
            modelBuilder.Entity<Usuario>().ToTable("Sist.Usuarios");
            // Administrativo
            modelBuilder.Entity<Producto>().ToTable("Adm.Productos");
            modelBuilder.Entity<Producto>()
                  .HasMany(e => e.ProductosCompuestos)
                  .WithOptional(s => s.Producto)
                  .WillCascadeOnDelete(true);
            modelBuilder.Entity<ProductosCompuesto>().ToTable("Adm.ProductosCompuestos");
            modelBuilder.Entity<Tercero>().ToTable("Adm.Terceros");
            modelBuilder.Entity<Tercero>()
                .HasMany(e => e.TercerosMovimientos)
                .WithOptional(s => s.Tercero)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<TercerosMovimiento>().ToTable("Adm.TercerosMovimientos");
            modelBuilder.Entity<Documento>().ToTable("Adm.Documentos");
            modelBuilder.Entity<Documento>()
                .HasMany(e => e.DocumentosProductos)
                .WithOptional(s => s.Documento)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<DocumentosProducto>().ToTable("Adm.DocumentoProductos");
            modelBuilder.Entity<Vale>().ToTable("Adm.Vales");
            modelBuilder.Entity<Vendedor>().ToTable("Adm.Vendedores");
            modelBuilder.Entity<MaestroDeCuenta>().ToTable("Adm.MaestroDeCuentas");
            // Seniat
            modelBuilder.Entity<LibroVenta>().ToTable("Adm.LibroVentas");
            modelBuilder.Entity<LibroCompra>().ToTable("Adm.LibroCompras");
            modelBuilder.Entity<LibroInventario>().ToTable("Adm.LibroInventarios");
            // 
            modelBuilder.Entity<CajaChica>().ToTable("Adm.AsientosCajaChicas");
            modelBuilder.Entity<CierreCaja>().ToTable("Adm.CierreCajas");
            modelBuilder.Entity<Pago>().ToTable("Adm.Pagos");
            modelBuilder.Entity<Banco>().ToTable("Adm.Bancos");
            modelBuilder.Entity<Banco>()
                .HasMany(e => e.BancosMovimientos)
                .WithOptional(s => s.Banco)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<BancosMovimiento>().ToTable("Adm.BancosMovimientos");
            modelBuilder.Entity<Tag>().ToTable("Adm.Tags");
            // Restaurant
            modelBuilder.Entity<Mesa>().ToTable("Rest.Mesas");
            modelBuilder.Entity<Evento>().ToTable("Rest.Eventos");
            modelBuilder.Entity<Mesonero>().ToTable("Rest.Mesoneros");
            modelBuilder.Entity<MesasCerrada>().ToTable("Rest.MesasCerradas");
            modelBuilder.Entity<MesasCerrada>()
                .HasMany(e => e.MesasCerradasProductos)
                .WithOptional(s => s.MesasCerrada)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<MesasCerradasProducto>().ToTable("Rest.MesasCerradasProductos");
            modelBuilder.Entity<MesasAbierta>().ToTable("Rest.MesasAbiertas");
            modelBuilder.Entity<MesasAbierta>()
                .HasMany(e => e.MesasAbiertasProductos)
                .WithOptional(s => s.MesasAbierta)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<MesasAbiertasProducto>().ToTable("Rest.MesasAbiertasProductos");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<BancosMovimiento> BancosMovimientos { get; set; }
        public DbSet<CierreCaja> CierresCaja { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<CajaChica> CajasChicas { get; set; }
        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<TercerosMovimiento> TercerosMovimientos { get; set; }
        public DbSet<Contador> Contadores { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentosProducto> DocumentosProductos { get; set; }
        public DbSet<LibroCompra> LibroCompras { get; set; }
        public DbSet<LibroInventario> LibroInventarios { get; set; }
        public DbSet<LibroVenta> LibroVentas { get; set; }
        public DbSet<MaestroDeCuenta> MaestroDeCuentas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<MesasAbierta> MesasAbiertas { get; set; }
        public DbSet<MesasAbiertasProducto> MesasAbiertasProductos { get; set; }
        public DbSet<MesasCerrada> MesasCerradas { get; set; }
        public DbSet<MesasCerradasProducto> MesasCerradasProductos { get; set; }
        public DbSet<Mesonero> Mesoneros { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductosCompuesto> ProductosCompuestos { get; set; }
        public DbSet<Retencion> Retenciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vale> Vales { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}