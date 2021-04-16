using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_NIVEL_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_NIVEL_ESCOLARIDAD datos_CAT_NIVEL_ESCOLARIDAD { get; set; }
        public Int32 NID_NIVEL_ESCOLARIDAD => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
        public String V_NIVEL_ESCOLARIDAD
        {
            get => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD;
            set => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_NIVEL_ESCOLARIDAD.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_NIVEL_ESCOLARIDAD() => datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD();
        public bll_CAT_NIVEL_ESCOLARIDAD(MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD CAT_NIVEL_ESCOLARIDAD) => datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(CAT_NIVEL_ESCOLARIDAD);
        public bll_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD) => datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(NID_NIVEL_ESCOLARIDAD);

//        public bll_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD, String V_NIVEL_ESCOLARIDAD)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD();
//            Int32 _NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD; 
//            this.V_NIVEL_ESCOLARIDAD = V_NIVEL_ESCOLARIDAD;
//            datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(_NID_NIVEL_ESCOLARIDAD, this.NID_NIVEL_ESCOLARIDAD, this.V_NIVEL_ESCOLARIDAD, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.update();
        }
        public void delete()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.delete();
        }
        public void reload()
        {
            datos_CAT_NIVEL_ESCOLARIDAD.reload();
        }

        #endregion

    }
}
