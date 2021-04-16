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
    internal class dal__l_CAT_CONFLICTO_PREGUNTA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA> lista_CAT_CONFLICTO_PREGUNTAs { get; set; }
        internal List<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA> base_CAT_CONFLICTO_PREGUNTAs { get; set; }


        internal IntegerFilter NID_RUBRO { get; set; }
        internal ListFilter<Int32> NID_RUBROs { get; set; }

        internal IntegerFilter NID_PREGUNTA { get; set; }
        internal ListFilter<Int32> NID_PREGUNTAs { get; set; }

        internal StringFilter V_RUBRO { get; set; }
        internal ListFilter<String> V_RUBROs { get; set; }

        internal StringFilter V_OPCIONES { get; set; }
        internal ListFilter<String> V_OPCIONESs { get; set; }

        internal StringFilter C_INICIO { get; set; }
        internal ListFilter<String> C_INICIOs { get; set; }

        internal StringFilter C_FIN { get; set; }
        internal ListFilter<String> C_FINs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_CONFLICTO_PREGUNTA()
        {
            NID_RUBROs = new ListFilter<Int32>();
            NID_PREGUNTAs = new ListFilter<Int32>();
            V_RUBROs = new ListFilter<String>();
            V_OPCIONESs = new ListFilter<String>();
            C_INICIOs = new ListFilter<String>();
            C_FINs = new ListFilter<String>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_CONFLICTO_PREGUNTA
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_CONFLICTO_PREGUNTA in db.CAT_CONFLICTO_PREGUNTA
                    join qCAT_CONFLICTO_RUBRO in db.CAT_CONFLICTO_RUBRO on qCAT_CONFLICTO_PREGUNTA.NID_RUBRO
                                                                    equals qCAT_CONFLICTO_RUBRO.NID_RUBRO
                    select new Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA
                    {
                        NID_RUBRO = qCAT_CONFLICTO_PREGUNTA.NID_RUBRO,
                        NID_PREGUNTA = qCAT_CONFLICTO_PREGUNTA.NID_PREGUNTA,
                        V_RUBRO = qCAT_CONFLICTO_PREGUNTA.V_RUBRO,
                        V_OPCIONES = qCAT_CONFLICTO_PREGUNTA.V_OPCIONES,
                        C_INICIO = qCAT_CONFLICTO_PREGUNTA.C_INICIO,
                        C_FIN = qCAT_CONFLICTO_PREGUNTA.C_FIN,
                    };
        }

        protected void Single_Where()
        {
            if (NID_RUBROs.Count > 0) single_query =  (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_RUBROs.Contains(p.NID_RUBRO)) : single_query.Where(p => !NID_RUBROs.Contains(p.NID_RUBRO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(NID_RUBRO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.NID_RUBRO.ToString(), single_query);

            if (NID_PREGUNTAs.Count > 0) single_query =  (NID_PREGUNTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PREGUNTAs.Contains(p.NID_PREGUNTA)) : single_query.Where(p => !NID_PREGUNTAs.Contains(p.NID_PREGUNTA));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(NID_PREGUNTA, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.NID_PREGUNTA.ToString(), single_query);

            if (V_RUBROs.Count > 0) single_query =  (V_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_RUBROs.Contains(p.V_RUBRO)) : single_query.Where(p => !V_RUBROs.Contains(p.V_RUBRO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(V_RUBRO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.V_RUBRO.ToString(), single_query);

            if (V_OPCIONESs.Count > 0) single_query =  (V_OPCIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_OPCIONESs.Contains(p.V_OPCIONES)) : single_query.Where(p => !V_OPCIONESs.Contains(p.V_OPCIONES));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(V_OPCIONES, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.V_OPCIONES.ToString(), single_query);

            if (C_INICIOs.Count > 0) single_query =  (C_INICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_INICIOs.Contains(p.C_INICIO)) : single_query.Where(p => !C_INICIOs.Contains(p.C_INICIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(C_INICIO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.C_INICIO.ToString(), single_query);

            if (C_FINs.Count > 0) single_query =  (C_FINs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => C_FINs.Contains(p.C_FIN)) : single_query.Where(p => !C_FINs.Contains(p.C_FIN));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>(C_FIN, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.C_FIN.ToString(), single_query);

        }

        protected void Where()
        {
            if (NID_RUBROs.Count > 0) query =  (NID_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_RUBROs.Contains(p.NID_RUBRO)) : query.Where(p => !NID_RUBROs.Contains(p.NID_RUBRO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(NID_RUBRO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.NID_RUBRO.ToString(), query);

            if (NID_PREGUNTAs.Count > 0) query =  (NID_PREGUNTAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PREGUNTAs.Contains(p.NID_PREGUNTA)) : query.Where(p => !NID_PREGUNTAs.Contains(p.NID_PREGUNTA));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(NID_PREGUNTA, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.NID_PREGUNTA.ToString(), query);

            if (V_RUBROs.Count > 0) query =  (V_RUBROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_RUBROs.Contains(p.V_RUBRO)) : query.Where(p => !V_RUBROs.Contains(p.V_RUBRO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(V_RUBRO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.V_RUBRO.ToString(), query);

            if (V_OPCIONESs.Count > 0) query =  (V_OPCIONESs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_OPCIONESs.Contains(p.V_OPCIONES)) : query.Where(p => !V_OPCIONESs.Contains(p.V_OPCIONES));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(V_OPCIONES, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.V_OPCIONES.ToString(), query);

            if (C_INICIOs.Count > 0) query =  (C_INICIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_INICIOs.Contains(p.C_INICIO)) : query.Where(p => !C_INICIOs.Contains(p.C_INICIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(C_INICIO, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.C_INICIO.ToString(), query);

            if (C_FINs.Count > 0) query =  (C_FINs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => C_FINs.Contains(p.C_FIN)) : query.Where(p => !C_FINs.Contains(p.C_FIN));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>(C_FIN, Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA.Properties.C_FIN.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_CONFLICTO_PREGUNTAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_CONFLICTO_PREGUNTAs = new List<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_CONFLICTO_PREGUNTAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_CONFLICTO_PREGUNTAs = new List<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_CONFLICTO_PREGUNTA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_CONFLICTO_PREGUNTA> r;
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
