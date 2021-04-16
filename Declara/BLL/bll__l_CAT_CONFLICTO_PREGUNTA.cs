using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_CONFLICTO_PREGUNTA : _bllSistema
    {

        internal dald__l_CAT_CONFLICTO_PREGUNTA datos_CAT_CONFLICTO_PREGUNTA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA> lista_CAT_CONFLICTO_PREGUNTA => datos_CAT_CONFLICTO_PREGUNTA.lista_CAT_CONFLICTO_PREGUNTAs;

        protected List<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>  base_CAT_CONFLICTO_PREGUNTAs => datos_CAT_CONFLICTO_PREGUNTA.base_CAT_CONFLICTO_PREGUNTAs;

        public IntegerFilter NID_RUBRO
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.NID_RUBRO;
          set => datos_CAT_CONFLICTO_PREGUNTA.NID_RUBRO = value;
        }
        public ListFilter<Int32> NID_RUBROs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.NID_RUBROs;
          set => datos_CAT_CONFLICTO_PREGUNTA.NID_RUBROs = value;
        }

        public IntegerFilter NID_PREGUNTA
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTA;
          set => datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTA = value;
        }
        public ListFilter<Int32> NID_PREGUNTAs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTAs;
          set => datos_CAT_CONFLICTO_PREGUNTA.NID_PREGUNTAs = value;
        }

        public StringFilter V_RUBRO
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_RUBRO = value;
        }
        public ListFilter<String> V_RUBROs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_RUBROs;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_RUBROs = value;
        }

        public StringFilter V_OPCIONES
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONES;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONES = value;
        }
        public ListFilter<String> V_OPCIONESs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONESs;
          set => datos_CAT_CONFLICTO_PREGUNTA.V_OPCIONESs = value;
        }

        public StringFilter C_INICIO
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_INICIO;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_INICIO = value;
        }
        public ListFilter<String> C_INICIOs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_INICIOs;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_INICIOs = value;
        }

        public StringFilter C_FIN
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_FIN;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_FIN = value;
        }
        public ListFilter<String> C_FINs
        {
          get => datos_CAT_CONFLICTO_PREGUNTA.C_FINs;
          set => datos_CAT_CONFLICTO_PREGUNTA.C_FINs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_CONFLICTO_PREGUNTA.OrderByCriterios; 
            set => datos_CAT_CONFLICTO_PREGUNTA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_CONFLICTO_PREGUNTA() => datos_CAT_CONFLICTO_PREGUNTA = new dald__l_CAT_CONFLICTO_PREGUNTA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_CONFLICTO_PREGUNTA.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_CONFLICTO_PREGUNTA.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_CONFLICTO_PREGUNTA.single_select();
        }

     #endregion

    }
}
