using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_SEGUNDO_NIVEL : _bllSistema
    {

        internal dald__l_CAT_SEGUNDO_NIVEL datos_CAT_SEGUNDO_NIVEL;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_SEGUNDO_NIVEL> lista_CAT_SEGUNDO_NIVEL => datos_CAT_SEGUNDO_NIVEL.lista_CAT_SEGUNDO_NIVELs;

        protected List<MODELDeclara_V2.CAT_SEGUNDO_NIVEL>  base_CAT_SEGUNDO_NIVELs => datos_CAT_SEGUNDO_NIVEL.base_CAT_SEGUNDO_NIVELs;

        public StringFilter VID_PRIMER_NIVEL
        {
          get => datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL;
          set => datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL = value;
        }
        public ListFilter<String> VID_PRIMER_NIVELs
        {
          get => datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVELs;
          set => datos_CAT_SEGUNDO_NIVEL.VID_PRIMER_NIVELs = value;
        }

        public StringFilter VID_SEGUNDO_NIVEL
        {
          get => datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL;
          set => datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL = value;
        }
        public ListFilter<String> VID_SEGUNDO_NIVELs
        {
          get => datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVELs;
          set => datos_CAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVELs = value;
        }

        public StringFilter V_SEGUNDO_NIVEL
        {
          get => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL;
          set => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL = value;
        }
        public ListFilter<String> V_SEGUNDO_NIVELs
        {
          get => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVELs;
          set => datos_CAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVELs = value;
        }

        public StringFilter C_INICIO
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_INICIO;
          set => datos_CAT_SEGUNDO_NIVEL.C_INICIO = value;
        }
        public ListFilter<String> C_INICIOs
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_INICIOs;
          set => datos_CAT_SEGUNDO_NIVEL.C_INICIOs = value;
        }

        public StringFilter C_FIN
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_FIN;
          set => datos_CAT_SEGUNDO_NIVEL.C_FIN = value;
        }
        public ListFilter<String> C_FINs
        {
          get => datos_CAT_SEGUNDO_NIVEL.C_FINs;
          set => datos_CAT_SEGUNDO_NIVEL.C_FINs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_SEGUNDO_NIVEL.OrderByCriterios; 
            set => datos_CAT_SEGUNDO_NIVEL.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_SEGUNDO_NIVEL() => datos_CAT_SEGUNDO_NIVEL = new dald__l_CAT_SEGUNDO_NIVEL();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_SEGUNDO_NIVEL.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_SEGUNDO_NIVEL.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_SEGUNDO_NIVEL.single_select();
        }

     #endregion

    }
}
