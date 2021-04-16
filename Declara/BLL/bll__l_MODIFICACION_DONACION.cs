using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_DONACION : _bllSistema
    {

        internal dald__l_MODIFICACION_DONACION datos_MODIFICACION_DONACION;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_DONACION> lista_MODIFICACION_DONACION => datos_MODIFICACION_DONACION.lista_MODIFICACION_DONACIONs;

        protected List<MODELDeclara_V2.MODIFICACION_DONACION>  base_MODIFICACION_DONACIONs => datos_MODIFICACION_DONACION.base_MODIFICACION_DONACIONs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_DONACION.VID_NOMBRE;
          set => datos_MODIFICACION_DONACION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_DONACION.VID_NOMBREs;
          set => datos_MODIFICACION_DONACION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_DONACION.VID_FECHA;
          set => datos_MODIFICACION_DONACION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_DONACION.VID_FECHAs;
          set => datos_MODIFICACION_DONACION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_DONACION.VID_HOMOCLAVE;
          set => datos_MODIFICACION_DONACION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_DONACION.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_DONACION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_DONACION.NID_DECLARACION;
          set => datos_MODIFICACION_DONACION.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_DONACION.NID_DECLARACIONs;
          set => datos_MODIFICACION_DONACION.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_PATRIMONIO
        {
          get => datos_MODIFICACION_DONACION.NID_PATRIMONIO;
          set => datos_MODIFICACION_DONACION.NID_PATRIMONIO = value;
        }
        public ListFilter<Int32> NID_PATRIMONIOs
        {
          get => datos_MODIFICACION_DONACION.NID_PATRIMONIOs;
          set => datos_MODIFICACION_DONACION.NID_PATRIMONIOs = value;
        }

        public StringFilter V_ESPECIFICA
        {
          get => datos_MODIFICACION_DONACION.E_ESPECIFICA;
          set => datos_MODIFICACION_DONACION.E_ESPECIFICA = value;
        }
        public ListFilter<String> V_ESPECIFICAs
        {
          get => datos_MODIFICACION_DONACION.E_ESPECIFICAs;
          set => datos_MODIFICACION_DONACION.E_ESPECIFICAs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_DONACION.OrderByCriterios; 
            set => datos_MODIFICACION_DONACION.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_DONACION() => datos_MODIFICACION_DONACION = new dald__l_MODIFICACION_DONACION();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_DONACION.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_DONACION.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_DONACION.single_select();
        }

     #endregion

    }
}
