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
    
    public partial class ALTA_MUEBLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALTA_MUEBLE()
        {
            this.ALTA_MUEBLE_COPROPIETARIO = new HashSet<ALTA_MUEBLE_COPROPIETARIO>();
            this.ALTA_MUEBLE_TITULAR = new HashSet<ALTA_MUEBLE_TITULAR>();
        }
    
        public string VID_NOMBRE { get; set; }
        public string VID_FECHA { get; set; }
        public string VID_HOMOCLAVE { get; set; }
        public int NID_DECLARACION { get; set; }
        public int NID_MUEBLE { get; set; }
        public int NID_TIPO { get; set; }
        public string E_ESPECIFICACION { get; set; }
        public decimal M_VALOR { get; set; }
        public int NID_PATRIMONIO { get; set; }
        public bool L_CREDITO { get; set; }
        public System.DateTime F_ADQUISICION { get; set; }
        public string CID_TIPO_PERSONA_TRANSMISOR { get; set; }
        public string E_NOMBRE_TRANSMISOR { get; set; }
        public string E_RFC_TRANSMISOR { get; set; }
        public int NID_RELACION_TRANSMISOR { get; set; }
        public string V_TIPO_MONEDA { get; set; }
        public Nullable<int> NID_FORMA_ADQUISICION { get; set; }
        public Nullable<int> NID_FORMA_PAGO { get; set; }
        public string E_OBSERVACIONES { get; set; }
        public string E_OBSERVACIONES_MARCADO { get; set; }
        public string V_OBSERVACIONES_TESTADO { get; set; }
        public int NID_ESTADO_TESTADO { get; set; }
        public string D_ESPECIFICACION { get; set; }

        public virtual ALTA ALTA { get; set; }
        public virtual CAT_ESTADO_TESTADO CAT_ESTADO_TESTADO { get; set; }
        public virtual CAT_FORMA_ADQUISICION CAT_FORMA_ADQUISICION { get; set; }
        public virtual CAT_FORMA_PAGO CAT_FORMA_PAGO { get; set; }
        public virtual CAT_RELACION_TRANSMISOR CAT_RELACION_TRANSMISOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_MUEBLE_COPROPIETARIO> ALTA_MUEBLE_COPROPIETARIO { get; set; }
        public virtual ALTA_MUEBLE_FORMA_ADQUISICION ALTA_MUEBLE_FORMA_ADQUISICION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALTA_MUEBLE_TITULAR> ALTA_MUEBLE_TITULAR { get; set; }
        public virtual CAT_TIPO_MUEBLE CAT_TIPO_MUEBLE { get; set; }
    }
}
