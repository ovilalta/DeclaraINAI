using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_ALTA_COMODATO_VEHICULO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO> lista_ALTA_COMODATO_VEHICULOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_COMODATO_VEHICULO> base_ALTA_COMODATO_VEHICULOs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_COMODATO { get; set; }
        internal ListFilter<Int32> NID_COMODATOs { get; set; }

        internal IntegerFilter NID_TIPO_VEHICULO { get; set; }
        internal ListFilter<Int32> NID_TIPO_VEHICULOs { get; set; }

        internal IntegerFilter NID_MARCA { get; set; }
        internal ListFilter<Int32> NID_MARCAs { get; set; }

        internal StringFilter C_MODELO { get; set; }
        internal ListFilter<String> C_MODELOs { get; set; }

        internal StringFilter V_DESCRIPCION { get; set; }
        internal ListFilter<String> V_DESCRIPCIONs { get; set; }

        internal StringFilter E_NUMERO_SERIE { get; set; }
        internal ListFilter<String> E_NUMERO_SERIEs { get; set; }

        internal IntegerFilter NID_PAIS { get; set; }
        internal ListFilter<Int32> NID_PAISs { get; set; }

        internal StringFilter CID_ENTIDAD_FEDERATIVA { get; set; }
        internal ListFilter<String> CID_ENTIDAD_FEDERATIVAs { get; set; }

        private List<Order> _OrderByCriterios;
        internal List<Order> OrderByCriterios
        {
            get
            {
                if (_OrderByCriterios == null) _OrderByCriterios = new List<Order>();
                return _OrderByCriterios;
            }
            set { _OrderByCriterios = value; }
        }
        protected IQueryable<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_COMODATO_VEHICULO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_ALTA_COMODATO_VEHICULO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_COMODATOs = new ListFilter<Int32>();
            NID_TIPO_VEHICULOs = new ListFilter<Int32>();
            NID_MARCAs = new ListFilter<Int32>();
            C_MODELOs = new ListFilter<String>();
            V_DESCRIPCIONs = new ListFilter<String>();
            E_NUMERO_SERIEs = new ListFilter<String>();
            NID_PAISs = new ListFilter<Int32>();
            CID_ENTIDAD_FEDERATIVAs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.ALTA_COMODATO_VEHICULO
                           select p;
        }
        protected void Select()
        {
            query = from qALTA_COMODATO_VEHICULO in db.ALTA_COMODATO_VEHICULO
                    join qCAT_TIPO_VEHICULO in db.CAT_TIPO_VEHICULO on qALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO equals qCAT_TIPO_VEHICULO.NID_TIPO_VEHICULO
                    join qCAT_MARCA_VEHICULO in db.CAT_MARCA_VEHICULO on qALTA_COMODATO_VEHICULO.NID_MARCA equals qCAT_MARCA_VEHICULO.NID_MARCA
                    join qCAT_ENTIDAD_FEDERATIVA in db.CAT_ENTIDAD_FEDERATIVA on new { qALTA_COMODATO_VEHICULO.NID_PAIS, qALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA } equals new { qCAT_ENTIDAD_FEDERATIVA.NID_PAIS, qCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA }
                    select new Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO
                    {
                        VID_NOMBRE = qALTA_COMODATO_VEHICULO.VID_NOMBRE,
                        VID_FECHA = qALTA_COMODATO_VEHICULO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_COMODATO_VEHICULO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_COMODATO_VEHICULO.NID_DECLARACION,
                        NID_COMODATO = qALTA_COMODATO_VEHICULO.NID_COMODATO,
                        NID_TIPO_VEHICULO = qALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO,
                        NID_MARCA = qALTA_COMODATO_VEHICULO.NID_MARCA,
                        C_MODELO = qALTA_COMODATO_VEHICULO.C_MODELO,
                        V_DESCRIPCION = qALTA_COMODATO_VEHICULO.V_DESCRIPCION,
                        E_NUMERO_SERIE = qALTA_COMODATO_VEHICULO.E_NUMERO_SERIE,
                        NID_PAIS = qALTA_COMODATO_VEHICULO.NID_PAIS,
                        CID_ENTIDAD_FEDERATIVA = qALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA,
                        V_TIPO_VEHICULO = qCAT_TIPO_VEHICULO.V_TIPO_VEHICULO,
                        V_MARCA = qCAT_MARCA_VEHICULO.V_MARCA,
                        V_ENTIDAD_FEDERATIVA = qCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_DECLARACION, single_query);

            if (NID_COMODATOs.Values.Count > 0) single_query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : single_query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_COMODATO, single_query);

            if (NID_TIPO_VEHICULOs.Values.Count > 0) single_query = (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_VEHICULOs.Values.Contains(p.NID_TIPO_VEHICULO)) : single_query.Where(p => !NID_TIPO_VEHICULOs.Values.Contains(p.NID_TIPO_VEHICULO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_TIPO_VEHICULO, single_query);

            if (NID_MARCAs.Values.Count > 0) single_query = (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_MARCAs.Values.Contains(p.NID_MARCA)) : single_query.Where(p => !NID_MARCAs.Values.Contains(p.NID_MARCA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_MARCA, single_query);

            if (C_MODELOs.Values.Count > 0) single_query = (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_MODELOs.Values.Contains(p.C_MODELO)) : single_query.Where(p => !C_MODELOs.Values.Contains(p.C_MODELO));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(C_MODELO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.C_MODELO, single_query);

            if (V_DESCRIPCIONs.Values.Count > 0) single_query = (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DESCRIPCIONs.Values.Contains(p.V_DESCRIPCION)) : single_query.Where(p => !V_DESCRIPCIONs.Values.Contains(p.V_DESCRIPCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.V_DESCRIPCION, single_query);

            if (E_NUMERO_SERIEs.Values.Count > 0) single_query = (E_NUMERO_SERIEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NUMERO_SERIEs.Values.Contains(p.E_NUMERO_SERIE)) : single_query.Where(p => !E_NUMERO_SERIEs.Values.Contains(p.E_NUMERO_SERIE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(E_NUMERO_SERIE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.E_NUMERO_SERIE, single_query);

            if (NID_PAISs.Values.Count > 0) single_query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : single_query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(NID_PAIS, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_PAIS, single_query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) single_query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : single_query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.CID_ENTIDAD_FEDERATIVA, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(VID_FECHA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_DECLARACION, query);

            if (NID_COMODATOs.Values.Count > 0) query = (NID_COMODATOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_COMODATOs.Values.Contains(p.NID_COMODATO)) : query.Where(p => !NID_COMODATOs.Values.Contains(p.NID_COMODATO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(NID_COMODATO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_COMODATO, query);

            if (NID_TIPO_VEHICULOs.Values.Count > 0) query = (NID_TIPO_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_VEHICULOs.Values.Contains(p.NID_TIPO_VEHICULO)) : query.Where(p => !NID_TIPO_VEHICULOs.Values.Contains(p.NID_TIPO_VEHICULO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(NID_TIPO_VEHICULO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_TIPO_VEHICULO, query);

            if (NID_MARCAs.Values.Count > 0) query = (NID_MARCAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_MARCAs.Values.Contains(p.NID_MARCA)) : query.Where(p => !NID_MARCAs.Values.Contains(p.NID_MARCA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(NID_MARCA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_MARCA, query);

            if (C_MODELOs.Values.Count > 0) query = (C_MODELOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_MODELOs.Values.Contains(p.C_MODELO)) : query.Where(p => !C_MODELOs.Values.Contains(p.C_MODELO));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(C_MODELO, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.C_MODELO, query);

            if (V_DESCRIPCIONs.Values.Count > 0) query = (V_DESCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DESCRIPCIONs.Values.Contains(p.V_DESCRIPCION)) : query.Where(p => !V_DESCRIPCIONs.Values.Contains(p.V_DESCRIPCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(V_DESCRIPCION, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.V_DESCRIPCION, query);

            if (E_NUMERO_SERIEs.Values.Count > 0) query = (E_NUMERO_SERIEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NUMERO_SERIEs.Values.Contains(p.E_NUMERO_SERIE)) : query.Where(p => !E_NUMERO_SERIEs.Values.Contains(p.E_NUMERO_SERIE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(E_NUMERO_SERIE, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.E_NUMERO_SERIE, query);

            if (NID_PAISs.Values.Count > 0) query = (NID_PAISs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PAISs.Values.Contains(p.NID_PAIS)) : query.Where(p => !NID_PAISs.Values.Contains(p.NID_PAIS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(NID_PAIS, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.NID_PAIS, query);

            if (CID_ENTIDAD_FEDERATIVAs.Values.Count > 0) query = (CID_ENTIDAD_FEDERATIVAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA)) : query.Where(p => !CID_ENTIDAD_FEDERATIVAs.Values.Contains(p.CID_ENTIDAD_FEDERATIVA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>(CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO.Properties.CID_ENTIDAD_FEDERATIVA, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_ALTA_COMODATO_VEHICULOs = single_query.AsNoTracking().ToList();
            else
                base_ALTA_COMODATO_VEHICULOs = new List<MODELDeclara_V2.ALTA_COMODATO_VEHICULO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_ALTA_COMODATO_VEHICULOs = query.AsNoTracking().ToList();
            else
                lista_ALTA_COMODATO_VEHICULOs = new List<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_COMODATO_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                single_query = r;
            }
        }
        internal void orderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_COMODATO_VEHICULO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 0; x < OrderByCriterios.Count(); x++)
                {
                    if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
                        r.ThenBy(OrderByCriterios[x].Field.ToString());
                    else
                        r.ThenByDescending(OrderByCriterios[x].Field.ToString());
                }
                query = r;
            }
        }
        internal void clearOrderBy()
        {
            _OrderByCriterios = null;
        }

        #endregion

    }
}
