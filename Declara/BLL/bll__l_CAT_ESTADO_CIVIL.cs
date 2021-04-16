using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_ESTADO_CIVIL : _bllSistema
    {

        internal dald__l_CAT_ESTADO_CIVIL datos_CAT_ESTADO_CIVIL;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_ESTADO_CIVIL> lista_CAT_ESTADO_CIVIL => datos_CAT_ESTADO_CIVIL.lista_CAT_ESTADO_CIVILs;

        protected List<MODELDeclara_V2.CAT_ESTADO_CIVIL>  base_CAT_ESTADO_CIVILs => datos_CAT_ESTADO_CIVIL.base_CAT_ESTADO_CIVILs;

        public IntegerFilter NID_ESTADO_CIVIL
        {
          get => datos_CAT_ESTADO_CIVIL.NID_ESTADO_CIVIL;
          set => datos_CAT_ESTADO_CIVIL.NID_ESTADO_CIVIL = value;
        }
        public ListFilter<Int32> NID_ESTADO_CIVILs
        {
          get => datos_CAT_ESTADO_CIVIL.NID_ESTADO_CIVILs;
          set => datos_CAT_ESTADO_CIVIL.NID_ESTADO_CIVILs = value;
        }

        public StringFilter V_ESTADO_CIVIL
        {
          get => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVIL;
          set => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVIL = value;
        }
        public ListFilter<String> V_ESTADO_CIVILs
        {
          get => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVILs;
          set => datos_CAT_ESTADO_CIVIL.V_ESTADO_CIVILs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_ESTADO_CIVIL.OrderByCriterios; 
            set => datos_CAT_ESTADO_CIVIL.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_ESTADO_CIVIL() => datos_CAT_ESTADO_CIVIL = new dald__l_CAT_ESTADO_CIVIL();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_ESTADO_CIVIL.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_ESTADO_CIVIL.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_ESTADO_CIVIL.single_select();
        }

     #endregion

    }
}
