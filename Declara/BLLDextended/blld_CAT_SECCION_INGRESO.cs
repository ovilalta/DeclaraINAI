using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_SECCION_INGRESO : bll_CAT_SECCION_INGRESO
    {

        #region *** Propiedades ***
//    new public Int32 NID_SECCION => datos_CAT_SECCION_INGRESO.NID_SECCION;
//    new public Int32 NID_RUBRO => datos_CAT_SECCION_INGRESO.NID_RUBRO;
//    new public String V_RUBRO
//        {
//            get => datos_CAT_SECCION_INGRESO.V_RUBRO;
//            set => datos_CAT_SECCION_INGRESO.V_RUBRO = value;
//        }
//    new public Boolean L_VIGENTE
//        {
//            get => datos_CAT_SECCION_INGRESO.L_VIGENTE;
//            set => datos_CAT_SECCION_INGRESO.L_VIGENTE = value;
//        }
//    new public String CID_TIPO
//        {
//            get => datos_CAT_SECCION_INGRESO.CID_TIPO;
//            set => datos_CAT_SECCION_INGRESO.CID_TIPO = value;
//        }
//    new public Int32 NID_RUBRO_SUMA
//        {
//            get => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA;
//            set => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA = value;
//        }
//    new public String C_TITULAR
//        {
//            get => datos_CAT_SECCION_INGRESO.C_TITULAR;
//            set => datos_CAT_SECCION_INGRESO.C_TITULAR = value;
//        }
//    new public String V_CATALOGO
//        {
//            get => datos_CAT_SECCION_INGRESO.V_CATALOGO;
//            set => datos_CAT_SECCION_INGRESO.V_CATALOGO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_SECCION = NID_SECCION; 
            Int32 _NID_RUBRO = NID_RUBRO; 
            this.V_RUBRO = V_RUBRO;
            this.L_VIGENTE = L_VIGENTE;
            this.CID_TIPO = CID_TIPO;
            this.NID_RUBRO_SUMA = NID_RUBRO_SUMA;
            this.C_TITULAR = C_TITULAR;
            this.V_CATALOGO = V_CATALOGO;
            datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO(_NID_SECCION, _NID_RUBRO, this.V_RUBRO, this.L_VIGENTE, this.CID_TIPO, this.NID_RUBRO_SUMA, this.C_TITULAR, this.V_CATALOGO, lOpcionesRegistroExistente);
        }
        public blld_CAT_SECCION_INGRESO(Int32 NID_SECCION, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_SECCION = NID_SECCION; 
            Int32 _NID_RUBRO = dald_CAT_SECCION_INGRESO.nNuevo_NID_RUBRO(NID_SECCION);
            this.V_RUBRO = V_RUBRO;
            this.L_VIGENTE = L_VIGENTE;
            this.CID_TIPO = CID_TIPO;
            this.NID_RUBRO_SUMA = NID_RUBRO_SUMA;
            this.C_TITULAR = C_TITULAR;
            this.V_CATALOGO = V_CATALOGO;
            datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO(_NID_SECCION, _NID_RUBRO, this.V_RUBRO, this.L_VIGENTE, this.CID_TIPO, this.NID_RUBRO_SUMA, this.C_TITULAR, this.V_CATALOGO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
