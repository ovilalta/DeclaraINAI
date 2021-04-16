using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION : _bllSistema
    {

        internal dald__l_MODIFICACION datos_MODIFICACION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION> lista_MODIFICACION => datos_MODIFICACION.lista_MODIFICACIONs;

        protected List<MODELDeclara_V2.MODIFICACION>  base_MODIFICACIONs => datos_MODIFICACION.base_MODIFICACIONs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION.VID_NOMBRE;
          set => datos_MODIFICACION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION.VID_NOMBREs;
          set => datos_MODIFICACION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION.VID_FECHA;
          set => datos_MODIFICACION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION.VID_FECHAs;
          set => datos_MODIFICACION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION.VID_HOMOCLAVE;
          set => datos_MODIFICACION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION.VID_HOMOCLAVEs;
          set => datos_MODIFICACION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION.NID_DECLARACION;
          set => datos_MODIFICACION.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION.NID_DECLARACIONs;
          set => datos_MODIFICACION.NID_DECLARACIONs = value;
        }

        public System.Nullable<Boolean> L_PRESENTO_DEC
        {
          get => datos_MODIFICACION.L_PRESENTO_DEC;
          set => datos_MODIFICACION.L_PRESENTO_DEC = value;
        }
        public ListFilter<Boolean> L_PRESENTO_DECs
        {
          get => datos_MODIFICACION.L_PRESENTO_DECs;
          set => datos_MODIFICACION.L_PRESENTO_DECs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION.OrderByCriterios; 
            set => datos_MODIFICACION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION() => datos_MODIFICACION = new dald__l_MODIFICACION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION.single_select();
        }

     #endregion

    }
}
