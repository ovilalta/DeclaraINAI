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
    internal class dal__l_CAT_PUESTO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.CAT_PUESTO> lista_CAT_PUESTOs { get; set; }
        internal List<MODELDeclara_V2.CAT_PUESTO> base_CAT_PUESTOs { get; set; }


        internal IntegerFilter NID_PUESTO { get; set; }
        internal ListFilter<Int32> NID_PUESTOs { get; set; }

        internal StringFilter VID_PUESTO { get; set; }
        internal ListFilter<String> VID_PUESTOs { get; set; }

        internal StringFilter VID_NIVEL { get; set; }
        internal ListFilter<String> VID_NIVELs { get; set; }

        internal StringFilter V_PUESTO { get; set; }
        internal ListFilter<String> V_PUESTOs { get; set; }

        internal StringFilter NOMBRE_UA { get; set; }
        internal ListFilter<String> NOMBRE_UAs { get; set; }


        internal System.Nullable<Boolean> L_ACTIVO { get; set; }
        internal ListFilter<Boolean> L_ACTIVOs { get; set; }

        internal System.Nullable<Boolean> L_OBLIGADO { get; set; }
        internal ListFilter<Boolean> L_OBLIGADOs { get; set; }

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


        protected IQueryable<Declara_V2.MODELextended.CAT_PUESTO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.CAT_PUESTO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_CAT_PUESTO()
        {
            NID_PUESTOs = new ListFilter<Int32>();
            VID_PUESTOs = new ListFilter<String>();
            VID_NIVELs = new ListFilter<String>();
            V_PUESTOs = new ListFilter<String>();
            L_ACTIVOs = new ListFilter<Boolean>();
            L_OBLIGADOs = new ListFilter<Boolean>();
            NOMBRE_UAs = new ListFilter<String>();
            
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.CAT_PUESTO
                           select p;
        }

        protected void Select()
        {

            query = from qCAT_PUESTO in db.CAT_PUESTO
                    select new Declara_V2.MODELextended.CAT_PUESTO
                    {
                        NID_PUESTO = qCAT_PUESTO.NID_PUESTO,
                        VID_PUESTO = qCAT_PUESTO.VID_PUESTO,
                        VID_NIVEL = qCAT_PUESTO.VID_NIVEL,
                        V_PUESTO = qCAT_PUESTO.V_PUESTO,
                        L_ACTIVO = qCAT_PUESTO.L_ACTIVO,
                        L_OBLIGADO = qCAT_PUESTO.L_OBLIGADO,
                        NOMBRE_UA = qCAT_PUESTO.NOMBRE_UA,
                    };
        }

        protected void Single_Where()
        {
            if (NID_PUESTOs.Count > 0) single_query =  (NID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PUESTOs.Contains(p.NID_PUESTO)) : single_query.Where(p => !NID_PUESTOs.Contains(p.NID_PUESTO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.CAT_PUESTO>(NID_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.NID_PUESTO.ToString(), single_query);

            if (VID_PUESTOs.Count > 0) single_query =  (VID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_PUESTOs.Contains(p.VID_PUESTO)) : single_query.Where(p => !VID_PUESTOs.Contains(p.VID_PUESTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PUESTO>(VID_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.VID_PUESTO.ToString(), single_query);

            if (VID_NIVELs.Count > 0) single_query =  (VID_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NIVELs.Contains(p.VID_NIVEL)) : single_query.Where(p => !VID_NIVELs.Contains(p.VID_NIVEL));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PUESTO>(VID_NIVEL, Declara_V2.MODELextended.CAT_PUESTO.Properties.VID_NIVEL.ToString(), single_query);

            if (V_PUESTOs.Count > 0) single_query =  (V_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_PUESTOs.Contains(p.V_PUESTO)) : single_query.Where(p => !V_PUESTOs.Contains(p.V_PUESTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PUESTO>(V_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.V_PUESTO.ToString(), single_query);

            if (NOMBRE_UAs.Count > 0) single_query = (NOMBRE_UAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NOMBRE_UAs.Contains(p.NOMBRE_UA)) : single_query.Where(p => !NOMBRE_UAs.Contains(p.NOMBRE_UA));
            single_query = StringFilterBuilder<MODELDeclara_V2.CAT_PUESTO>(NOMBRE_UA, Declara_V2.MODELextended.CAT_PUESTO.Properties.NOMBRE_UA.ToString(), single_query);

            if (L_ACTIVO.HasValue) single_query = single_query.Where<MODELDeclara_V2.CAT_PUESTO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Where()
        {
            if (NID_PUESTOs.Count > 0) query =  (NID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PUESTOs.Contains(p.NID_PUESTO)) : query.Where(p => !NID_PUESTOs.Contains(p.NID_PUESTO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.CAT_PUESTO>(NID_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.NID_PUESTO.ToString(), query);

            if (VID_PUESTOs.Count > 0) query =  (VID_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_PUESTOs.Contains(p.VID_PUESTO)) : query.Where(p => !VID_PUESTOs.Contains(p.VID_PUESTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PUESTO>(VID_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.VID_PUESTO.ToString(), query);

            if (VID_NIVELs.Count > 0) query =  (VID_NIVELs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NIVELs.Contains(p.VID_NIVEL)) : query.Where(p => !VID_NIVELs.Contains(p.VID_NIVEL));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PUESTO>(VID_NIVEL, Declara_V2.MODELextended.CAT_PUESTO.Properties.VID_NIVEL.ToString(), query);

            if (V_PUESTOs.Count > 0) query =  (V_PUESTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_PUESTOs.Contains(p.V_PUESTO)) : query.Where(p => !V_PUESTOs.Contains(p.V_PUESTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PUESTO>(V_PUESTO, Declara_V2.MODELextended.CAT_PUESTO.Properties.V_PUESTO.ToString(), query);

            if (NOMBRE_UAs.Count > 0) query = (NOMBRE_UAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NOMBRE_UAs.Contains(p.NOMBRE_UA)) : query.Where(p => !NOMBRE_UAs.Contains(p.NOMBRE_UA));
            query = StringFilterBuilder<Declara_V2.MODELextended.CAT_PUESTO>(NOMBRE_UA, Declara_V2.MODELextended.CAT_PUESTO.Properties.NOMBRE_UA.ToString(), query);

            if (L_ACTIVO.HasValue) query = query.Where<Declara_V2.MODELextended.CAT_PUESTO>(p => p.L_ACTIVO == L_ACTIVO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_CAT_PUESTOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_CAT_PUESTOs = new List<MODELDeclara_V2.CAT_PUESTO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_CAT_PUESTOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_CAT_PUESTOs = new List<Declara_V2.MODELextended.CAT_PUESTO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.CAT_PUESTO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.CAT_PUESTO> r;
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
