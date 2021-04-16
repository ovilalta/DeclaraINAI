using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_ALTA_MUEBLE_COPROPIETARIO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_ALTA_MUEBLE_COPROPIETARIO datos_ALTA_MUEBLE_COPROPIETARIO { get; set; }
        public List<Declara_V2.MODELextended.ALTA_MUEBLE_COPROPIETARIO> lista_ALTA_MUEBLE_COPROPIETARIO => datos_ALTA_MUEBLE_COPROPIETARIO.lista_ALTA_MUEBLE_COPROPIETARIOs;
        protected List<MODELDeclara_V2.ALTA_MUEBLE_COPROPIETARIO> base_ALTA_MUEBLE_COPROPIETARIOs => datos_ALTA_MUEBLE_COPROPIETARIO.base_ALTA_MUEBLE_COPROPIETARIOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_NOMBRE;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_NOMBREs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_FECHA;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_FECHAs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_HOMOCLAVE;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.VID_HOMOCLAVEs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_DECLARACION;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_DECLARACIONs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_MUEBLE
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_MUEBLE;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_MUEBLE = value;
        }
        public ListFilter<Int32> NID_MUEBLEs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_MUEBLEs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_MUEBLEs = value;
        }

        public IntegerFilter NID_COPROPIETARIO
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_COPROPIETARIO;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_COPROPIETARIO = value;
        }
        public ListFilter<Int32> NID_COPROPIETARIOs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.NID_COPROPIETARIOs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.NID_COPROPIETARIOs = value;
        }

        public StringFilter CID_TIPO_PERSONA
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONA;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONA = value;
        }
        public ListFilter<String> CID_TIPO_PERSONAs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONAs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONAs = value;
        }

        public StringFilter V_NOMBRE
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.V_NOMBRE;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.V_NOMBRE = value;
        }
        public ListFilter<String> V_NOMBREs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.V_NOMBREs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.V_NOMBREs = value;
        }

        public StringFilter V_RFC
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.V_RFC;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.V_RFC = value;
        }
        public ListFilter<String> V_RFCs
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.V_RFCs;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.V_RFCs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_MUEBLE_COPROPIETARIO.OrderByCriterios;
            set => datos_ALTA_MUEBLE_COPROPIETARIO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_ALTA_MUEBLE_COPROPIETARIO() => datos_ALTA_MUEBLE_COPROPIETARIO = new dald__l_ALTA_MUEBLE_COPROPIETARIO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_ALTA_MUEBLE_COPROPIETARIO.select();
        }
        public void clearOrderBy()
        {
            datos_ALTA_MUEBLE_COPROPIETARIO.clearOrderBy();
        }
        public void single_select()
        {
            datos_ALTA_MUEBLE_COPROPIETARIO.single_select();
        }

        #endregion

    }
}
