//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class D_VENTAINMUEBLE
    {
        public decimal NUM_EMPLEADO { get; set; }
        public decimal ID_DECLARAV { get; set; }
        public decimal T_DV { get; set; }
        public decimal ANIOV { get; set; }
        public decimal ID_INMUEBLEV { get; set; }
        public Nullable<decimal> TIPO_FORMAV { get; set; }
        public Nullable<decimal> SALDO_INSOLUTOV { get; set; }
        public Nullable<decimal> MONTO_PAGOSV { get; set; }
        public Nullable<System.DateTime> FECHA_VENTA { get; set; }
        public Nullable<decimal> VALOR_VENTA { get; set; }
        public Nullable<decimal> TIPO_DESTINORECURSOS { get; set; }
        public string OTRO_DESTINORECURSOS { get; set; }
        public string OTRA_FORMAV { get; set; }
        public string NOMBRE_DONANTE { get; set; }
        public Nullable<System.DateTime> FEC_CAPTURA { get; set; }
    
        public virtual CAT_DESTINORECURSOS CAT_DESTINORECURSOS { get; set; }
        public virtual CAT_FORMADQUI CAT_FORMADQUI { get; set; }
    }
}
