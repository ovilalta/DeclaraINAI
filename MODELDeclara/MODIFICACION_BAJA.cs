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
    
    public partial class MODIFICACION_BAJA
    {
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public int NID_PATRIMONIO { get; set; }
        public int NID_TIPO_BAJA { get; set; }
        public System.DateTime F_BAJA { get; set; }
    
        public virtual CAT_TIPO_BAJA CAT_TIPO_BAJA { get; set; }
        public virtual MODIFICACION MODIFICACION { get; set; }
        public virtual MODIFICACION_BAJA_SINIESTRO MODIFICACION_BAJA_SINIESTRO { get; set; }
        public virtual MODIFICACION_BAJA_VENTA MODIFICACION_BAJA_VENTA { get; set; }
        public virtual MODIFICACION_DONACION MODIFICACION_DONACION { get; set; }
    }
}
