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
    
    public partial class ALTA_MUEBLE_TITULAR
    {
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public int NID_MUEBLE { get; set; }
        public int NID_DEPENDIENTE { get; set; }
        public bool L_DIF { get; set; }
    
        public virtual ALTA_MUEBLE ALTA_MUEBLE { get; set; }
    }
}
