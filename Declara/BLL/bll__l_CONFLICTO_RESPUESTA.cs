using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CONFLICTO_RESPUESTA : _bllSistema
    {

        internal dald__l_CONFLICTO_RESPUESTA datos_CONFLICTO_RESPUESTA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CONFLICTO_RESPUESTA> lista_CONFLICTO_RESPUESTA => datos_CONFLICTO_RESPUESTA.lista_CONFLICTO_RESPUESTAs;

        protected List<MODELDeclara_V2.CONFLICTO_RESPUESTA>  base_CONFLICTO_RESPUESTAs => datos_CONFLICTO_RESPUESTA.base_CONFLICTO_RESPUESTAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_CONFLICTO_RESPUESTA.VID_NOMBRE;
          set => datos_CONFLICTO_RESPUESTA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_CONFLICTO_RESPUESTA.VID_NOMBREs;
          set => datos_CONFLICTO_RESPUESTA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_CONFLICTO_RESPUESTA.VID_FECHA;
          set => datos_CONFLICTO_RESPUESTA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_CONFLICTO_RESPUESTA.VID_FECHAs;
          set => datos_CONFLICTO_RESPUESTA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_CONFLICTO_RESPUESTA.VID_HOMOCLAVE;
          set => datos_CONFLICTO_RESPUESTA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_CONFLICTO_RESPUESTA.VID_HOMOCLAVEs;
          set => datos_CONFLICTO_RESPUESTA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_CONFLICTO
        {
          get => datos_CONFLICTO_RESPUESTA.NID_CONFLICTO;
          set => datos_CONFLICTO_RESPUESTA.NID_CONFLICTO = value;
        }
        public ListFilter<Int32> NID_CONFLICTOs
        {
          get => datos_CONFLICTO_RESPUESTA.NID_CONFLICTOs;
          set => datos_CONFLICTO_RESPUESTA.NID_CONFLICTOs = value;
        }

        public IntegerFilter NID_RUBRO
        {
          get => datos_CONFLICTO_RESPUESTA.NID_RUBRO;
          set => datos_CONFLICTO_RESPUESTA.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
          get => datos_CONFLICTO_RESPUESTA.NID_RUBROs;
          set => datos_CONFLICTO_RESPUESTA.NID_RUBROs = value;
        }

        public IntegerFilter NID_ENCABEZADO
        {
          get => datos_CONFLICTO_RESPUESTA.NID_ENCABEZADO;
          set => datos_CONFLICTO_RESPUESTA.NID_ENCABEZADO = value;
        }
        public ListFilter<Int32> NID_ENCABEZADOs
        {
          get => datos_CONFLICTO_RESPUESTA.NID_ENCABEZADOs;
          set => datos_CONFLICTO_RESPUESTA.NID_ENCABEZADOs = value;
        }

        public IntegerFilter NID_PREGUNTA
        {
          get => datos_CONFLICTO_RESPUESTA.NID_PREGUNTA;
          set => datos_CONFLICTO_RESPUESTA.NID_PREGUNTA = value;
        }
        public ListFilter<Int32> NID_PREGUNTAs
        {
          get => datos_CONFLICTO_RESPUESTA.NID_PREGUNTAs;
          set => datos_CONFLICTO_RESPUESTA.NID_PREGUNTAs = value;
        }

        public StringFilter V_RESPUESTA
        {
          get => datos_CONFLICTO_RESPUESTA.V_RESPUESTA;
          set => datos_CONFLICTO_RESPUESTA.V_RESPUESTA = value;
        }
        public ListFilter<String> V_RESPUESTAs
        {
          get => datos_CONFLICTO_RESPUESTA.V_RESPUESTAs;
          set => datos_CONFLICTO_RESPUESTA.V_RESPUESTAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CONFLICTO_RESPUESTA.OrderByCriterios; 
            set => datos_CONFLICTO_RESPUESTA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CONFLICTO_RESPUESTA() => datos_CONFLICTO_RESPUESTA = new dald__l_CONFLICTO_RESPUESTA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CONFLICTO_RESPUESTA.select();
        }

        public void clearOrderBy()
        {
            datos_CONFLICTO_RESPUESTA.clearOrderBy();
        }

        public void Select()
        {
            datos_CONFLICTO_RESPUESTA.single_select();
        }

     #endregion

    }
}
