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
    
    public partial class USUARIO_DOMICILIO
    {
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DOMICILIO { get; set; }
        public int NID_PAIS { get; set; }
        public string CID_ENTIDAD_FEDERATIVA { get; set; }
        public string CID_MUNICIPIO { get; set; }
        public string C_CODIGO_POSTAL { get; set; }
        public string E_DIRECCION { get; set; }
        public int NID_TIPO_DOMICILIO { get; set; }
        public bool L_ACTIVO { get; set; }
    
        public virtual CAT_MUNICIPIO CAT_MUNICIPIO { get; set; }
        public virtual CAT_TIPO_DOMICILIO CAT_TIPO_DOMICILIO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
