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
    internal class dal__l_DECLARACION_APARTADO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.DECLARACION_APARTADO> lista_DECLARACION_APARTADOs { get; set; }
        internal List<MODELDeclara_V2.DECLARACION_APARTADO> base_DECLARACION_APARTADOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_APARTADO { get; set; }
        internal ListFilter<Int32> NID_APARTADOs { get; set; }

        internal System.Nullable<Boolean> L_ESTADO { get; set; }
        internal ListFilter<Boolean> L_ESTADOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.DECLARACION_APARTADO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.DECLARACION_APARTADO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_DECLARACION_APARTADO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_APARTADOs = new ListFilter<Int32>();
            L_ESTADOs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.DECLARACION_APARTADO
                           select p;
        }

        protected void Select()
        {

            query = from qDECLARACION_APARTADO in db.DECLARACION_APARTADO
                    join qCAT_APARTADO in db.CAT_APARTADO on qDECLARACION_APARTADO.NID_APARTADO
                                                      equals qCAT_APARTADO.NID_APARTADO
                    select new Declara_V2.MODELextended.DECLARACION_APARTADO
                    {
                        VID_NOMBRE = qDECLARACION_APARTADO.VID_NOMBRE,
                        VID_FECHA = qDECLARACION_APARTADO.VID_FECHA,
                        VID_HOMOCLAVE = qDECLARACION_APARTADO.VID_HOMOCLAVE,
                        NID_DECLARACION = qDECLARACION_APARTADO.NID_DECLARACION,
                        NID_APARTADO = qDECLARACION_APARTADO.NID_APARTADO,
                        L_ESTADO = qDECLARACION_APARTADO.L_ESTADO,
                        V_APARTADO = qCAT_APARTADO.V_APARTADO,
                        NID_APARTADO_SUPERIOR = qCAT_APARTADO.NID_APARTADO_SUPERIOR,
                        N_APARTADO = qCAT_APARTADO.N_APARTADO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_APARTADO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_APARTADO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.DECLARACION_APARTADO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_APARTADO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_APARTADOs.Count > 0) single_query =  (NID_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_APARTADOs.Contains(p.NID_APARTADO)) : single_query.Where(p => !NID_APARTADOs.Contains(p.NID_APARTADO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.DECLARACION_APARTADO>(NID_APARTADO, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.NID_APARTADO.ToString(), single_query);

            if (L_ESTADO.HasValue) single_query = single_query.Where<MODELDeclara_V2.DECLARACION_APARTADO>(p => p.L_ESTADO == L_ESTADO );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_APARTADO>(VID_NOMBRE, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_APARTADO>(VID_FECHA, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.DECLARACION_APARTADO>(VID_HOMOCLAVE, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_APARTADO>(NID_DECLARACION, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_APARTADOs.Count > 0) query =  (NID_APARTADOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_APARTADOs.Contains(p.NID_APARTADO)) : query.Where(p => !NID_APARTADOs.Contains(p.NID_APARTADO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.DECLARACION_APARTADO>(NID_APARTADO, Declara_V2.MODELextended.DECLARACION_APARTADO.Properties.NID_APARTADO.ToString(), query);

            if (L_ESTADO.HasValue) query = query.Where<Declara_V2.MODELextended.DECLARACION_APARTADO>(p => p.L_ESTADO == L_ESTADO );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_DECLARACION_APARTADOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_DECLARACION_APARTADOs = new List<MODELDeclara_V2.DECLARACION_APARTADO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_DECLARACION_APARTADOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_DECLARACION_APARTADOs = new List<Declara_V2.MODELextended.DECLARACION_APARTADO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.DECLARACION_APARTADO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.DECLARACION_APARTADO> r;
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
