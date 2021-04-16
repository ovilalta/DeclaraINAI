using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll__l_MODIFICACION_INGRESOS : _bllSistema
    {

        internal dald__l_MODIFICACION_INGRESOS datos_MODIFICACION_INGRESOS;

     #region *** Atributos ***


        public List<Declara_V2.MODELextended.MODIFICACION_INGRESOS> lista_MODIFICACION_INGRESOS => datos_MODIFICACION_INGRESOS.lista_MODIFICACION_INGRESOSs;

        protected List<MODELDeclara_V2.MODIFICACION_INGRESOS>  base_MODIFICACION_INGRESOSs => datos_MODIFICACION_INGRESOS.base_MODIFICACION_INGRESOSs;

        public StringFilter VID_NOMBRE
        {
          get => datos_MODIFICACION_INGRESOS.VID_NOMBRE;
          set => datos_MODIFICACION_INGRESOS.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
          get => datos_MODIFICACION_INGRESOS.VID_NOMBREs;
          set => datos_MODIFICACION_INGRESOS.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
          get => datos_MODIFICACION_INGRESOS.VID_FECHA;
          set => datos_MODIFICACION_INGRESOS.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
          get => datos_MODIFICACION_INGRESOS.VID_FECHAs;
          set => datos_MODIFICACION_INGRESOS.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
          get => datos_MODIFICACION_INGRESOS.VID_HOMOCLAVE;
          set => datos_MODIFICACION_INGRESOS.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
          get => datos_MODIFICACION_INGRESOS.VID_HOMOCLAVEs;
          set => datos_MODIFICACION_INGRESOS.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
          get => datos_MODIFICACION_INGRESOS.NID_DECLARACION;
          set => datos_MODIFICACION_INGRESOS.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
          get => datos_MODIFICACION_INGRESOS.NID_DECLARACIONs;
          set => datos_MODIFICACION_INGRESOS.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_INGRESO
        {
          get => datos_MODIFICACION_INGRESOS.NID_INGRESO;
          set => datos_MODIFICACION_INGRESOS.NID_INGRESO = value;
        }
        public ListFilter<Int32> NID_INGRESOs
        {
          get => datos_MODIFICACION_INGRESOS.NID_INGRESOs;
          set => datos_MODIFICACION_INGRESOS.NID_INGRESOs = value;
        }

        public StringFilter E_ESPECIFICAR
        {
          get => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR;
          set => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR = value;
        }
        public ListFilter<String> E_ESPECIFICARs
        {
          get => datos_MODIFICACION_INGRESOS.E_ESPECIFICARs;
          set => datos_MODIFICACION_INGRESOS.E_ESPECIFICARs = value;
        }

        public DecimalFilter M_INGRESO
        {
          get => datos_MODIFICACION_INGRESOS.M_INGRESO;
          set => datos_MODIFICACION_INGRESOS.M_INGRESO = value;
        }
        public ListFilter<Decimal> M_INGRESOs
        {
          get => datos_MODIFICACION_INGRESOS.M_INGRESOs;
          set => datos_MODIFICACION_INGRESOS.M_INGRESOs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_MODIFICACION_INGRESOS.OrderByCriterios; 
            set => datos_MODIFICACION_INGRESOS.OrderByCriterios = value; 
        }


     #endregion


     #region *** Constructores ***

        public bll__l_MODIFICACION_INGRESOS() => datos_MODIFICACION_INGRESOS = new dald__l_MODIFICACION_INGRESOS();

     #endregion


     #region *** Metodos ***

        public void select()
        {
            datos_MODIFICACION_INGRESOS.select();
        }

        public void clearOrderBy()
        {
            datos_MODIFICACION_INGRESOS.clearOrderBy();
        }

        public void Select()
        {
            datos_MODIFICACION_INGRESOS.single_select();
        }

     #endregion

    }
}
