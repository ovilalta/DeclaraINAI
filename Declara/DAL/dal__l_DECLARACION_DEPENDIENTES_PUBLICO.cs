using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_DEPENDIENTES_PUBLICO : _dal_base_Declara
    {

        #region *** Propiedades ***
        internal List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO> lista_DECLARACION_DEPENDIENTES_PUBLICOs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO> base_DECLARACION_DEPENDIENTES_PUBLICOs { get; set; }

        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_DEPENDIENTE { get; set; }
        internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

        internal IntegerFilter NID_AMBITO_SECTOR { get; set; }
        internal ListFilter<Int32> NID_AMBITO_SECTORs { get; set; }

        internal IntegerFilter NID_NIVEL_GOBIERNO { get; set; }
        internal ListFilter<Int32> NID_NIVEL_GOBIERNOs { get; set; }

        internal IntegerFilter NID_AMBITO_PUBLICO { get; set; }
        internal ListFilter<Int32> NID_AMBITO_PUBLICOs { get; set; }

        internal StringFilter V_NOMBRE_ENTE { get; set; }
        internal ListFilter<String> V_NOMBRE_ENTEs { get; set; }

        internal StringFilter V_AREA_ADSCRIPCION { get; set; }
        internal ListFilter<String> V_AREA_ADSCRIPCIONs { get; set; }

        internal StringFilter V_CARGO { get; set; }
        internal ListFilter<String> V_CARGOs { get; set; }

        internal StringFilter V_FUNCION_PRINCIPAL { get; set; }
        internal ListFilter<String> V_FUNCION_PRINCIPALs { get; set; }

        internal DecimalFilter M_SALARIO_MENSUAL { get; set; }

        internal DateTimeFilter F_INGRESO { get; set; }

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
        protected IQueryable<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO> single_query { get; set; }

        #endregion

        #region *** Constructores ***
        internal dal__l_DECLARACION_DEPENDIENTES_PUBLICO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_DEPENDIENTEs = new ListFilter<Int32>();
            NID_AMBITO_SECTORs = new ListFilter<Int32>();
            NID_NIVEL_GOBIERNOs = new ListFilter<Int32>();
            NID_AMBITO_PUBLICOs = new ListFilter<Int32>();
            V_NOMBRE_ENTEs = new ListFilter<String>();
            V_AREA_ADSCRIPCIONs = new ListFilter<String>();
            V_CARGOs = new ListFilter<String>();
            V_FUNCION_PRINCIPALs = new ListFilter<String>();
            query = null;
            single_query = null;
        }

        #endregion

        #region *** Metodos ***
        protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_DEPENDIENTES_PUBLICO
                           select p;
        }
        protected void Select()
        {
            query = from qDECLARACION_DEPENDIENTES_PUBLICO in db.DECLARACION_DEPENDIENTES_PUBLICO
                    join qCAT_AMBITO_SECTOR in db.CAT_AMBITO_SECTOR on qDECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR equals qCAT_AMBITO_SECTOR.NID_AMBITO_SECTOR
                    join qCAT_NIVEL_GOBIERNO in db.CAT_NIVEL_GOBIERNO on qDECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO equals qCAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO
                    join qCAT_AMBITO_PUBLICO in db.CAT_AMBITO_PUBLICO on qDECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO equals qCAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO
                    select new Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO
                    {
                        VID_NOMBRE = qDECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION,
                        NID_DEPENDIENTE = qDECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE,
                        NID_AMBITO_SECTOR = qDECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR,
                        NID_NIVEL_GOBIERNO = qDECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO,
                        NID_AMBITO_PUBLICO = qDECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO,
                        V_NOMBRE_ENTE = qDECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE,
                        V_AREA_ADSCRIPCION = qDECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION,
                        V_CARGO = qDECLARACION_DEPENDIENTES_PUBLICO.V_CARGO,
                        V_FUNCION_PRINCIPAL = qDECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL,
                        M_SALARIO_MENSUAL = qDECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL,
                        F_INGRESO = qDECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO,
                        V_AMBITO_SECTOR = qCAT_AMBITO_SECTOR.V_AMBITO_SECTOR,
                        V_NIVEL_GOBIERNO = qCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO,
                        V_AMBITO_PUBLICO = qCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO,
                    };
        }
        protected void Single_Where()
        {
            if (VID_NOMBREs.Values.Count > 0) single_query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_NOMBRE, single_query);

            if (VID_FECHAs.Values.Count > 0) single_query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_FECHA, single_query);

            if (VID_HOMOCLAVEs.Values.Count > 0) single_query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_HOMOCLAVE, single_query);

            if (NID_DECLARACIONs.Values.Count > 0) single_query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_DECLARACION, single_query);

            if (NID_DEPENDIENTEs.Values.Count > 0) single_query = (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(NID_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_DEPENDIENTE, single_query);

            if (NID_AMBITO_SECTORs.Values.Count > 0) single_query = (NID_AMBITO_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR)) : single_query.Where(p => !NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(NID_AMBITO_SECTOR, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_AMBITO_SECTOR, single_query);

            if (NID_NIVEL_GOBIERNOs.Values.Count > 0) single_query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : single_query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_NIVEL_GOBIERNO, single_query);

            if (NID_AMBITO_PUBLICOs.Values.Count > 0) single_query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : single_query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_AMBITO_PUBLICO, single_query);

            if (V_NOMBRE_ENTEs.Values.Count > 0) single_query = (V_NOMBRE_ENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NOMBRE_ENTEs.Values.Contains(p.V_NOMBRE_ENTE)) : single_query.Where(p => !V_NOMBRE_ENTEs.Values.Contains(p.V_NOMBRE_ENTE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(V_NOMBRE_ENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_NOMBRE_ENTE, single_query);

            if (V_AREA_ADSCRIPCIONs.Values.Count > 0) single_query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : single_query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_AREA_ADSCRIPCION, single_query);

            if (V_CARGOs.Values.Count > 0) single_query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : single_query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_CARGO, single_query);

            if (V_FUNCION_PRINCIPALs.Values.Count > 0) single_query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : single_query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_FUNCION_PRINCIPAL, single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(M_SALARIO_MENSUAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.M_SALARIO_MENSUAL, single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.F_INGRESO, single_query);

        }
        protected void Where()
        {
            if (VID_NOMBREs.Values.Count > 0) query = (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Values.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Values.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_NOMBRE, query);

            if (VID_FECHAs.Values.Count > 0) query = (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Values.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Values.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_FECHA, query);

            if (VID_HOMOCLAVEs.Values.Count > 0) query = (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Values.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.VID_HOMOCLAVE, query);

            if (NID_DECLARACIONs.Values.Count > 0) query = (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Values.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_DECLARACION, query);

            if (NID_DEPENDIENTEs.Values.Count > 0) query = (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Values.Contains(p.NID_DEPENDIENTE));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(NID_DEPENDIENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_DEPENDIENTE, query);

            if (NID_AMBITO_SECTORs.Values.Count > 0) query = (NID_AMBITO_SECTORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR)) : query.Where(p => !NID_AMBITO_SECTORs.Values.Contains(p.NID_AMBITO_SECTOR));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(NID_AMBITO_SECTOR, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_AMBITO_SECTOR, query);

            if (NID_NIVEL_GOBIERNOs.Values.Count > 0) query = (NID_NIVEL_GOBIERNOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO)) : query.Where(p => !NID_NIVEL_GOBIERNOs.Values.Contains(p.NID_NIVEL_GOBIERNO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(NID_NIVEL_GOBIERNO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_NIVEL_GOBIERNO, query);

            if (NID_AMBITO_PUBLICOs.Values.Count > 0) query = (NID_AMBITO_PUBLICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO)) : query.Where(p => !NID_AMBITO_PUBLICOs.Values.Contains(p.NID_AMBITO_PUBLICO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(NID_AMBITO_PUBLICO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.NID_AMBITO_PUBLICO, query);

            if (V_NOMBRE_ENTEs.Values.Count > 0) query = (V_NOMBRE_ENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NOMBRE_ENTEs.Values.Contains(p.V_NOMBRE_ENTE)) : query.Where(p => !V_NOMBRE_ENTEs.Values.Contains(p.V_NOMBRE_ENTE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(V_NOMBRE_ENTE, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_NOMBRE_ENTE, query);

            if (V_AREA_ADSCRIPCIONs.Values.Count > 0) query = (V_AREA_ADSCRIPCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION)) : query.Where(p => !V_AREA_ADSCRIPCIONs.Values.Contains(p.V_AREA_ADSCRIPCION));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(V_AREA_ADSCRIPCION, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_AREA_ADSCRIPCION, query);

            if (V_CARGOs.Values.Count > 0) query = (V_CARGOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CARGOs.Values.Contains(p.V_CARGO)) : query.Where(p => !V_CARGOs.Values.Contains(p.V_CARGO));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(V_CARGO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_CARGO, query);

            if (V_FUNCION_PRINCIPALs.Values.Count > 0) query = (V_FUNCION_PRINCIPALs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL)) : query.Where(p => !V_FUNCION_PRINCIPALs.Values.Contains(p.V_FUNCION_PRINCIPAL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(V_FUNCION_PRINCIPAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.V_FUNCION_PRINCIPAL, query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(M_SALARIO_MENSUAL, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.M_SALARIO_MENSUAL, query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>(F_INGRESO, Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO.Properties.F_INGRESO, query);

        }
        protected void Single_Exec()
        {
            if (single_query.Any())
                base_DECLARACION_DEPENDIENTES_PUBLICOs = single_query.AsNoTracking().ToList();
            else
                base_DECLARACION_DEPENDIENTES_PUBLICOs = new List<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO>();
        }
        protected void Exec()
        {
            if (query.Any())
                lista_DECLARACION_DEPENDIENTES_PUBLICOs = query.AsNoTracking().ToList();
            else
                lista_DECLARACION_DEPENDIENTES_PUBLICOs = new List<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO>();
        }
        internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_DEPENDIENTES_PUBLICO> r;
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
