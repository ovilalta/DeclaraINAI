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
    
    public partial class CAT_VALOR_ADQUISICION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_VALOR_ADQUISICION()
        {
            this.ALTA_INMUEBLE = new HashSet<ALTA_INMUEBLE>();
        }
    
        public int NID_VALOR_ADQUISICION { get; set; }
        public string V_VALOR_ADQUISICION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_INMUEBLE> ALTA_INMUEBLE { get; set; }
    }
}
