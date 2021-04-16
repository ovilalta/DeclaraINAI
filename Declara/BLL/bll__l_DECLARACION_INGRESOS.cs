using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_INGRESOS : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_INGRESOS datos_DECLARACION_INGRESOS { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_INGRESOS> lista_DECLARACION_INGRESOS => datos_DECLARACION_INGRESOS.lista_DECLARACION_INGRESOSs;
        protected List<MODELDeclara_V2.DECLARACION_INGRESOS> base_DECLARACION_INGRESOSs => datos_DECLARACION_INGRESOS.base_DECLARACION_INGRESOSs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_INGRESOS.VID_NOMBRE;
            set => datos_DECLARACION_INGRESOS.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_INGRESOS.VID_NOMBREs;
            set => datos_DECLARACION_INGRESOS.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_INGRESOS.VID_FECHA;
            set => datos_DECLARACION_INGRESOS.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_INGRESOS.VID_FECHAs;
            set => datos_DECLARACION_INGRESOS.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_INGRESOS.VID_HOMOCLAVE;
            set => datos_DECLARACION_INGRESOS.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_INGRESOS.VID_HOMOCLAVEs;
            set => datos_DECLARACION_INGRESOS.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_INGRESOS.NID_DECLARACION;
            set => datos_DECLARACION_INGRESOS.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_INGRESOS.NID_DECLARACIONs;
            set => datos_DECLARACION_INGRESOS.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_INGRESO
        {
            get => datos_DECLARACION_INGRESOS.NID_INGRESO;
            set => datos_DECLARACION_INGRESOS.NID_INGRESO = value;
        }
        public ListFilter<Int32> NID_INGRESOs
        {
            get => datos_DECLARACION_INGRESOS.NID_INGRESOs;
            set => datos_DECLARACION_INGRESOS.NID_INGRESOs = value;
        }

        public StringFilter V_CONCEPTO
        {
            get => datos_DECLARACION_INGRESOS.V_CONCEPTO;
            set => datos_DECLARACION_INGRESOS.V_CONCEPTO = value;
        }
        public ListFilter<String> V_CONCEPTOs
        {
            get => datos_DECLARACION_INGRESOS.V_CONCEPTOs;
            set => datos_DECLARACION_INGRESOS.V_CONCEPTOs = value;
        }

        public DecimalFilter M_DECLARANTE
        {
            get => datos_DECLARACION_INGRESOS.M_DECLARANTE;
            set => datos_DECLARACION_INGRESOS.M_DECLARANTE = value;
        }

        public DecimalFilter M_DEPENDIENTE
        {
            get => datos_DECLARACION_INGRESOS.M_DEPENDIENTE;
            set => datos_DECLARACION_INGRESOS.M_DEPENDIENTE = value;
        }

        public DecimalFilter M_SUMA
        {
            get => datos_DECLARACION_INGRESOS.M_SUMA;
            set => datos_DECLARACION_INGRESOS.M_SUMA = value;
        }

        public IntegerFilter N_NIVEL
        {
            get => datos_DECLARACION_INGRESOS.N_NIVEL;
            set => datos_DECLARACION_INGRESOS.N_NIVEL = value;
        }
        public ListFilter<Int32> N_NIVELs
        {
            get => datos_DECLARACION_INGRESOS.N_NIVELs;
            set => datos_DECLARACION_INGRESOS.N_NIVELs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_INGRESOS.OrderByCriterios;
            set => datos_DECLARACION_INGRESOS.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_INGRESOS() => datos_DECLARACION_INGRESOS = new dald__l_DECLARACION_INGRESOS();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_INGRESOS.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_INGRESOS.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_INGRESOS.single_select();
        }

        #endregion

    }
}
