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
    
    public partial class MODIFICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODIFICACION()
        {
            this.MODIFICACION_ADEUDO = new HashSet<MODIFICACION_ADEUDO>();
            this.MODIFICACION_BAJA = new HashSet<MODIFICACION_BAJA>();
            this.MODIFICACION_GASTO = new HashSet<MODIFICACION_GASTO>();
            this.MODIFICACION_INGRESOS = new HashSet<MODIFICACION_INGRESOS>();
            this.MODIFICACION_INMUEBLE = new HashSet<MODIFICACION_INMUEBLE>();
            this.MODIFICACION_INVERSION = new HashSet<MODIFICACION_INVERSION>();
            this.MODIFICACION_MUEBLE = new HashSet<MODIFICACION_MUEBLE>();
            this.MODIFICACION_TARJETA = new HashSet<MODIFICACION_TARJETA>();
            this.MODIFICACION_VEHICULO = new HashSet<MODIFICACION_VEHICULO>();
        }
    
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public Nullable<bool> L_PRESENTO_DEC { get; set; }
        public Nullable<System.DateTime> F_INICIO { get; set; }
        public Nullable<System.DateTime> F_FIN { get; set; }
    
        public virtual DECLARACION DECLARACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_ADEUDO> MODIFICACION_ADEUDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_BAJA> MODIFICACION_BAJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_GASTO> MODIFICACION_GASTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_INGRESOS> MODIFICACION_INGRESOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_INMUEBLE> MODIFICACION_INMUEBLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_INVERSION> MODIFICACION_INVERSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_MUEBLE> MODIFICACION_MUEBLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_TARJETA> MODIFICACION_TARJETA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODIFICACION_VEHICULO> MODIFICACION_VEHICULO { get; set; }
    }
}
