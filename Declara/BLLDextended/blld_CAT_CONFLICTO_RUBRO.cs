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
    public partial class blld_CAT_CONFLICTO_RUBRO : bll_CAT_CONFLICTO_RUBRO
    {

        #region *** Atributos (Extended) ***

        //        public Int32 NID_RUBRO
        //        {
        //          get { return datos_CAT_CONFLICTO_RUBRO.NID_RUBRO; }
        //        }


        //        public String V_RUBRO
        //        {
        //          get { return datos_CAT_CONFLICTO_RUBRO.V_RUBRO; }
        //          set { datos_CAT_CONFLICTO_RUBRO.V_RUBRO = value; }
        //        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        new public String C_INICIO
        {
            get { return datos_CAT_CONFLICTO_RUBRO.C_INICIO; }
            set
            {
                if (2018 <= Convert.ToInt32(value)) datos_CAT_CONFLICTO_RUBRO.C_INICIO = value;
                else
                    throw new CustomException("Fecha Inicio, no puede ingresar fechas anteriores a 2018");
            }
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        new public String C_FIN
        {
            get { return datos_CAT_CONFLICTO_RUBRO.C_FIN; }
            set
            {
                if (Convert.ToInt32(value) >= Convert.ToInt32(C_INICIO))
                    if (2018 <= Convert.ToInt32(value)) datos_CAT_CONFLICTO_RUBRO.C_FIN = value;
                    else
                        throw new CustomException("Fecha Fin, debe comenzar en 2018");
                else
                    throw new CustomException("Fecha Fin, debe ser igual o mayor a la Inicial");
            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_CAT_CONFLICTO_RUBRO(String V_RUBRO, String C_INICIO, String C_FIN)
        : base()
        {
            Int32 NID_RUBRO = dald_CAT_CONFLICTO_RUBRO.nNuevo_NID_RUBRO();
            if (2018 > Convert.ToInt32(C_INICIO)) throw new CustomException("Fecha Inicio, no puede ser menor a 2018");
            if (2018 > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe comenzar en 2018");
            if (Convert.ToInt32(C_INICIO) > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe ser igual o mayor a la Inicial");
            datos_CAT_CONFLICTO_RUBRO = new dald_CAT_CONFLICTO_RUBRO(NID_RUBRO, V_RUBRO, C_INICIO, C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_CAT_CONFLICTO_PREGUNTAs()
        {
            _Reload_CAT_CONFLICTO_PREGUNTAs();
        }

        public void Add_CAT_CONFLICTO_PREGUNTAs(String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN)
        {
            try
            {
                Int32 NID_PREGUNTA = dald_CAT_CONFLICTO_PREGUNTA.nNuevo_NID_PREGUNTA(NID_RUBRO);
                if (2018 > Convert.ToInt32(C_INICIO)) throw new CustomException("Fecha Inicio, no puede ser menor a 2018");
                if (2018 > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe comenzar en 2018");
                if (Convert.ToInt32(C_INICIO) > Convert.ToInt32(C_FIN)) throw new CustomException("Fecha Fin, debe ser igual o mayor a la Inicial");
                _Add_CAT_CONFLICTO_PREGUNTAs(NID_PREGUNTA, V_RUBRO, V_OPCIONES, C_INICIO, C_FIN);
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

        public void Reload_CONFLICTO_RUBROs()
        {
            _Reload_CONFLICTO_RUBROs();
        }

        public void Add_CONFLICTO_RUBROs(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Boolean L_RESPUESTA)
        {
            try
            {
                _Add_CONFLICTO_RUBROs(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, L_RESPUESTA);
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
