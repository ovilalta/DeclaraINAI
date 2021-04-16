using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_ESTADO_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_ESTADO_ESCOLARIDAD datos_CAT_ESTADO_ESCOLARIDAD { get; set; }
        public Int32 NID_ESTADO_ESCOLARIDAD => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
        public String V_ESTADO_ESCOLARIDAD
        {
            get => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD;
            set => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_ESTADO_ESCOLARIDAD.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_ESTADO_ESCOLARIDAD() => datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD();
        public bll_CAT_ESTADO_ESCOLARIDAD(MODELDeclara_V2.CAT_ESTADO_ESCOLARIDAD CAT_ESTADO_ESCOLARIDAD) => datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(CAT_ESTADO_ESCOLARIDAD);
        public bll_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD) => datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(NID_ESTADO_ESCOLARIDAD);

//        public bll_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD, String V_ESTADO_ESCOLARIDAD)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD();
//            Int32 _NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD; 
//            this.V_ESTADO_ESCOLARIDAD = V_ESTADO_ESCOLARIDAD;
//            datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(_NID_ESTADO_ESCOLARIDAD, this.NID_ESTADO_ESCOLARIDAD, this.V_ESTADO_ESCOLARIDAD, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.update();
        }
        public void delete()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.delete();
        }
        public void reload()
        {
            datos_CAT_ESTADO_ESCOLARIDAD.reload();
        }

        #endregion

    }
}
