using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_ALTA_COMODATO_VEHICULO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_ALTA_COMODATO_VEHICULO datos_ALTA_COMODATO_VEHICULO { get; set; }
        public List<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO> lista_ALTA_COMODATO_VEHICULO => datos_ALTA_COMODATO_VEHICULO.lista_ALTA_COMODATO_VEHICULOs;
        protected List<MODELDeclara_V2.ALTA_COMODATO_VEHICULO> base_ALTA_COMODATO_VEHICULOs => datos_ALTA_COMODATO_VEHICULO.base_ALTA_COMODATO_VEHICULOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_NOMBRE;
            set => datos_ALTA_COMODATO_VEHICULO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_NOMBREs;
            set => datos_ALTA_COMODATO_VEHICULO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_FECHA;
            set => datos_ALTA_COMODATO_VEHICULO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_FECHAs;
            set => datos_ALTA_COMODATO_VEHICULO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_HOMOCLAVE;
            set => datos_ALTA_COMODATO_VEHICULO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_ALTA_COMODATO_VEHICULO.VID_HOMOCLAVEs;
            set => datos_ALTA_COMODATO_VEHICULO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_DECLARACION;
            set => datos_ALTA_COMODATO_VEHICULO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_DECLARACIONs;
            set => datos_ALTA_COMODATO_VEHICULO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_COMODATO
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_COMODATO;
            set => datos_ALTA_COMODATO_VEHICULO.NID_COMODATO = value;
        }
        public ListFilter<Int32> NID_COMODATOs
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_COMODATOs;
            set => datos_ALTA_COMODATO_VEHICULO.NID_COMODATOs = value;
        }

        public IntegerFilter NID_TIPO_VEHICULO
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO;
            set => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO = value;
        }
        public ListFilter<Int32> NID_TIPO_VEHICULOs
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULOs;
            set => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULOs = value;
        }

        public IntegerFilter NID_MARCA
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_MARCA;
            set => datos_ALTA_COMODATO_VEHICULO.NID_MARCA = value;
        }
        public ListFilter<Int32> NID_MARCAs
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_MARCAs;
            set => datos_ALTA_COMODATO_VEHICULO.NID_MARCAs = value;
        }

        public StringFilter C_MODELO
        {
            get => datos_ALTA_COMODATO_VEHICULO.C_MODELO;
            set => datos_ALTA_COMODATO_VEHICULO.C_MODELO = value;
        }
        public ListFilter<String> C_MODELOs
        {
            get => datos_ALTA_COMODATO_VEHICULO.C_MODELOs;
            set => datos_ALTA_COMODATO_VEHICULO.C_MODELOs = value;
        }

        public StringFilter V_DESCRIPCION
        {
            get => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCION;
            set => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCION = value;
        }
        public ListFilter<String> V_DESCRIPCIONs
        {
            get => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCIONs;
            set => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCIONs = value;
        }

        public StringFilter E_NUMERO_SERIE
        {
            get => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIE;
            set => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIE = value;
        }
        public ListFilter<String> E_NUMERO_SERIEs
        {
            get => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIEs;
            set => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIEs = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_PAIS;
            set => datos_ALTA_COMODATO_VEHICULO.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_PAISs;
            set => datos_ALTA_COMODATO_VEHICULO.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
            get => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVAs;
            set => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_COMODATO_VEHICULO.OrderByCriterios;
            set => datos_ALTA_COMODATO_VEHICULO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_ALTA_COMODATO_VEHICULO() => datos_ALTA_COMODATO_VEHICULO = new dald__l_ALTA_COMODATO_VEHICULO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_ALTA_COMODATO_VEHICULO.select();
        }
        public void clearOrderBy()
        {
            datos_ALTA_COMODATO_VEHICULO.clearOrderBy();
        }
        public void single_select()
        {
            datos_ALTA_COMODATO_VEHICULO.single_select();
        }

        #endregion

    }
}
