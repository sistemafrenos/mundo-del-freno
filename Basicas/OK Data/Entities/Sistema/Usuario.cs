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
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class Usuario : Entity
    {
        public Usuario()
        {
            Clave = string.Empty;
            AccesoMenu = true;
            TipoUsuario = "USUARIO";
            PuedeEliminarPlatos = false;
        }
        [MaxLength(10)]
        public string Cedula { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(40)]
        public string TipoUsuario { get; set; }
        [MaxLength(20)]
        public string Clave { get; set; }
        public Nullable<bool> PuedeDarConsumoInterno { get; set; }
        public Nullable<bool> PuedeSepararCuentas { get; set; }
        public Nullable<bool> PuedePedirCorteDeCuenta { get; set; }
        public Nullable<bool> PuedeRegistrarPago { get; set; }
        public Nullable<bool> PuedeCambiarMesa { get; set; }
        public Nullable<bool> PuedeDarCreditos { get; set; }
        public Nullable<bool> ReporteX { get; set; }
        public Nullable<bool> ReporteZ { get; set; }
        public Nullable<bool> Vale { get; set; }
        public Nullable<bool> CierreDeCaja { get; set; }
        public Nullable<bool> ContarDinero { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> PuedeDividirCuentas { get; set; }
        public Nullable<bool> GenerarNotaCredito { get; set; }
        public Nullable<bool> PuedeCambiarVendedor { get; set; }
        public Nullable<bool> PuedeCambiarPrecios { get; set; }
        public Nullable<bool> PuedeModificarDescripcion { get; set; }
        public Nullable<bool> PuedeModificarProveedores { get; set; }
        public Nullable<bool> PuedeLiberarMesa { get; set; }
        public Nullable<bool> PuedeAnularMesa { get; set; }
        public Nullable<bool> AccesoMenu { get; set; }
        
        [MaxLength(4000)]
        public string disabled { get; set; }

        [NotMapped]
        public bool PuedeEliminarPlatos { get; set; }
        

    }
}
