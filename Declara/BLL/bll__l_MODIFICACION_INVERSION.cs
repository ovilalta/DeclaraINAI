using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_INVERSION : _bllSistema
    {

        internal dald__l_MODIFICACION_INVERSION datos_MODIFICACION_INVERSION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_INVERSION> lista_MODIFICACION_INVERSION => datos_MODIFICACION_INVERSION.lista_MODIFICACION_INVERSIONs;

        protected List<MODELDeclara_V2.MODIFICACION_INVERSION>  base_MODIFICACION_INVERSIONs => datos_MODIFICACION_INVERSION.base_MODIFICACION_INVERSIONs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_INVERSION.VID_NOMBRE;
          set => datos_MODIFICACION_INVERSION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_INVERSION.VID_NOMBREs;
          set => datos_MODIFICACION_INVERSION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_INVERSION.VID_FECHA;
          set => datos_MODIFICACION_INVERSION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_INVERSION.VID_FECHAs;
          set => datos_MODIFICACION_INVERSION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_INVERSION.VID_HOMOCLAVE;
          set => datos_MODIFICACION_INVERSION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_INVERSION.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_INVERSION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_INVERSION.NID_DECLARACION;
          set => datos_MODIFICACION_INVERSION.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_INVERSION.NID_DECLARACIONs;
          set => datos_MODIFICACION_INVERSION.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_INVERSION.NID_PATRIMONIO;
          set => datos_MODIFICACION_INVERSION.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_INVERSION.NID_PATRIMONIOs;
          set => datos_MODIFICACION_INVERSION.NID_PATRIMONIOs = value;
        }

        public DecimalFilter M_SALDO_ANTERIOR
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR = value;
        }
        public ListFilter<Decimal> M_SALDO_ANTERIORs
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIORs;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIORs = value;
        }

        public DecimalFilter M_SALDO_ACTUAL
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ACTUAL;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ACTUAL = value;
        }
        public ListFilter<Decimal> M_SALDO_ACTUALs
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ACTUALs;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ACTUALs = value;
        }

        public System.Nullable<Boolean> L_CANCELADA
        {
          get => datos_MODIFICACION_INVERSION.L_CANCELADA;
          set => datos_MODIFICACION_INVERSION.L_CANCELADA = value;
        }
        public ListFilter<Boolean> L_CANCELADAs
        {
          get => datos_MODIFICACION_INVERSION.L_CANCELADAs;
          set => datos_MODIFICACION_INVERSION.L_CANCELADAs = value;
        }

        public System.Nullable<Boolean> L_MODIFICADA
        {
          get => datos_MODIFICACION_INVERSION.L_MODIFICADA;
          set => datos_MODIFICACION_INVERSION.L_MODIFICADA = value;
        }
        public ListFilter<Boolean> L_MODIFICADAs
        {
          get => datos_MODIFICACION_INVERSION.L_MODIFICADAs;
          set => datos_MODIFICACION_INVERSION.L_MODIFICADAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_INVERSION.OrderByCriterios; 
            set => datos_MODIFICACION_INVERSION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_INVERSION() => datos_MODIFICACION_INVERSION = new dald__l_MODIFICACION_INVERSION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_INVERSION.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_INVERSION.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_INVERSION.single_select();
        }

     #endregion

    }
}
