using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_PRIMER_NIVEL : _bllSistema
    {

        internal dald__l_CAT_PRIMER_NIVEL datos_CAT_PRIMER_NIVEL;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_PRIMER_NIVEL> lista_CAT_PRIMER_NIVEL => datos_CAT_PRIMER_NIVEL.lista_CAT_PRIMER_NIVELs;

        protected List<MODELDeclara_V2.CAT_PRIMER_NIVEL>  base_CAT_PRIMER_NIVELs => datos_CAT_PRIMER_NIVEL.base_CAT_PRIMER_NIVELs;

        public StringFilter VID_PRIMER_NIVEL
        {
          get => datos_CAT_PRIMER_NIVEL.VID_PRIMER_NIVEL;
          set => datos_CAT_PRIMER_NIVEL.VID_PRIMER_NIVEL = value;
        }
        public ListFilter<String> VID_PRIMER_NIVELs
        {
          get => datos_CAT_PRIMER_NIVEL.VID_PRIMER_NIVELs;
          set => datos_CAT_PRIMER_NIVEL.VID_PRIMER_NIVELs = value;
        }

        public StringFilter V_PRIMER_NIVEL
        {
          get => datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVEL;
          set => datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVEL = value;
        }
        public ListFilter<String> V_PRIMER_NIVELs
        {
          get => datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVELs;
          set => datos_CAT_PRIMER_NIVEL.V_PRIMER_NIVELs = value;
        }

        public StringFilter C_INICIO
        {
          get => datos_CAT_PRIMER_NIVEL.C_INICIO;
          set => datos_CAT_PRIMER_NIVEL.C_INICIO = value;
        }
        public ListFilter<String> C_INICIOs
        {
          get => datos_CAT_PRIMER_NIVEL.C_INICIOs;
          set => datos_CAT_PRIMER_NIVEL.C_INICIOs = value;
        }

        public StringFilter C_FIN
        {
          get => datos_CAT_PRIMER_NIVEL.C_FIN;
          set => datos_CAT_PRIMER_NIVEL.C_FIN = value;
        }
        public ListFilter<String> C_FINs
        {
          get => datos_CAT_PRIMER_NIVEL.C_FINs;
          set => datos_CAT_PRIMER_NIVEL.C_FINs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_PRIMER_NIVEL.OrderByCriterios; 
            set => datos_CAT_PRIMER_NIVEL.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_PRIMER_NIVEL() => datos_CAT_PRIMER_NIVEL = new dald__l_CAT_PRIMER_NIVEL();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_PRIMER_NIVEL.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_PRIMER_NIVEL.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_PRIMER_NIVEL.single_select();
        }

     #endregion

    }
}
