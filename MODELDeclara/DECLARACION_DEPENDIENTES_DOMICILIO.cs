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
    
    public partial class DECLARACION_DEPENDIENTES_DOMICILIO
    {
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public int NID_DEPENDIENTE { get; set; }
        public string C_CODIGO_POSTAL { get; set; }
        public int NID_PAIS { get; set; }
        public string CID_ENTIDAD_FEDERATIVA { get; set; }
        public string CID_MUNICIPIO { get; set; }
        public string V_COLONIA { get; set; }
        public string V_DOMICILIO { get; set; }
    
        public virtual CAT_MUNICIPIO CAT_MUNICIPIO { get; set; }
        public virtual DECLARACION_DEPENDIENTES DECLARACION_DEPENDIENTES { get; set; }
    }
}
