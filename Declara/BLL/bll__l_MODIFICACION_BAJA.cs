using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_BAJA : _bllSistema
    {

        internal dald__l_MODIFICACION_BAJA datos_MODIFICACION_BAJA;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_BAJA> lista_MODIFICACION_BAJA => datos_MODIFICACION_BAJA.lista_MODIFICACION_BAJAs;

        protected List<MODELDeclara_V2.MODIFICACION_BAJA>  base_MODIFICACION_BAJAs => datos_MODIFICACION_BAJA.base_MODIFICACION_BAJAs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_BAJA.VID_NOMBRE;
          set => datos_MODIFICACION_BAJA.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_BAJA.VID_NOMBREs;
          set => datos_MODIFICACION_BAJA.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_BAJA.VID_FECHA;
          set => datos_MODIFICACION_BAJA.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_BAJA.VID_FECHAs;
          set => datos_MODIFICACION_BAJA.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_BAJA.VID_HOMOCLAVE;
          set => datos_MODIFICACION_BAJA.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_BAJA.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_BAJA.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_BAJA.NID_DECLARACION;
          set => datos_MODIFICACION_BAJA.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_BAJA.NID_DECLARACIONs;
          set => datos_MODIFICACION_BAJA.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_BAJA.NID_PATRIMONIO;
          set => datos_MODIFICACION_BAJA.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_BAJA.NID_PATRIMONIOs;
          set => datos_MODIFICACION_BAJA.NID_PATRIMONIOs = value;
        }

        public IntegerFilter NID_TIPO_BAJA
        {
          get => datos_MODIFICACION_BAJA.NID_TIPO_BAJA;
          set => datos_MODIFICACION_BAJA.NID_TIPO_BAJA = value;
        }
        public ListFilter<Int32> NID_TIPO_BAJAs
        {
          get => datos_MODIFICACION_BAJA.NID_TIPO_BAJAs;
          set => datos_MODIFICACION_BAJA.NID_TIPO_BAJAs = value;
        }

        public DateTimeFilter F_BAJA
        {
          get => datos_MODIFICACION_BAJA.F_BAJA;
          set => datos_MODIFICACION_BAJA.F_BAJA = value;
        }
        public ListFilter<DateTime> F_BAJAs
        {
          get => datos_MODIFICACION_BAJA.F_BAJAs;
          set => datos_MODIFICACION_BAJA.F_BAJAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_BAJA.OrderByCriterios; 
            set => datos_MODIFICACION_BAJA.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_BAJA() => datos_MODIFICACION_BAJA = new dald__l_MODIFICACION_BAJA();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_BAJA.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_BAJA.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_BAJA.single_select();
        }

     #endregion

    }
}
