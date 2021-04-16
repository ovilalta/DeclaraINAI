using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_FORMA_ADQUISICION : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_FORMA_ADQUISICION datos_CAT_FORMA_ADQUISICION { get; set; }
        public Int32 NID_FORMA_ADQUISICION => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICION;
        public String V_FORMA_ADQUISICION
        {
            get => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION;
            set => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_FORMA_ADQUISICION.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_FORMA_ADQUISICION() => datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION();
        public bll_CAT_FORMA_ADQUISICION(MODELDeclara_V2.CAT_FORMA_ADQUISICION CAT_FORMA_ADQUISICION) => datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION(CAT_FORMA_ADQUISICION);
        public bll_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION) => datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION(NID_FORMA_ADQUISICION);

//        public bll_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION, String V_FORMA_ADQUISICION)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION();
//            Int32 _NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION; 
//            this.V_FORMA_ADQUISICION = V_FORMA_ADQUISICION;
//            datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION(_NID_FORMA_ADQUISICION, this.NID_FORMA_ADQUISICION, this.V_FORMA_ADQUISICION, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_FORMA_ADQUISICION.update();
        }
        public void delete()
        {
            datos_CAT_FORMA_ADQUISICION.delete();
        }
        public void reload()
        {
            datos_CAT_FORMA_ADQUISICION.reload();
        }

        #endregion

    }
}
