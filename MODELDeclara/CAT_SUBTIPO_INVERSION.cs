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
    
    public partial class CAT_SUBTIPO_INVERSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_SUBTIPO_INVERSION()
        {
            this.ALTA_INVERSION = new HashSet<ALTA_INVERSION>();
            this.H_PATRIMONIO_INVERSION = new HashSet<H_PATRIMONIO_INVERSION>();
            this.PATRIMONIO_INVERSION = new HashSet<PATRIMONIO_INVERSION>();
        }
    
        public int NID_TIPO_INVERSION { get; set; }
        public int NID_SUBTIPO_INVERSION { get; set; }
        public string V_SUBTIPO_INVERSION { get; set; }
        public bool L_ACTIVO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_INVERSION> ALTA_INVERSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<H_PATRIMONIO_INVERSION> H_PATRIMONIO_INVERSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATRIMONIO_INVERSION> PATRIMONIO_INVERSION { get; set; }
    }
}
