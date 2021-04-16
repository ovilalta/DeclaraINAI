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
    public partial class blld_CAT_CONFLICTO_PREGUNTA : bll_CAT_CONFLICTO_PREGUNTA
    {

        #region *** Atributos (Extended) ***

        //        public Int32 NID_RUBRO
        //        {
        //          get { return datos_CAT_CONFLICTO_PREGUNTA.NID_RUBRO; }
        //        }

        //        public Int32 NID_PREGUNTA
        //        {
        //          get { return datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTA; }
        //        }


        //        public String V_RUBRO
        //        {
        //          get { return datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO; }
        //          set { datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO = value; }
        //        }


        new public String C_INICIO
        {
            get { return datos_CAT_CONFLICTO_PREGUNTA.C_INICIO; }
            set
            {
                if (2018 <= Convert.ToInt32(value)) datos_CAT_CONFLICTO_PREGUNTA.C_INICIO = value;
                else
                    throw new CustomException("Fecha Inicio, no puede ser menor a 2018");
            }
        }


        new public String C_FIN
        {
            get { return datos_CAT_CONFLICTO_PREGUNTA.C_FIN; }
            set
            {
                if (Convert.ToInt32(value) >= Convert.ToInt32(C_INICIO))
                    if (2018 <= Convert.ToInt32(value)) datos_CAT_CONFLICTO_PREGUNTA.C_FIN = value;
                    else
                        throw new CustomException("Fecha Inicio, no puede ser menor a 2018");
                else
                    throw new CustomException("Fecha Fin, debe ser igual o mayor a la Inicial");
            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN)
        : base()
        {
            Int32 NID_PREGUNTA = dald_CAT_CONFLICTO_PREGUNTA.nNuevo_NID_PREGUNTA(NID_RUBRO);

            if (2018 > Convert.ToInt32(C_INICIO)) throw new CustomException("Fecha Inicio, no puede ser menor a 2018");
            if (2018 > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe comenzar en 2018");
            if (Convert.ToInt32(C_INICIO) > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe ser igual o mayor a la Inicial");

            datos_CAT_CONFLICTO_PREGUNTA = new dald_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA, V_OPCIONES, V_RUBRO, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***



        #endregion

    }
}
