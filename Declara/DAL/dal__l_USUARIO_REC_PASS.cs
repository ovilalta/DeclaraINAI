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
    internal class dal__l_USUARIO_REC_PASS : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.USUARIO_REC_PASS> lista_USUARIO_REC_PASSs { get; set; }
        internal List<MODELDeclara_V2.USUARIO_REC_PASS> base_USUARIO_REC_PASSs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal StringFilter V_CORREO { get; set; }
        internal ListFilter<String> V_CORREOs { get; set; }

        internal IntegerFilter N_USOS { get; set; }
        internal ListFilter<Int32> N_USOSs { get; set; }

        internal DateTimeFilter F_SOLICITUD { get; set; }
        internal ListFilter<DateTime> F_SOLICITUDs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.USUARIO_REC_PASS> query { get; set; }
        protected IQueryable<MODELDeclara_V2.USUARIO_REC_PASS> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_USUARIO_REC_PASS()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            V_CORREOs = new ListFilter<String>();
            N_USOSs = new ListFilter<Int32>();
            F_SOLICITUDs = new ListFilter<DateTime>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.USUARIO_REC_PASS
                           select p;
        }

        protected void Select()
        {

            query = from qUSUARIO_REC_PASS in db.USUARIO_REC_PASS
                    select new Declara_V2.MODELextended.USUARIO_REC_PASS
                    {
                        VID_NOMBRE = qUSUARIO_REC_PASS.VID_NOMBRE,
                        VID_FECHA = qUSUARIO_REC_PASS.VID_FECHA,
                        VID_HOMOCLAVE = qUSUARIO_REC_PASS.VID_HOMOCLAVE,
                        V_CORREO = qUSUARIO_REC_PASS.V_CORREO,
                        N_USOS = qUSUARIO_REC_PASS.N_USOS,
                        F_SOLICITUD = qUSUARIO_REC_PASS.F_SOLICITUD,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(VID_FECHA, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (V_CORREOs.Count > 0) single_query =  (V_CORREOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_CORREOs.Contains(p.V_CORREO)) : single_query.Where(p => !V_CORREOs.Contains(p.V_CORREO));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(V_CORREO, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.V_CORREO.ToString(), single_query);

            if (N_USOSs.Count > 0) single_query =  (N_USOSs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => N_USOSs.Contains(p.N_USOS)) : single_query.Where(p => !N_USOSs.Contains(p.N_USOS));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(N_USOS, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.N_USOS.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO_REC_PASS>(F_SOLICITUD, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.F_SOLICITUD.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(VID_FECHA, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.VID_HOMOCLAVE.ToString(), query);

            if (V_CORREOs.Count > 0) query =  (V_CORREOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_CORREOs.Contains(p.V_CORREO)) : query.Where(p => !V_CORREOs.Contains(p.V_CORREO));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(V_CORREO, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.V_CORREO.ToString(), query);

            if (N_USOSs.Count > 0) query =  (N_USOSs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => N_USOSs.Contains(p.N_USOS)) : query.Where(p => !N_USOSs.Contains(p.N_USOS));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(N_USOS, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.N_USOS.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO_REC_PASS>(F_SOLICITUD, Declara_V2.MODELextended.USUARIO_REC_PASS.Properties.F_SOLICITUD.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_USUARIO_REC_PASSs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_USUARIO_REC_PASSs = new List<MODELDeclara_V2.USUARIO_REC_PASS>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_USUARIO_REC_PASSs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_USUARIO_REC_PASSs = new List<Declara_V2.MODELextended.USUARIO_REC_PASS>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.USUARIO_REC_PASS> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.USUARIO_REC_PASS> r;
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
