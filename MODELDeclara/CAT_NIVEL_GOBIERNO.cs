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
    
    public partial class CAT_NIVEL_GOBIERNO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_NIVEL_GOBIERNO()
        {
            this.DECLARACION_CARGO_OTRO = new HashSet<DECLARACION_CARGO_OTRO>();
            this.DECLARACION_DEPENDIENTES_PUBLICO = new HashSet<DECLARACION_DEPENDIENTES_PUBLICO>();
            this.DECLARACION_EXPERIENCIA_LABORAL = new HashSet<DECLARACION_EXPERIENCIA_LABORAL>();
        }
    
        public int NID_NIVEL_GOBIERNO { get; set; }
        public string V_NIVEL_GOBIERNO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DECLARACION_CARGO_OTRO> DECLARACION_CARGO_OTRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DECLARACION_DEPENDIENTES_PUBLICO> DECLARACION_DEPENDIENTES_PUBLICO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DECLARACION_EXPERIENCIA_LABORAL> DECLARACION_EXPERIENCIA_LABORAL { get; set; }
    }
}
