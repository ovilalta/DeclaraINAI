using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
// Extended
    public partial class blld_CONFLICTO_RUBRO : bll_CONFLICTO_RUBRO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_CONFLICTO_RUBRO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_CONFLICTO_RUBRO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_CONFLICTO_RUBRO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_CONFLICTO
        //        {
        //          get { return datos_CONFLICTO_RUBRO.NID_CONFLICTO; }
        //        }

        //        public Int32 NID_RUBRO
        //        {
        //          get { return datos_CONFLICTO_RUBRO.NID_RUBRO; }
        //        }


        //        public System.Nullable<Boolean> L_RESPUESTA
        //        {
        //          get { return datos_CONFLICTO_RUBRO.L_RESPUESTA; }
        //          set { datos_CONFLICTO_RUBRO.L_RESPUESTA = value; }
        //        }

        public Boolean L_ENCABEZADOS => CONFLICTO_ENCABEZADOs.Any();


     #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_CONFLICTO_ENCABEZADOs()
        {
                _Reload_CONFLICTO_ENCABEZADOs();
        }

        public void Add_CONFLICTO_ENCABEZADOs()
        {
            try
            {
                _Add_CONFLICTO_ENCABEZADOs();
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public Int32 SI(System.Nullable<Int32> NID_DECLARACION)
        {
            Int32 retorno = datos_CONFLICTO_RUBRO.SI(NID_DECLARACION);
            this.L_RESPUESTA = true;
            this.update();
            Reload_CONFLICTO_ENCABEZADOs();
            return retorno;
        }

        public void NO(System.Nullable<Int32> NID_DECLARACION)
        {
            datos_CONFLICTO_RUBRO.NO(NID_DECLARACION);
            this.L_RESPUESTA = false;
            Reload_CONFLICTO_ENCABEZADOs();
        }


        #endregion

    }
}
