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
    
    public partial class CAT_ENTIDAD_FEDERATIVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_ENTIDAD_FEDERATIVA()
        {
            this.ALTA_ADEUDO = new HashSet<ALTA_ADEUDO>();
            this.ALTA_COMODATO_VEHICULO = new HashSet<ALTA_COMODATO_VEHICULO>();
            this.ALTA_INVERSION = new HashSet<ALTA_INVERSION>();
            this.ALTA_VEHICULO = new HashSet<ALTA_VEHICULO>();
            this.CAT_MUNICIPIO = new HashSet<CAT_MUNICIPIO>();
            this.H_PATRIMONIO_ADEUDO = new HashSet<H_PATRIMONIO_ADEUDO>();
            this.H_PATRIMONIO_INVERSION = new HashSet<H_PATRIMONIO_INVERSION>();
            this.PATRIMONIO_ADEUDO = new HashSet<PATRIMONIO_ADEUDO>();
            this.PATRIMONIO_INVERSION = new HashSet<PATRIMONIO_INVERSION>();
        }
    
        public int NID_PAIS { get; set; }
        public string CID_ENTIDAD_FEDERATIVA { get; set; }
        public string V_ENTIDAD_FEDERATIVA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_ADEUDO> ALTA_ADEUDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_COMODATO_VEHICULO> ALTA_COMODATO_VEHICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_INVERSION> ALTA_INVERSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_VEHICULO> ALTA_VEHICULO { get; set; }
        public virtual CAT_PAIS CAT_PAIS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_MUNICIPIO> CAT_MUNICIPIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<H_PATRIMONIO_ADEUDO> H_PATRIMONIO_ADEUDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<H_PATRIMONIO_INVERSION> H_PATRIMONIO_INVERSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATRIMONIO_ADEUDO> PATRIMONIO_ADEUDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATRIMONIO_INVERSION> PATRIMONIO_INVERSION { get; set; }
    }
}
