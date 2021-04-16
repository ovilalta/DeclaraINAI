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
    public partial class blld_CONFLICTO : bll_CONFLICTO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_CONFLICTO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_CONFLICTO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_CONFLICTO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_CONFLICTO
        //        {
        //          get { return datos_CONFLICTO.NID_CONFLICTO; }
        //        }


        //        public System.Nullable<Int32> NID_DEC_ASOS
        //        {
        //          get { return datos_CONFLICTO.NID_DEC_ASOS; }
        //          set { datos_CONFLICTO.NID_DEC_ASOS = value; }
        //        }

        public bool L_VALIDA
        {
            get
            {
                if (CONFLICTO_RUBROs.Where(p => !p.L_RESPUESTA.HasValue).Any())
                {
                    throw new CustomException("Debe responder Si ó No a todas la preguntas");
                }
                else
                {
                    foreach (blld_CONFLICTO_RUBRO rubro in CONFLICTO_RUBROs.Where(p => p.L_RESPUESTA.Value == true))
                    {
                        if (rubro.CONFLICTO_ENCABEZADOs.Count == 0)
                        {
                            throw new CustomException("Si responde 'Si' a una pregunta debe capturar por lo menos un conflicto");
                        }
                        else
                        {
                            foreach (blld_CONFLICTO_ENCABEZADO encabezado in rubro.CONFLICTO_ENCABEZADOs)
                            {
                                //if (encabezado.CONFLICTO_RESPUESTAs.Where(p => String.IsNullOrEmpty(p.V_RESPUESTA)).Any())
                                //    throw new CustomException("Debe contestar a toda la información adicional del conflicto");
                                 if (!encabezado.L_CONFLICTO.HasValue)
                                    throw new CustomException("Debe contestar si la relación representa un conflicto de intereses ");
                            }
                        }
                    }
                }
                return true;
            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, System.Nullable<Int32> NID_DEC_ASOS)
            : base()
        {
            Int32 NID_ESTADO_CONFLICTO = 1;
            datos_CONFLICTO = new dald_CONFLICTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_DEC_ASOS, NID_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }

        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_CONFLICTO_RUBROs()
        {
            _Reload_CONFLICTO_RUBROs();
        }

        public void Add_CONFLICTO_RUBROs(Int32 NID_RUBRO, Boolean L_RESPUESTA)
        {
            try
            {
                _Add_CONFLICTO_RUBROs(NID_RUBRO, L_RESPUESTA);
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
