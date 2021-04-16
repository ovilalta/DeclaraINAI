using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_CAT_RESTRICCIONES : _bllSistema
    {

        internal dald__l_CAT_RESTRICCIONES datos_CAT_RESTRICCIONES;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.CAT_RESTRICCIONES> lista_CAT_RESTRICCIONES => datos_CAT_RESTRICCIONES.lista_CAT_RESTRICCIONESs;

        protected List<MODELDeclara_V2.CAT_RESTRICCIONES>  base_CAT_RESTRICCIONESs => datos_CAT_RESTRICCIONES.base_CAT_RESTRICCIONESs;

        public IntegerFilter NID_RESTRICCION
        {
          get => datos_CAT_RESTRICCIONES.NID_RESTRICCION;
          set => datos_CAT_RESTRICCIONES.NID_RESTRICCION = value;
        }
        public ListFilter<Int32> NID_RESTRICCIONs
        {
          get => datos_CAT_RESTRICCIONES.NID_RESTRICCIONs;
          set => datos_CAT_RESTRICCIONES.NID_RESTRICCIONs = value;
        }

        public StringFilter V_RESTRICCION
        {
          get => datos_CAT_RESTRICCIONES.V_RESTRICCION;
          set => datos_CAT_RESTRICCIONES.V_RESTRICCION = value;
        }
        public ListFilter<String> V_RESTRICCIONs
        {
          get => datos_CAT_RESTRICCIONES.V_RESTRICCIONs;
          set => datos_CAT_RESTRICCIONES.V_RESTRICCIONs = value;
        }

        public System.Nullable<Boolean> L_VIGENTE
        {
          get => datos_CAT_RESTRICCIONES.L_VIGENTE;
          set => datos_CAT_RESTRICCIONES.L_VIGENTE = value;
        }
        public ListFilter<Boolean> L_VIGENTEs
        {
          get => datos_CAT_RESTRICCIONES.L_VIGENTEs;
          set => datos_CAT_RESTRICCIONES.L_VIGENTEs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_CAT_RESTRICCIONES.OrderByCriterios; 
            set => datos_CAT_RESTRICCIONES.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_CAT_RESTRICCIONES() => datos_CAT_RESTRICCIONES = new dald__l_CAT_RESTRICCIONES();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_CAT_RESTRICCIONES.select();
        }

        public void clearOrderBy()
        {
            datos_CAT_RESTRICCIONES.clearOrderBy();
        }

        public void Select()
        {
            datos_CAT_RESTRICCIONES.single_select();
        }

     #endregion

    }
}
