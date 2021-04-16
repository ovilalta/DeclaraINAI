using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll__l_DECLARACION_DEPENDIENTES_PRIVADO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald__l_DECLARACION_DEPENDIENTES_PRIVADO datos_DECLARACION_DEPENDIENTES_PRIVADO { get; set; }
        public List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PRIVADO> lista_DECLARACION_DEPENDIENTES_PRIVADO => datos_DECLARACION_DEPENDIENTES_PRIVADO.lista_DECLARACION_DEPENDIENTES_PRIVADOs;
        protected List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO> base_DECLARACION_DEPENDIENTES_PRIVADOs => datos_DECLARACION_DEPENDIENTES_PRIVADO.base_DECLARACION_DEPENDIENTES_PRIVADOs;

        public StringFilter VID_NOMBRE
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE = value;
        }
        public ListFilter<String> VID_NOMBREs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBREs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBREs = value;
        }

        public StringFilter VID_FECHA
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA = value;
        }
        public ListFilter<String> VID_FECHAs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHAs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHAs = value;
        }

        public StringFilter VID_HOMOCLAVE
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE = value;
        }
        public ListFilter<String> VID_HOMOCLAVEs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVEs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVEs = value;
        }

        public IntegerFilter NID_DECLARACION
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION = value;
        }
        public ListFilter<Int32> NID_DECLARACIONs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACIONs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACIONs = value;
        }

        public IntegerFilter NID_DEPENDIENTE
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE = value;
        }
        public ListFilter<Int32> NID_DEPENDIENTEs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTEs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTEs = value;
        }

        public StringFilter V_NOMBRE
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = value;
        }
        public ListFilter<String> V_NOMBREs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBREs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBREs = value;
        }

        public StringFilter V_CARGO
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = value;
        }
        public ListFilter<String> V_CARGOs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGOs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGOs = value;
        }

        public StringFilter V_RFC
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = value;
        }
        public ListFilter<String> V_RFCs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFCs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFCs = value;
        }

        public DateTimeFilter F_INGRESO
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO = value;
        }

        public IntegerFilter NID_SECTOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = value;
        }
        public ListFilter<Int32> NID_SECTORs
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTORs;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTORs = value;
        }

        public DecimalFilter M_SALARIO_MENSUAL
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = value;
        }

        public System.Nullable<Boolean> L_PROVEEDOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = value;
        }

        public List<Order> OrderByCriterios
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.OrderByCriterios;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.OrderByCriterios = value;
        }

        #endregion

        #region *** Constructores ***
        public bll__l_DECLARACION_DEPENDIENTES_PRIVADO() => datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald__l_DECLARACION_DEPENDIENTES_PRIVADO();

        #endregion

        #region *** Metodos ***
        public void select()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.select();
        }
        public void clearOrderBy()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.clearOrderBy();
        }
        public void single_select()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.single_select();
        }

        #endregion

    }
}
