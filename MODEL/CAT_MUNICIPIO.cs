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
    
    public partial class CAT_MUNICIPIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_MUNICIPIO()
        {
            this.D_DATOSPERSONALES = new HashSet<D_DATOSPERSONALES>();
            this.D_DETDOMICILIOPERSONAL = new HashSet<D_DETDOMICILIOPERSONAL>();
            this.D_DETDOMICILIOLABORAL = new HashSet<D_DETDOMICILIOLABORAL>();
        }
    
        public decimal ID_MUNICIPIO { get; set; }
        public decimal ID_ESTADO { get; set; }
        public string DESC_MUNICIPIO { get; set; }
    
        public virtual CAT_ESTADOS CAT_ESTADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<D_DATOSPERSONALES> D_DATOSPERSONALES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<D_DETDOMICILIOPERSONAL> D_DETDOMICILIOPERSONAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<D_DETDOMICILIOLABORAL> D_DETDOMICILIOLABORAL { get; set; }
    }
}
