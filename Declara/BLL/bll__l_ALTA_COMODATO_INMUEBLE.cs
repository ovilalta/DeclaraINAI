using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_ALTA_COMODATO_INMUEBLE : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_ALTA_COMODATO_INMUEBLE datos_ALTA_COMODATO_INMUEBLE { get; set; }
        public List<Declara_V2.MODELextended.ALTA_COMODATO_INMUEBLE> lista_ALTA_COMODATO_INMUEBLE => datos_ALTA_COMODATO_INMUEBLE.lista_ALTA_COMODATO_INMUEBLEs;
        protected List<MODELDeclara_V2.ALTA_COMODATO_INMUEBLE> base_ALTA_COMODATO_INMUEBLEs => datos_ALTA_COMODATO_INMUEBLE.base_ALTA_COMODATO_INMUEBLEs;

        public StringFilter VID_NOMBRE
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBRE;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBREs;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_FECHA;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_FECHAs;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVEs;
            set => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACION;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACIONs;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_COMODATO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATO;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATO = value;
        }
        public ListFilter<Int32> NID_COMODATOs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATOs;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATOs = value;
        }

        public IntegerFilter NID_TIPO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO = value;
        }
        public ListFilter<Int32> NID_TIPOs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_TIPOs;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_TIPOs = value;
        }

        public StringFilter C_CODIGO_POSTAL
        {
            get => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL;
            set => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL = value;
        }
        public ListFilter<String> C_CODIGO_POSTALs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTALs;
            set => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTALs = value;
        }

        public IntegerFilter NID_PAIS
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS = value;
        }
        public ListFilter<Int32> NID_PAISs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_PAISs;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_PAISs = value;
        }

        public StringFilter CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA = value;
        }
        public ListFilter<String> CID_ENTIDAD_FEDERATIVAs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVAs;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVAs = value;
        }

        public StringFilter CID_MUNICIPIO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO = value;
        }
        public ListFilter<String> CID_MUNICIPIOs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIOs;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIOs = value;
        }

        public StringFilter V_COLONIA
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA;
            set => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA = value;
        }
        public ListFilter<String> V_COLONIAs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_COLONIAs;
            set => datos_ALTA_COMODATO_INMUEBLE.V_COLONIAs = value;
        }

        public StringFilter V_DOMICILIO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO;
            set => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO = value;
        }
        public ListFilter<String> V_DOMICILIOs
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIOs;
            set => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIOs = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_ALTA_COMODATO_INMUEBLE.OrderByCriterios;
            set => datos_ALTA_COMODATO_INMUEBLE.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_ALTA_COMODATO_INMUEBLE() => datos_ALTA_COMODATO_INMUEBLE = new dald__l_ALTA_COMODATO_INMUEBLE();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_ALTA_COMODATO_INMUEBLE.select();
        }
        public void clearOrderBy()
        {
            datos_ALTA_COMODATO_INMUEBLE.clearOrderBy();
        }
        public void single_select()
        {
            datos_ALTA_COMODATO_INMUEBLE.single_select();
        }

        #endregion

    }
}
