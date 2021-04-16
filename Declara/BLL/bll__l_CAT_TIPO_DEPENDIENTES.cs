using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_TIPO_DEPENDIENTES : _bllSistema
    {

        internal dald__l_CAT_TIPO_DEPENDIENTES datos_CAT_TIPO_DEPENDIENTES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_TIPO_DEPENDIENTES> lista_CAT_TIPO_DEPENDIENTES => datos_CAT_TIPO_DEPENDIENTES.lista_CAT_TIPO_DEPENDIENTESs;

        protected List<MODELDeclara_V2.CAT_TIPO_DEPENDIENTES>  base_CAT_TIPO_DEPENDIENTESs => datos_CAT_TIPO_DEPENDIENTES.base_CAT_TIPO_DEPENDIENTESs;

        public IntegerFilter NID_TIPO_DEPENDIENTE
        {
          get => datos_CAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
          set => datos_CAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_TIPO_DEPENDIENTEs
        {
          get => datos_CAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs;
          set => datos_CAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTEs = value;
        }

        public StringFilter V_TIPO_DEPENDIENTE
        {
          get => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE;
          set => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE = value;
        }
        public ListFilter<String> V_TIPO_DEPENDIENTEs
        {
          get => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTEs;
          set => datos_CAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTEs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_TIPO_DEPENDIENTES.OrderByCriterios; 
            set => datos_CAT_TIPO_DEPENDIENTES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_TIPO_DEPENDIENTES() => datos_CAT_TIPO_DEPENDIENTES = new dald__l_CAT_TIPO_DEPENDIENTES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_TIPO_DEPENDIENTES.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_TIPO_DEPENDIENTES.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_TIPO_DEPENDIENTES.single_select();
        }

     #endregion

    }
}
