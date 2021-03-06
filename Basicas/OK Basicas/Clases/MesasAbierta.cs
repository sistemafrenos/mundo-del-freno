//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HK
{
    using System;
    using System.Collections.Generic;
    
    public partial class MesasAbierta
    {
        public MesasAbierta()
        {
            this.MesasAbiertasProductos = new HashSet<MesasAbiertasProducto>();
        }
    
        public string IdMesaAbierta { get; set; }
        public string IdMesonero { get; set; }
        public string Mesonero { get; set; }
        public Nullable<int> Personas { get; set; }
        public Nullable<System.DateTime> Apertura { get; set; }
        public Nullable<double> MontoGravable { get; set; }
        public Nullable<double> MontoExento { get; set; }
        public Nullable<double> MontoIva { get; set; }
        public Nullable<double> MontoTotal { get; set; }
        public Nullable<double> MontoServicio { get; set; }
        public string Numero { get; set; }
        public Nullable<int> NumeroImpresiones { get; set; }
        public string ImpresaPor { get; set; }
        public string Estacion { get; set; }
        public string CodigoMesa { get; set; }
        public Nullable<System.DateTime> UltimaImpresion { get; set; }
        public Nullable<bool> CobraServicio { get; set; }
        public string CedulaRif { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public Nullable<bool> Bloqueada { get; set; }
        public Nullable<bool> TieneComidas { get; set; }
        public Nullable<bool> TieneBebidas { get; set; }
        public Nullable<bool> TieneEventos { get; set; }
        public string Ubicacion { get; set; }
    
        public virtual ICollection<MesasAbiertasProducto> MesasAbiertasProductos { get; set; }
    }
}
