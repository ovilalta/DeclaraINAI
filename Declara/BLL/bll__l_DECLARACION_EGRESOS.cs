using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_EGRESOS : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_EGRESOS datos_DECLARACION_EGRESOS { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_EGRESOS> lista_DECLARACION_EGRESOS => datos_DECLARACION_EGRESOS.lista_DECLARACION_EGRESOSs;
        protected List<MODELDeclara_V2.DECLARACION_EGRESOS> base_DECLARACION_EGRESOSs => datos_DECLARACION_EGRESOS.base_DECLARACION_EGRESOSs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_EGRESOS.VID_NOMBRE;
            set => datos_DECLARACION_EGRESOS.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_EGRESOS.VID_NOMBREs;
            set => datos_DECLARACION_EGRESOS.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_EGRESOS.VID_FECHA;
            set => datos_DECLARACION_EGRESOS.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_EGRESOS.VID_FECHAs;
            set => datos_DECLARACION_EGRESOS.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_EGRESOS.VID_HOMOCLAVE;
            set => datos_DECLARACION_EGRESOS.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_EGRESOS.VID_HOMOCLAVEs;
            set => datos_DECLARACION_EGRESOS.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_EGRESOS.NID_DECLARACION;
            set => datos_DECLARACION_EGRESOS.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_EGRESOS.NID_DECLARACIONs;
            set => datos_DECLARACION_EGRESOS.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_EGRESO
        {
            get => datos_DECLARACION_EGRESOS.NID_EGRESO;
            set => datos_DECLARACION_EGRESOS.NID_EGRESO = value;
        }
        public ListFilter<Int32> NID_EGRESOs
        {
            get => datos_DECLARACION_EGRESOS.NID_EGRESOs;
            set => datos_DECLARACION_EGRESOS.NID_EGRESOs = value;
        }

        public StringFilter V_CONCEPTO
        {
            get => datos_DECLARACION_EGRESOS.V_CONCEPTO;
            set => datos_DECLARACION_EGRESOS.V_CONCEPTO = value;
        }
        public ListFilter<String> V_CONCEPTOs
        {
            get => datos_DECLARACION_EGRESOS.V_CONCEPTOs;
            set => datos_DECLARACION_EGRESOS.V_CONCEPTOs = value;
        }

        public DecimalFilter M_DECLARANTE
        {
            get => datos_DECLARACION_EGRESOS.M_DECLARANTE;
            set => datos_DECLARACION_EGRESOS.M_DECLARANTE = value;
        }

        public DecimalFilter M_DEPENDIENTE
        {
            get => datos_DECLARACION_EGRESOS.M_DEPENDIENTE;
            set => datos_DECLARACION_EGRESOS.M_DEPENDIENTE = value;
        }

        public DecimalFilter M_SUMA
        {
            get => datos_DECLARACION_EGRESOS.M_SUMA;
            set => datos_DECLARACION_EGRESOS.M_SUMA = value;
        }

        public IntegerFilter N_NIVEL
        {
            get => datos_DECLARACION_EGRESOS.N_NIVEL;
            set => datos_DECLARACION_EGRESOS.N_NIVEL = value;
        }
        public ListFilter<Int32> N_NIVELs
        {
            get => datos_DECLARACION_EGRESOS.N_NIVELs;
            set => datos_DECLARACION_EGRESOS.N_NIVELs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_EGRESOS.OrderByCriterios;
            set => datos_DECLARACION_EGRESOS.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_EGRESOS() => datos_DECLARACION_EGRESOS = new dald__l_DECLARACION_EGRESOS();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_EGRESOS.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_EGRESOS.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_EGRESOS.single_select();
        }

        #endregion

    }
}
