using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_GASTO : _bllSistema
    {

        internal dald__l_MODIFICACION_GASTO datos_MODIFICACION_GASTO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_GASTO> lista_MODIFICACION_GASTO => datos_MODIFICACION_GASTO.lista_MODIFICACION_GASTOs;

        protected List<MODELDeclara_V2.MODIFICACION_GASTO>  base_MODIFICACION_GASTOs => datos_MODIFICACION_GASTO.base_MODIFICACION_GASTOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_GASTO.VID_NOMBRE;
          set => datos_MODIFICACION_GASTO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_GASTO.VID_NOMBREs;
          set => datos_MODIFICACION_GASTO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_GASTO.VID_FECHA;
          set => datos_MODIFICACION_GASTO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_GASTO.VID_FECHAs;
          set => datos_MODIFICACION_GASTO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_GASTO.VID_HOMOCLAVE;
          set => datos_MODIFICACION_GASTO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_GASTO.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_GASTO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_GASTO.NID_DECLARACION;
          set => datos_MODIFICACION_GASTO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_GASTO.NID_DECLARACIONs;
          set => datos_MODIFICACION_GASTO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_GASTO
        {
          get => datos_MODIFICACION_GASTO.NID_GASTO;
          set => datos_MODIFICACION_GASTO.NID_GASTO = value;
        }
        public ListFilter<Int32> NID_GASTOs
        {
          get => datos_MODIFICACION_GASTO.NID_GASTOs;
          set => datos_MODIFICACION_GASTO.NID_GASTOs = value;
        }

        public StringFilter V_GASTO
        {
          get => datos_MODIFICACION_GASTO.V_GASTO;
          set => datos_MODIFICACION_GASTO.V_GASTO = value;
        }
        public ListFilter<String> V_GASTOs
        {
          get => datos_MODIFICACION_GASTO.V_GASTOs;
          set => datos_MODIFICACION_GASTO.V_GASTOs = value;
        }

        public DecimalFilter M_GASTO
        {
          get => datos_MODIFICACION_GASTO.M_GASTO;
          set => datos_MODIFICACION_GASTO.M_GASTO = value;
        }
        public ListFilter<Decimal> M_GASTOs
        {
          get => datos_MODIFICACION_GASTO.M_GASTOs;
          set => datos_MODIFICACION_GASTO.M_GASTOs = value;
        }

        public System.Nullable<Boolean> L_AUTOGENERADO
        {
          get => datos_MODIFICACION_GASTO.L_AUTOGENERADO;
          set => datos_MODIFICACION_GASTO.L_AUTOGENERADO = value;
        }
        public ListFilter<Boolean> L_AUTOGENERADOs
        {
          get => datos_MODIFICACION_GASTO.L_AUTOGENERADOs;
          set => datos_MODIFICACION_GASTO.L_AUTOGENERADOs = value;
        }

        public IntegerFilter NID_PATRIMONIO_ASC
        {
          get => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC;
          set => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC = value;
        }
        public ListFilter<Int32> NID_PATRIMONIO_ASCs
        {
          get => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASCs;
          set => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASCs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_GASTO.OrderByCriterios; 
            set => datos_MODIFICACION_GASTO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_GASTO() => datos_MODIFICACION_GASTO = new dald__l_MODIFICACION_GASTO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_GASTO.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_GASTO.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_GASTO.single_select();
        }

     #endregion

    }
}
