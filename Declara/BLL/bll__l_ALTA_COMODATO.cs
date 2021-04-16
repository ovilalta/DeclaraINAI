using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_ALTA_COMODATO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_ALTA_COMODATO datos_ALTA_COMODATO { get; set; }
        public List<Declara_V2.MODELextended.ALTA_COMODATO> lista_ALTA_COMODATO => datos_ALTA_COMODATO.lista_ALTA_COMODATOs;
        protected List<MODELDeclara_V2.ALTA_COMODATO> base_ALTA_COMODATOs => datos_ALTA_COMODATO.base_ALTA_COMODATOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_ALTA_COMODATO.VID_NOMBRE;
            set => datos_ALTA_COMODATO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_ALTA_COMODATO.VID_NOMBREs;
            set => datos_ALTA_COMODATO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_ALTA_COMODATO.VID_FECHA;
            set => datos_ALTA_COMODATO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_ALTA_COMODATO.VID_FECHAs;
            set => datos_ALTA_COMODATO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_ALTA_COMODATO.VID_HOMOCLAVE;
            set => datos_ALTA_COMODATO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_ALTA_COMODATO.VID_HOMOCLAVEs;
            set => datos_ALTA_COMODATO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_ALTA_COMODATO.NID_DECLARACION;
            set => datos_ALTA_COMODATO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_ALTA_COMODATO.NID_DECLARACIONs;
            set => datos_ALTA_COMODATO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_COMODATO
        {
            get => datos_ALTA_COMODATO.NID_COMODATO;
            set => datos_ALTA_COMODATO.NID_COMODATO = value;
        }
        public ListFilter<Int32> NID_COMODATOs
        {
            get => datos_ALTA_COMODATO.NID_COMODATOs;
            set => datos_ALTA_COMODATO.NID_COMODATOs = value;
        }

        public StringFilter CID_TIPO_PERSONA
        {
            get => datos_ALTA_COMODATO.CID_TIPO_PERSONA;
            set => datos_ALTA_COMODATO.CID_TIPO_PERSONA = value;
        }
        public ListFilter<String> CID_TIPO_PERSONAs
        {
            get => datos_ALTA_COMODATO.CID_TIPO_PERSONAs;
            set => datos_ALTA_COMODATO.CID_TIPO_PERSONAs = value;
        }

        public StringFilter E_TITULAR
        {
            get => datos_ALTA_COMODATO.E_TITULAR;
            set => datos_ALTA_COMODATO.E_TITULAR = value;
        }
        public ListFilter<String> E_TITULARs
        {
            get => datos_ALTA_COMODATO.E_TITULARs;
            set => datos_ALTA_COMODATO.E_TITULARs = value;
        }

        public StringFilter E_RFC
        {
            get => datos_ALTA_COMODATO.E_RFC;
            set => datos_ALTA_COMODATO.E_RFC = value;
        }
        public ListFilter<String> E_RFCs
        {
            get => datos_ALTA_COMODATO.E_RFCs;
            set => datos_ALTA_COMODATO.E_RFCs = value;
        }

        public IntegerFilter NID_TIPO_RELACION
        {
            get => datos_ALTA_COMODATO.NID_TIPO_RELACION;
            set => datos_ALTA_COMODATO.NID_TIPO_RELACION = value;
        }
        public ListFilter<Int32> NID_TIPO_RELACIONs
        {
            get => datos_ALTA_COMODATO.NID_TIPO_RELACIONs;
            set => datos_ALTA_COMODATO.NID_TIPO_RELACIONs = value;
        }

        public StringFilter E_OBSERVACIONES
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONES;
            set => datos_ALTA_COMODATO.E_OBSERVACIONES = value;
        }
        public ListFilter<String> E_OBSERVACIONESs
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONESs;
            set => datos_ALTA_COMODATO.E_OBSERVACIONESs = value;
        }

        public StringFilter E_OBSERVACIONES_MARCADO
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO;
            set => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO = value;
        }
        public ListFilter<String> E_OBSERVACIONES_MARCADOs
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADOs;
            set => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADOs = value;
        }

        public StringFilter V_OBSERVACIONES_TESTADO
        {
            get => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO;
            set => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO = value;
        }
        public ListFilter<String> V_OBSERVACIONES_TESTADOs
        {
            get => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADOs;
            set => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADOs = value;
        }

        public IntegerFilter NID_ESTADO_TESTADO
        {
            get => datos_ALTA_COMODATO.NID_ESTADO_TESTADO;
            set => datos_ALTA_COMODATO.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
            get => datos_ALTA_COMODATO.NID_ESTADO_TESTADOs;
            set => datos_ALTA_COMODATO.NID_ESTADO_TESTADOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_COMODATO.OrderByCriterios;
            set => datos_ALTA_COMODATO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_ALTA_COMODATO() => datos_ALTA_COMODATO = new dald__l_ALTA_COMODATO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_ALTA_COMODATO.select();
        }
        public void clearOrderBy()
        {
            datos_ALTA_COMODATO.clearOrderBy();
        }
        public void single_select()
        {
            datos_ALTA_COMODATO.single_select();
        }

        #endregion

    }
}
