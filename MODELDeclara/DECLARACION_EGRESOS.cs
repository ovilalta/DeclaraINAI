//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODELDeclara_V2
{
    using System;
    using System.Collections.Generic;
    
    public partial class DECLARACION_EGRESOS
    {
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public int NID_EGRESO { get; set; }
        public string V_CONCEPTO { get; set; }
        public decimal M_DECLARANTE { get; set; }
        public decimal M_DEPENDIENTE { get; set; }
        public decimal M_SUMA { get; set; }
        public int N_NIVEL { get; set; }
    
        public virtual DECLARACION DECLARACION { get; set; }
    }
}
