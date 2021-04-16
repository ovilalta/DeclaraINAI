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
    public partial class blld_CONFLICTO_ENCABEZADO : bll_CONFLICTO_ENCABEZADO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_CONFLICTO
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.NID_CONFLICTO; }
        //        }

        //        public Int32 NID_RUBRO
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.NID_RUBRO; }
        //        }

        //        public Int32 NID_ENCABEZADO
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.NID_ENCABEZADO; }
        //        }


        //        public System.Nullable<Boolean> L_CONFLICTO
        //        {
        //          get { return datos_CONFLICTO_ENCABEZADO.L_CONFLICTO; }
        //          set { datos_CONFLICTO_ENCABEZADO.L_CONFLICTO = value; }
        //        }

        public String V_DESCRIPCION
        {
            get => CONFLICTO_RESPUESTAs.Count == 0 ? String.Concat("Conflicto de Intereses ", NID_ENCABEZADO) : (String.IsNullOrEmpty(CONFLICTO_RESPUESTAs[0].V_RESPUESTA) ? String.Concat("Conflicto de Intereses ", NID_ENCABEZADO) : CONFLICTO_RESPUESTAs[0].V_RESPUESTA);
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO)
           : base()
        {
            Int32 NID_ENCABEZADO = 1;
            System.Nullable<Boolean> L_CONFLICTO = null;
            datos_CONFLICTO_ENCABEZADO = new dald_CONFLICTO_ENCABEZADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }

        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_CONFLICTO_RESPUESTAs()
        {
            _Reload_CONFLICTO_RESPUESTAs();
        }

        public void Add_CONFLICTO_RESPUESTAs(Int32 NID_PREGUNTA, String V_RESPUESTA)
        {
            try
            {
                _Add_CONFLICTO_RESPUESTAs(NID_PREGUNTA, V_RESPUESTA);
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

        new public void delete()
        {
            datos_CONFLICTO_ENCABEZADO.borra();
        }

        #endregion

    }
}
