using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_BAJA_VENTA : _bllSistema
    {

        internal dald__l_MODIFICACION_BAJA_VENTA datos_MODIFICACION_BAJA_VENTA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_BAJA_VENTA> lista_MODIFICACION_BAJA_VENTA => datos_MODIFICACION_BAJA_VENTA.lista_MODIFICACION_BAJA_VENTAs;

        protected List<MODELDeclara_V2.MODIFICACION_BAJA_VENTA>  base_MODIFICACION_BAJA_VENTAs => datos_MODIFICACION_BAJA_VENTA.base_MODIFICACION_BAJA_VENTAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_NOMBRE;
          set => datos_MODIFICACION_BAJA_VENTA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_NOMBREs;
          set => datos_MODIFICACION_BAJA_VENTA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_FECHA;
          set => datos_MODIFICACION_BAJA_VENTA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_FECHAs;
          set => datos_MODIFICACION_BAJA_VENTA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVE;
          set => datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_DECLARACION;
          set => datos_MODIFICACION_BAJA_VENTA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_DECLARACIONs;
          set => datos_MODIFICACION_BAJA_VENTA.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIO;
          set => datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIOs;
          set => datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO_VENTA
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA;
          set => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA = value;
        }
        public ListFilter<Int32> NID_TIPO_VENTAs
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTAs;
          set => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTAs = value;
        }

        public DecimalFilter M_IMPORTE_VENTA
        {
          get => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA;
          set => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA = value;
        }
        public ListFilter<Decimal> M_IMPORTE_VENTAs
        {
          get => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTAs;
          set => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_BAJA_VENTA.OrderByCriterios; 
            set => datos_MODIFICACION_BAJA_VENTA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_BAJA_VENTA() => datos_MODIFICACION_BAJA_VENTA = new dald__l_MODIFICACION_BAJA_VENTA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_BAJA_VENTA.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_BAJA_VENTA.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_BAJA_VENTA.single_select();
        }

     #endregion

    }
}
