using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_VALOR_ADQUISICION : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_VALOR_ADQUISICION datos_CAT_VALOR_ADQUISICION { get; set; }
        public Int32 NID_VALOR_ADQUISICION => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICION;
        public String V_VALOR_ADQUISICION
        {
            get => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION;
            set => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_VALOR_ADQUISICION.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_VALOR_ADQUISICION() => datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION();
        public bll_CAT_VALOR_ADQUISICION(MODELDeclara_V2.CAT_VALOR_ADQUISICION CAT_VALOR_ADQUISICION) => datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION(CAT_VALOR_ADQUISICION);
        public bll_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION) => datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION(NID_VALOR_ADQUISICION);

//        public bll_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION, String V_VALOR_ADQUISICION)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION();
//            Int32 _NID_VALOR_ADQUISICION = NID_VALOR_ADQUISICION; 
//            this.V_VALOR_ADQUISICION = V_VALOR_ADQUISICION;
//            datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION(_NID_VALOR_ADQUISICION, this.NID_VALOR_ADQUISICION, this.V_VALOR_ADQUISICION, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_VALOR_ADQUISICION.update();
        }
        public void delete()
        {
            datos_CAT_VALOR_ADQUISICION.delete();
        }
        public void reload()
        {
            datos_CAT_VALOR_ADQUISICION.reload();
        }

        #endregion

    }
}
