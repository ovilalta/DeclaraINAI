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
    public partial class blld_CAT_SEGUNDO_NIVEL : bll_CAT_SEGUNDO_NIVEL
    {

        #region *** Atributos (Extended) ***

        //        public String VID_PRIMER_NIVEL
        //        {
        //          get { return datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL; }
        //        }

        //        public String VID_SEGUNDO_NIVEL
        //        {
        //          get { return datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL; }
        //        }


        //        public String V_SEGUNDO_NIVEL
        //        {
        //          get { return datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL; }
        //          set { datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL = value; }
        //        }


        //        public String C_INICIO
        //        {
        //          get { return datos_CAT_SEGUNDO_NIVEL.C_INICIO; }
        //          set { datos_CAT_SEGUNDO_NIVEL.C_INICIO = value; }
        //        }


        //        public String C_FIN
        //        {
        //          get { return datos_CAT_SEGUNDO_NIVEL.C_FIN; }
        //          set { datos_CAT_SEGUNDO_NIVEL.C_FIN = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***
        public blld_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN)
         : base()
        { 
            if (Convert.ToInt32(C_INICIO) > Convert.ToInt32(C_FIN)) throw new CustomException("Las Fechas son incorrectas");
            VID_SEGUNDO_NIVEL = Convert.ToString(dald_CAT_SEGUNDO_NIVEL.nNuevo_VID_PRIMER_NIVEL(VID_PRIMER_NIVEL));
            datos_CAT_SEGUNDO_NIVEL = new dald_CAT_SEGUNDO_NIVEL(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_DECLARACION_CARGOs()
        {
            _Reload_DECLARACION_CARGOs();
        }

        public void Add_DECLARACION_CARGOs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, DateTime F_INICIO)
        {
            try
            {
                _Add_DECLARACION_CARGOs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO);
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


        #endregion

    }
}
