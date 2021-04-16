using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_ADEUDO : _bllSistema
    {

        internal dald__l_MODIFICACION_ADEUDO datos_MODIFICACION_ADEUDO;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_ADEUDO> lista_MODIFICACION_ADEUDO => datos_MODIFICACION_ADEUDO.lista_MODIFICACION_ADEUDOs;

        protected List<MODELDeclara_V2.MODIFICACION_ADEUDO>  base_MODIFICACION_ADEUDOs => datos_MODIFICACION_ADEUDO.base_MODIFICACION_ADEUDOs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_ADEUDO.VID_NOMBRE;
          set => datos_MODIFICACION_ADEUDO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_ADEUDO.VID_NOMBREs;
          set => datos_MODIFICACION_ADEUDO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_ADEUDO.VID_FECHA;
          set => datos_MODIFICACION_ADEUDO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_ADEUDO.VID_FECHAs;
          set => datos_MODIFICACION_ADEUDO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_ADEUDO.VID_HOMOCLAVE;
          set => datos_MODIFICACION_ADEUDO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_ADEUDO.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_ADEUDO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_ADEUDO.NID_DECLARACION;
          set => datos_MODIFICACION_ADEUDO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_ADEUDO.NID_DECLARACIONs;
          set => datos_MODIFICACION_ADEUDO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_ADEUDO.NID_PATRIMONIO;
          set => datos_MODIFICACION_ADEUDO.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_ADEUDO.NID_PATRIMONIOs;
          set => datos_MODIFICACION_ADEUDO.NID_PATRIMONIOs = value;
        }

        public DecimalFilter M_PAGOS
        {
          get => datos_MODIFICACION_ADEUDO.M_PAGOS;
          set => datos_MODIFICACION_ADEUDO.M_PAGOS = value;
        }
        public ListFilter<Decimal> M_PAGOSs
        {
          get => datos_MODIFICACION_ADEUDO.M_PAGOSs;
          set => datos_MODIFICACION_ADEUDO.M_PAGOSs = value;
        }

        public DecimalFilter M_SALDOS
        {
          get => datos_MODIFICACION_ADEUDO.M_SALDOS;
          set => datos_MODIFICACION_ADEUDO.M_SALDOS = value;
        }
        public ListFilter<Decimal> M_SALDOSs
        {
          get => datos_MODIFICACION_ADEUDO.M_SALDOSs;
          set => datos_MODIFICACION_ADEUDO.M_SALDOSs = value;
        }

        public System.Nullable<Boolean> L_CANCELADO
        {
          get => datos_MODIFICACION_ADEUDO.L_CANCELADO;
          set => datos_MODIFICACION_ADEUDO.L_CANCELADO = value;
        }
        public ListFilter<Boolean> L_CANCELADOs
        {
          get => datos_MODIFICACION_ADEUDO.L_CANCELADOs;
          set => datos_MODIFICACION_ADEUDO.L_CANCELADOs = value;
        }

        public System.Nullable<Boolean> L_MODIFICADO
        {
          get => datos_MODIFICACION_ADEUDO.L_MODIFICADO;
          set => datos_MODIFICACION_ADEUDO.L_MODIFICADO = value;
        }
        public ListFilter<Boolean> L_MODIFICADOs
        {
          get => datos_MODIFICACION_ADEUDO.L_MODIFICADOs;
          set => datos_MODIFICACION_ADEUDO.L_MODIFICADOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_ADEUDO.OrderByCriterios; 
            set => datos_MODIFICACION_ADEUDO.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_ADEUDO() => datos_MODIFICACION_ADEUDO = new dald__l_MODIFICACION_ADEUDO();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_ADEUDO.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_ADEUDO.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_ADEUDO.single_select();
        }

     #endregion

    }
}
