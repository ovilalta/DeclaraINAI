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
    
    public partial class D_DETDOMICILIODEPENDIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public D_DETDOMICILIODEPENDIENTES()
        {
            this.D_DEPENDIENTES = new HashSet<D_DEPENDIENTES>();
        }
    
        public decimal NUM_EMPLEADO { get; set; }
        public decimal ID_DOMICILIODEP { get; set; }
        public string DIRECCION { get; set; }
        public string CP { get; set; }
        public string COL { get; set; }
        public Nullable<decimal> ID_ESTADO { get; set; }
        public Nullable<decimal> ID_MUNICIPIO { get; set; }
        public string CIUDAD { get; set; }
        public Nullable<System.DateTime> FEC_CAPTURA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<D_DEPENDIENTES> D_DEPENDIENTES { get; set; }
    }
}
