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
    internal class dal__l_CAT_ESTADO_TESTADO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_ESTADO_TESTADO> lista_CAT_ESTADO_TESTADOs { get; set; }
        internal List<MODELDeclara_V2.CAT_ESTADO_TESTADO> base_CAT_ESTADO_TESTADOs { get; set; }


        internal IntegerFilter NID_ESTADO_TESTADO { get; set; }
        internal ListFilter<Int32> NID_ESTADO_TESTADOs { get; set; }

        internal StringFilter V_ESTADO_TESTADO { get; set; }
        internal ListFilter<String> V_ESTADO_TESTADOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_ESTADO_TESTADO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_ESTADO_TESTADO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_ESTADO_TESTADO()
        {
            NID_ESTADO_TESTADOs = new ListFilter<Int32>();
            V_ESTADO_TESTADOs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_ESTADO_TESTADO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_ESTADO_TESTADO in db.CAT_ESTADO_TESTADO
                    select new Declara_V2.MODELextended.CAT_ESTADO_TESTADO
                    {
                        NID_ESTADO_TESTADO = qCAT_ESTADO_TESTADO.NID_ESTADO_TESTADO,
                        V_ESTADO_TESTADO = qCAT_ESTADO_TESTADO.V_ESTADO_TESTADO,
                    };
        }

        protected void Single_Where()
        {
            if (NID_ESTADO_TESTADOs.Count > 0) single_query =  (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO)) : single_query.Where(p => !NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_ESTADO_TESTADO>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.CAT_ESTADO_TESTADO.Properties.NID_ESTADO_TESTADO.ToString(), single_query);

            if (V_ESTADO_TESTADOs.Count > 0) single_query =  (V_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_ESTADO_TESTADOs.Contains(p.V_ESTADO_TESTADO)) : single_query.Where(p => !V_ESTADO_TESTADOs.Contains(p.V_ESTADO_TESTADO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_ESTADO_TESTADO>(V_ESTADO_TESTADO, Declara_V2.MODELextended.CAT_ESTADO_TESTADO.Properties.V_ESTADO_TESTADO.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_ESTADO_TESTADOs.Count > 0) query =  (NID_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO)) : query.Where(p => !NID_ESTADO_TESTADOs.Contains(p.NID_ESTADO_TESTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_TESTADO>(NID_ESTADO_TESTADO, Declara_V2.MODELextended.CAT_ESTADO_TESTADO.Properties.NID_ESTADO_TESTADO.ToString(), query);

            if (V_ESTADO_TESTADOs.Count > 0) query =  (V_ESTADO_TESTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_ESTADO_TESTADOs.Contains(p.V_ESTADO_TESTADO)) : query.Where(p => !V_ESTADO_TESTADOs.Contains(p.V_ESTADO_TESTADO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_ESTADO_TESTADO>(V_ESTADO_TESTADO, Declara_V2.MODELextended.CAT_ESTADO_TESTADO.Properties.V_ESTADO_TESTADO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_ESTADO_TESTADOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_ESTADO_TESTADOs = new List<MODELDeclara_V2.CAT_ESTADO_TESTADO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_ESTADO_TESTADOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_ESTADO_TESTADOs = new List<Declara_V2.MODELextended.CAT_ESTADO_TESTADO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_ESTADO_TESTADO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_ESTADO_TESTADO> r;
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
