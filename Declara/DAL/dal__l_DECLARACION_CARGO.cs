using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal__l_DECLARACION_CARGO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_CARGO> lista_DECLARACION_CARGOs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_CARGO> base_DECLARACION_CARGOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_PUESTO { get; set; }
        internal ListFilter<Int32> NID_PUESTOs { get; set; }

        internal StringFilter V_DENOMINACION { get; set; }
        internal ListFilter<String> V_DENOMINACIONs { get; set; }

        internal DateTimeFilter F_POSESION { get; set; }
        internal ListFilter<DateTime> F_POSESIONs { get; set; }

        internal DateTimeFilter F_INICIO { get; set; }
        internal ListFilter<DateTime> F_INICIOs { get; set; }

        internal StringFilter VID_PRIMER_NIVEL { get; set; }
        internal ListFilter<String> VID_PRIMER_NIVELs { get; set; }

        internal StringFilter VID_SEGUNDO_NIVEL { get; set; }
        internal ListFilter<String> VID_SEGUNDO_NIVELs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION_CARGO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_CARGO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_DECLARACION_CARGO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PUESTOs = new ListFilter<Int32>();
            V_DENOMINACIONs = new ListFilter<String>();
            F_POSESIONs = new ListFilter<DateTime>();
            F_INICIOs = new ListFilter<DateTime>();
            VID_PRIMER_NIVELs = new ListFilter<String>();
            VID_SEGUNDO_NIVELs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_CARGO
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION_CARGO in db.DECLARACION_CARGO
                    join qCAT_PUESTO in db.CAT_PUESTO on qDECLARACION_CARGO.NID_PUESTO
                                                  equals qCAT_PUESTO.NID_PUESTO
                    join qCAT_SEGUNDO_NIVEL in db.CAT_SEGUNDO_NIVEL on new { qDECLARACION_CARGO.VID_PRIMER_NIVEL, qDECLARACION_CARGO.VID_SEGUNDO_NIVEL }
                                                                equals new { qCAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL, qCAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL }
                    join qDECLARACION in db.DECLARACION on new { qDECLARACION_CARGO.VID_NOMBRE, qDECLARACION_CARGO.VID_FECHA, qDECLARACION_CARGO.VID_HOMOCLAVE, qDECLARACION_CARGO.NID_DECLARACION }
                                                    equals new { qDECLARACION.VID_NOMBRE, qDECLARACION.VID_FECHA, qDECLARACION.VID_HOMOCLAVE, qDECLARACION.NID_DECLARACION }
                    select new Declara_V2.MODELextended.DECLARACION_CARGO
                    {
                        VID_NOMBRE = qDECLARACION_CARGO.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_CARGO.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_CARGO.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_CARGO.NID_DECLARACION,
                        NID_PUESTO = qDECLARACION_CARGO.NID_PUESTO,
                        V_DENOMINACION = qDECLARACION_CARGO.V_DENOMINACION,
                        F_POSESION = qDECLARACION_CARGO.F_POSESION,
                        F_INICIO = qDECLARACION_CARGO.F_INICIO,
                        VID_PRIMER_NIVEL = qDECLARACION_CARGO.VID_PRIMER_NIVEL,
                        VID_SEGUNDO_NIVEL = qDECLARACION_CARGO.VID_SEGUNDO_NIVEL,
                        VID_PUESTO = qCAT_PUESTO.VID_PUESTO,
                        VID_NIVEL = qCAT_PUESTO.VID_NIVEL,
                        V_PUESTO = qCAT_PUESTO.V_PUESTO,
                        L_ACTIVO = qCAT_PUESTO.L_ACTIVO,
                        V_SEGUNDO_NIVEL = qCAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL,
                        C_EJERCICIO = qDECLARACION.C_EJERCICIO,
                        NID_TIPO_DECLARACION = qDECLARACION.NID_TIPO_DECLARACION,
                        NID_ESTADO = qDECLARACION.NID_ESTADO,
                        E_OBSERVACIONES = qDECLARACION.E_OBSERVACIONES,
                        E_OBSERVACIONES_MARCADO = qDECLARACION.E_OBSERVACIONES_MARCADO,
                        V_OBSERVACIONES_TESTADO = qDECLARACION.V_OBSERVACIONES_TESTADO,
                        NID_ESTADO_TESTADO = qDECLARACION.NID_ESTADO_TESTADO,
                        L_AUTORIZA_PUBLICAR = qDECLARACION.L_AUTORIZA_PUBLICAR,
                        F_REGISTRO = qDECLARACION.F_REGISTRO,
                        F_ENVIO = qDECLARACION.F_ENVIO,
                        L_CONFLICTO = qDECLARACION.L_CONFLICTO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PUESTOs.Count > 0) single_query =  (NID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PUESTOs.Contains(p.NID_PUESTO)) : single_query.Where(p => !NID_PUESTOs.Contains(p.NID_PUESTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(NID_PUESTO, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.NID_PUESTO.ToString(), single_query);

            if (V_DENOMINACIONs.Count > 0) single_query =  (V_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_DENOMINACIONs.Contains(p.V_DENOMINACION)) : single_query.Where(p => !V_DENOMINACIONs.Contains(p.V_DENOMINACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(V_DENOMINACION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.V_DENOMINACION.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(F_POSESION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.F_POSESION.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(F_INICIO, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.F_INICIO.ToString(), single_query);

            if (VID_PRIMER_NIVELs.Count > 0) single_query =  (VID_PRIMER_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL)) : single_query.Where(p => !VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(VID_PRIMER_NIVEL, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_PRIMER_NIVEL.ToString(), single_query);

            if (VID_SEGUNDO_NIVELs.Count > 0) single_query =  (VID_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL)) : single_query.Where(p => !VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_CARGO>(VID_SEGUNDO_NIVEL, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_SEGUNDO_NIVEL.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PUESTOs.Count > 0) query =  (NID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PUESTOs.Contains(p.NID_PUESTO)) : query.Where(p => !NID_PUESTOs.Contains(p.NID_PUESTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(NID_PUESTO, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.NID_PUESTO.ToString(), query);

            if (V_DENOMINACIONs.Count > 0) query =  (V_DENOMINACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_DENOMINACIONs.Contains(p.V_DENOMINACION)) : query.Where(p => !V_DENOMINACIONs.Contains(p.V_DENOMINACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(V_DENOMINACION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.V_DENOMINACION.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(F_POSESION, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.F_POSESION.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(F_INICIO, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.F_INICIO.ToString(), query);

            if (VID_PRIMER_NIVELs.Count > 0) query =  (VID_PRIMER_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL)) : query.Where(p => !VID_PRIMER_NIVELs.Contains(p.VID_PRIMER_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(VID_PRIMER_NIVEL, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_PRIMER_NIVEL.ToString(), query);

            if (VID_SEGUNDO_NIVELs.Count > 0) query =  (VID_SEGUNDO_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL)) : query.Where(p => !VID_SEGUNDO_NIVELs.Contains(p.VID_SEGUNDO_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_CARGO>(VID_SEGUNDO_NIVEL, Declara_V2.MODELextended.DECLARACION_CARGO.Properties.VID_SEGUNDO_NIVEL.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACION_CARGOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACION_CARGOs = new List<MODELDeclara_V2.DECLARACION_CARGO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_CARGOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_CARGOs = new List<Declara_V2.MODELextended.DECLARACION_CARGO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_CARGO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_CARGO> r;
                if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
                    r = query.OrderBy(OrderByCriterios[0].Field.ToString());
                else
                    r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
                for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
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
