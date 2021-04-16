using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_SECCION_INGRESO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_SECCION_INGRESO datos_CAT_SECCION_INGRESO { get; set; }
        public Int32 NID_SECCION => datos_CAT_SECCION_INGRESO.NID_SECCION;
        public Int32 NID_RUBRO => datos_CAT_SECCION_INGRESO.NID_RUBRO;
        public String V_RUBRO
        {
            get => datos_CAT_SECCION_INGRESO.V_RUBRO;
            set => datos_CAT_SECCION_INGRESO.V_RUBRO = value;
        }
        public Boolean L_VIGENTE
        {
            get => datos_CAT_SECCION_INGRESO.L_VIGENTE;
            set => datos_CAT_SECCION_INGRESO.L_VIGENTE = value;
        }
        public String CID_TIPO
        {
            get => datos_CAT_SECCION_INGRESO.CID_TIPO;
            set => datos_CAT_SECCION_INGRESO.CID_TIPO = value;
        }
        public Int32 NID_RUBRO_SUMA
        {
            get => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA;
            set => datos_CAT_SECCION_INGRESO.NID_RUBRO_SUMA = value;
        }
        public String C_TITULAR
        {
            get => datos_CAT_SECCION_INGRESO.C_TITULAR;
            set => datos_CAT_SECCION_INGRESO.C_TITULAR = value;
        }
        public String V_CATALOGO
        {
            get => datos_CAT_SECCION_INGRESO.V_CATALOGO;
            set => datos_CAT_SECCION_INGRESO.V_CATALOGO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_SECCION_INGRESO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_SECCION_INGRESO() => datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO();
        public bll_CAT_SECCION_INGRESO(MODELDeclara_V2.CAT_SECCION_INGRESO CAT_SECCION_INGRESO) => datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO(CAT_SECCION_INGRESO);
        public bll_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO) => datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO(NID_SECCION, NID_RUBRO);

//        public bll_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO();
//            Int32 _NID_SECCION = NID_SECCION; 
//            Int32 _NID_RUBRO = NID_RUBRO; 
//            this.V_RUBRO = V_RUBRO;
//            this.L_VIGENTE = L_VIGENTE;
//            this.CID_TIPO = CID_TIPO;
//            this.NID_RUBRO_SUMA = NID_RUBRO_SUMA;
//            this.C_TITULAR = C_TITULAR;
//            this.V_CATALOGO = V_CATALOGO;
//            datos_CAT_SECCION_INGRESO = new dald_CAT_SECCION_INGRESO(_NID_SECCION, _NID_RUBRO, this.NID_SECCION, this.NID_RUBRO, this.V_RUBRO, this.L_VIGENTE, this.CID_TIPO, this.NID_RUBRO_SUMA, this.C_TITULAR, this.V_CATALOGO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_SECCION_INGRESO.update();
        }
        public void delete()
        {
            datos_CAT_SECCION_INGRESO.delete();
        }
        public void reload()
        {
            datos_CAT_SECCION_INGRESO.reload();
        }

        #endregion

    }
}
