using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_ALTA_INMUEBLE_COPROPIETARIO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_ALTA_INMUEBLE_COPROPIETARIO datos_ALTA_INMUEBLE_COPROPIETARIO { get; set; }
        public List<Declara_V2.MODELextended.ALTA_INMUEBLE_COPROPIETARIO> lista_ALTA_INMUEBLE_COPROPIETARIO => datos_ALTA_INMUEBLE_COPROPIETARIO.lista_ALTA_INMUEBLE_COPROPIETARIOs;
        protected List<MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO> base_ALTA_INMUEBLE_COPROPIETARIOs => datos_ALTA_INMUEBLE_COPROPIETARIO.base_ALTA_INMUEBLE_COPROPIETARIOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBRE;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBREs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_FECHA;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_FECHAs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVE;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVEs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACION;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACIONs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_INMUEBLE
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLE;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLE = value;
        }
        public ListFilter<Int32> NID_INMUEBLEs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLEs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLEs = value;
        }

        public IntegerFilter NID_COPROPIETARIO
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIO;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIO = value;
        }
        public ListFilter<Int32> NID_COPROPIETARIOs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIOs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIOs = value;
        }

        public StringFilter CID_TIPO_PERSONA
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA = value;
        }
        public ListFilter<String> CID_TIPO_PERSONAs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONAs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONAs = value;
        }

        public StringFilter V_NOMBRE
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE = value;
        }
        public ListFilter<String> V_NOMBREs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBREs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBREs = value;
        }

        public StringFilter V_RFC
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFC;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFC = value;
        }
        public ListFilter<String> V_RFCs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFCs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFCs = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_PAIS;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_PAISs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_ENTIDAD_FEDERATIVAs;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.OrderByCriterios;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_ALTA_INMUEBLE_COPROPIETARIO() => datos_ALTA_INMUEBLE_COPROPIETARIO = new dald__l_ALTA_INMUEBLE_COPROPIETARIO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.select();
        }
        public void clearOrderBy()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.clearOrderBy();
        }
        public void single_select()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.single_select();
        }

        #endregion

    }
}
