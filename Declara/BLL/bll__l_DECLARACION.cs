using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION : _bllSistema
    {

        internal dald__l_DECLARACION datos_DECLARACION;

        #region *** Atributos ***


        public List<Declara_V2.MODELextended.DECLARACION> lista_DECLARACION => datos_DECLARACION.lista_DECLARACIONs;

        protected List<MODELDeclara_V2.DECLARACION> base_DECLARACIONs => datos_DECLARACION.base_DECLARACIONs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION.VID_NOMBRE;
            set => datos_DECLARACION.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION.VID_NOMBREs;
            set => datos_DECLARACION.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION.VID_FECHA;
            set => datos_DECLARACION.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION.VID_FECHAs;
            set => datos_DECLARACION.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION.VID_HOMOCLAVE;
            set => datos_DECLARACION.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION.VID_HOMOCLAVEs;
            set => datos_DECLARACION.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION.NID_DECLARACION;
            set => datos_DECLARACION.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION.NID_DECLARACIONs;
            set => datos_DECLARACION.NID_DECLARACIONs = value;
        }

        public StringFilter C_EJERCICIO
        {
            get => datos_DECLARACION.C_EJERCICIO;
            set => datos_DECLARACION.C_EJERCICIO = value;
        }
        public ListFilter<String> C_EJERCICIOs
        {
            get => datos_DECLARACION.C_EJERCICIOs;
            set => datos_DECLARACION.C_EJERCICIOs = value;
        }

        public IntegerFilter NID_TIPO_DECLARACION
        {
            get => datos_DECLARACION.NID_TIPO_DECLARACION;
            set => datos_DECLARACION.NID_TIPO_DECLARACION = value;
        }
        public ListFilter<Int32> NID_TIPO_DECLARACIONs
        {
            get => datos_DECLARACION.NID_TIPO_DECLARACIONs;
            set => datos_DECLARACION.NID_TIPO_DECLARACIONs = value;
        }

        public IntegerFilter NID_ESTADO
        {
            get => datos_DECLARACION.NID_ESTADO;
            set => datos_DECLARACION.NID_ESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADOs
        {
            get => datos_DECLARACION.NID_ESTADOs;
            set => datos_DECLARACION.NID_ESTADOs = value;
        }

        public StringFilter E_OBSERVACIONES
        {
            get => datos_DECLARACION.E_OBSERVACIONES;
            set => datos_DECLARACION.E_OBSERVACIONES = value;
        }
        public ListFilter<String> E_OBSERVACIONESs
        {
            get => datos_DECLARACION.E_OBSERVACIONESs;
            set => datos_DECLARACION.E_OBSERVACIONESs = value;
        }

        public StringFilter E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION.E_OBSERVACIONES_MARCADO = value;
        }
        public ListFilter<String> E_OBSERVACIONES_MARCADOs
        {
            get => datos_DECLARACION.E_OBSERVACIONES_MARCADOs;
            set => datos_DECLARACION.E_OBSERVACIONES_MARCADOs = value;
        }

        public StringFilter V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION.V_OBSERVACIONES_TESTADO = value;
        }
        public ListFilter<String> V_OBSERVACIONES_TESTADOs
        {
            get => datos_DECLARACION.V_OBSERVACIONES_TESTADOs;
            set => datos_DECLARACION.V_OBSERVACIONES_TESTADOs = value;
        }

        public IntegerFilter NID_ESTADO_TESTADO
        {
            get => datos_DECLARACION.NID_ESTADO_TESTADO;
            set => datos_DECLARACION.NID_ESTADO_TESTADO = value;
        }
        public ListFilter<Int32> NID_ESTADO_TESTADOs
        {
            get => datos_DECLARACION.NID_ESTADO_TESTADOs;
            set => datos_DECLARACION.NID_ESTADO_TESTADOs = value;
        }

        public System.Nullable<Boolean> L_AUTORIZA_PUBLICAR
        {
            get => datos_DECLARACION.L_AUTORIZA_PUBLICAR;
            set => datos_DECLARACION.L_AUTORIZA_PUBLICAR = value;
        }
        public ListFilter<Boolean> L_AUTORIZA_PUBLICARs
        {
            get => datos_DECLARACION.L_AUTORIZA_PUBLICARs;
            set => datos_DECLARACION.L_AUTORIZA_PUBLICARs = value;
        }

        public DateTimeFilter F_REGISTRO
        {
            get => datos_DECLARACION.F_REGISTRO;
            set => datos_DECLARACION.F_REGISTRO = value;
        }
        public ListFilter<DateTime> F_REGISTROs
        {
            get => datos_DECLARACION.F_REGISTROs;
            set => datos_DECLARACION.F_REGISTROs = value;
        }

        public DateTimeFilter F_ENVIO
        {
            get => datos_DECLARACION.F_ENVIO;
            set => datos_DECLARACION.F_ENVIO = value;
        }
        public ListFilter<DateTime> F_ENVIOs
        {
            get => datos_DECLARACION.F_ENVIOs;
            set => datos_DECLARACION.F_ENVIOs = value;
        }

        public System.Nullable<Boolean> L_CONFLICTO
        {
            get => datos_DECLARACION.L_CONFLICTO;
            set => datos_DECLARACION.L_CONFLICTO = value;
        }
        public ListFilter<Boolean> L_CONFLICTOs
        {
            get => datos_DECLARACION.L_CONFLICTOs;
            set => datos_DECLARACION.L_CONFLICTOs = value;
        }

        public StringFilter V_HASH
        {
            get => datos_DECLARACION.V_HASH;
            set => datos_DECLARACION.V_HASH = value;
        }
        public ListFilter<String> V_HASHs
        {
            get => datos_DECLARACION.V_HASHs;
            set => datos_DECLARACION.V_HASHs = value;
        }


        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION.OrderByCriterios;
            set => datos_DECLARACION.OrderByCriterios = value;
        }


        #endregion


        #region *** Constructores ***

        public bll__l_DECLARACION() => datos_DECLARACION = new dald__l_DECLARACION();

        #endregion


        #region *** Metodos ***

        public void select()
        {
            datos_DECLARACION.select();
        }

        public void clearOrderBy()
        {
            datos_DECLARACION.clearOrderBy();
        }

        public void Select()
        {
            datos_DECLARACION.single_select();
        }

        #endregion

    }
}
