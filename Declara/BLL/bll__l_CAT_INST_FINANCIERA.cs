using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_INST_FINANCIERA : _bllSistema
    {

        internal dald__l_CAT_INST_FINANCIERA datos_CAT_INST_FINANCIERA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_INST_FINANCIERA> lista_CAT_INST_FINANCIERA => datos_CAT_INST_FINANCIERA.lista_CAT_INST_FINANCIERAs;

        protected List<MODELDeclara_V2.CAT_INST_FINANCIERA>  base_CAT_INST_FINANCIERAs => datos_CAT_INST_FINANCIERA.base_CAT_INST_FINANCIERAs;

        public IntegerFilter NID_INSTITUCION
        {
          get => datos_CAT_INST_FINANCIERA.NID_INSTITUCION;
          set => datos_CAT_INST_FINANCIERA.NID_INSTITUCION = value;
        }
        public ListFilter<Int32> NID_INSTITUCIONs
        {
          get => datos_CAT_INST_FINANCIERA.NID_INSTITUCIONs;
          set => datos_CAT_INST_FINANCIERA.NID_INSTITUCIONs = value;
        }

        public StringFilter V_INSTITUCION
        {
          get => datos_CAT_INST_FINANCIERA.V_INSTITUCION;
          set => datos_CAT_INST_FINANCIERA.V_INSTITUCION = value;
        }
        public ListFilter<String> V_INSTITUCIONs
        {
          get => datos_CAT_INST_FINANCIERA.V_INSTITUCIONs;
          set => datos_CAT_INST_FINANCIERA.V_INSTITUCIONs = value;
        }

        public System.Nullable<Boolean> L_ACTIVO
        {
          get => datos_CAT_INST_FINANCIERA.L_ACTIVO;
          set => datos_CAT_INST_FINANCIERA.L_ACTIVO = value;
        }
        public ListFilter<Boolean> L_ACTIVOs
        {
          get => datos_CAT_INST_FINANCIERA.L_ACTIVOs;
          set => datos_CAT_INST_FINANCIERA.L_ACTIVOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_INST_FINANCIERA.OrderByCriterios; 
            set => datos_CAT_INST_FINANCIERA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_INST_FINANCIERA() => datos_CAT_INST_FINANCIERA = new dald__l_CAT_INST_FINANCIERA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_INST_FINANCIERA.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_INST_FINANCIERA.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_INST_FINANCIERA.single_select();
        }

     #endregion

    }
}
