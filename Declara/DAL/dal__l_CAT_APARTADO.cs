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
    internal class dal__l_CAT_APARTADO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_APARTADO> lista_CAT_APARTADOs { get; set; }
        internal List<MODELDeclara_V2.CAT_APARTADO> base_CAT_APARTADOs { get; set; }


        internal IntegerFilter NID_APARTADO { get; set; }
        internal ListFilter<Int32> NID_APARTADOs { get; set; }

        internal StringFilter V_APARTADO { get; set; }
        internal ListFilter<String> V_APARTADOs { get; set; }

        internal IntegerFilter NID_APARTADO_SUPERIOR { get; set; }
        internal ListFilter<Int32> NID_APARTADO_SUPERIORs { get; set; }

        internal IntegerFilter N_APARTADO { get; set; }
        internal ListFilter<Int32> N_APARTADOs { get; set; }

        internal IntegerFilter NID_TIPO_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_TIPO_DECLARACIONs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_APARTADO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_APARTADO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_APARTADO()
        {
            NID_APARTADOs = new ListFilter<Int32>();
            V_APARTADOs = new ListFilter<String>();
            NID_APARTADO_SUPERIORs = new ListFilter<Int32>();
            N_APARTADOs = new ListFilter<Int32>();
            NID_TIPO_DECLARACIONs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_APARTADO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_APARTADO in db.CAT_APARTADO
                    select new Declara_V2.MODELextended.CAT_APARTADO
                    {
                        NID_APARTADO = qCAT_APARTADO.NID_APARTADO,
                        V_APARTADO = qCAT_APARTADO.V_APARTADO,
                        NID_APARTADO_SUPERIOR = qCAT_APARTADO.NID_APARTADO_SUPERIOR,
                        N_APARTADO = qCAT_APARTADO.N_APARTADO,
                        NID_TIPO_DECLARACION = qCAT_APARTADO.NID_TIPO_DECLARACION,
                    };
        }

        protected void Single_Where()
        {
            if (NID_APARTADOs.Count > 0) single_query =  (NID_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_APARTADOs.Contains(p.NID_APARTADO)) : single_query.Where(p => !NID_APARTADOs.Contains(p.NID_APARTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_APARTADO>(NID_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.NID_APARTADO.ToString(), single_query);

            if (V_APARTADOs.Count > 0) single_query =  (V_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_APARTADOs.Contains(p.V_APARTADO)) : single_query.Where(p => !V_APARTADOs.Contains(p.V_APARTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_APARTADO>(V_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.V_APARTADO.ToString(), single_query);

            if (NID_APARTADO_SUPERIORs.Count > 0) single_query =  (NID_APARTADO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_APARTADO_SUPERIORs.Contains(p.NID_APARTADO_SUPERIOR.Value)) : single_query.Where(p => !NID_APARTADO_SUPERIORs.Contains(p.NID_APARTADO_SUPERIOR.Value));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_APARTADO>(NID_APARTADO_SUPERIOR, Declara_V2.MODELextended.CAT_APARTADO.Properties.NID_APARTADO_SUPERIOR.ToString(), single_query);

            if (N_APARTADOs.Count > 0) single_query =  (N_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => N_APARTADOs.Contains(p.N_APARTADO.Value)) : single_query.Where(p => !N_APARTADOs.Contains(p.N_APARTADO.Value));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_APARTADO>(N_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.N_APARTADO.ToString(), single_query);


        }

        protected void Where()
        {
            if (NID_APARTADOs.Count > 0) query =  (NID_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_APARTADOs.Contains(p.NID_APARTADO)) : query.Where(p => !NID_APARTADOs.Contains(p.NID_APARTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_APARTADO>(NID_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.NID_APARTADO.ToString(), query);

            if (V_APARTADOs.Count > 0) query =  (V_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_APARTADOs.Contains(p.V_APARTADO)) : query.Where(p => !V_APARTADOs.Contains(p.V_APARTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_APARTADO>(V_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.V_APARTADO.ToString(), query);

            if (NID_APARTADO_SUPERIORs.Count > 0) query =  (NID_APARTADO_SUPERIORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_APARTADO_SUPERIORs.Contains(p.NID_APARTADO_SUPERIOR.Value)) : query.Where(p => !NID_APARTADO_SUPERIORs.Contains(p.NID_APARTADO_SUPERIOR.Value));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_APARTADO>(NID_APARTADO_SUPERIOR, Declara_V2.MODELextended.CAT_APARTADO.Properties.NID_APARTADO_SUPERIOR.ToString(), query);

            if (N_APARTADOs.Count > 0) query =  (N_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => N_APARTADOs.Contains(p.N_APARTADO.Value)) : query.Where(p => !N_APARTADOs.Contains(p.N_APARTADO.Value));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_APARTADO>(N_APARTADO, Declara_V2.MODELextended.CAT_APARTADO.Properties.N_APARTADO.ToString(), query);


        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_APARTADOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_APARTADOs = new List<MODELDeclara_V2.CAT_APARTADO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_APARTADOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_APARTADOs = new List<Declara_V2.MODELextended.CAT_APARTADO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_APARTADO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_APARTADO> r;
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
