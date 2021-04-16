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
    internal class dal__l_USUARIO_SESION : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.USUARIO_SESION> lista_USUARIO_SESIONs { get; set; }
        internal List<MODELDeclara_V2.USUARIO_SESION> base_USUARIO_SESIONs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_SESION { get; set; }
        internal ListFilter<Int32> NID_SESIONs { get; set; }

        internal StringFilter V_IP { get; set; }
        internal ListFilter<String> V_IPs { get; set; }

        internal StringFilter V_MAQUINA_USUARIO { get; set; }
        internal ListFilter<String> V_MAQUINA_USUARIOs { get; set; }

        internal DateTimeFilter F_INICIO { get; set; }
        internal ListFilter<DateTime> F_INICIOs { get; set; }

        internal DateTimeFilter F_FIN { get; set; }
        internal ListFilter<DateTime> F_FINs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.USUARIO_SESION> query { get; set; }
        protected IQueryable<MODELDeclara_V2.USUARIO_SESION> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_USUARIO_SESION()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_SESIONs = new ListFilter<Int32>();
            V_IPs = new ListFilter<String>();
            V_MAQUINA_USUARIOs = new ListFilter<String>();
            F_INICIOs = new ListFilter<DateTime>();
            F_FINs = new ListFilter<DateTime>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.USUARIO_SESION
                           select p;
        }

        protected void Select()
        {

            query = from qUSUARIO_SESION in db.USUARIO_SESION
                    select new Declara_V2.MODELextended.USUARIO_SESION
                    {
                        VID_NOMBRE = qUSUARIO_SESION.VID_NOMBRE,
                        VID_FECHA = qUSUARIO_SESION.VID_FECHA,
                        VID_HOMOCLAVE = qUSUARIO_SESION.VID_HOMOCLAVE,
                        NID_SESION = qUSUARIO_SESION.NID_SESION,
                        V_IP = qUSUARIO_SESION.V_IP,
                        V_MAQUINA_USUARIO = qUSUARIO_SESION.V_MAQUINA_USUARIO,
                        F_INICIO = qUSUARIO_SESION.F_INICIO,
                        F_FIN = qUSUARIO_SESION.F_FIN,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(VID_FECHA, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_SESIONs.Count > 0) single_query =  (NID_SESIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_SESIONs.Contains(p.NID_SESION)) : single_query.Where(p => !NID_SESIONs.Contains(p.NID_SESION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(NID_SESION, Declara_V2.MODELextended.USUARIO_SESION.Properties.NID_SESION.ToString(), single_query);

            if (V_IPs.Count > 0) single_query =  (V_IPs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_IPs.Contains(p.V_IP)) : single_query.Where(p => !V_IPs.Contains(p.V_IP));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(V_IP, Declara_V2.MODELextended.USUARIO_SESION.Properties.V_IP.ToString(), single_query);

            if (V_MAQUINA_USUARIOs.Count > 0) single_query =  (V_MAQUINA_USUARIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_MAQUINA_USUARIOs.Contains(p.V_MAQUINA_USUARIO)) : single_query.Where(p => !V_MAQUINA_USUARIOs.Contains(p.V_MAQUINA_USUARIO));
            single_query = StringFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(V_MAQUINA_USUARIO, Declara_V2.MODELextended.USUARIO_SESION.Properties.V_MAQUINA_USUARIO.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(F_INICIO, Declara_V2.MODELextended.USUARIO_SESION.Properties.F_INICIO.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.USUARIO_SESION>(F_FIN, Declara_V2.MODELextended.USUARIO_SESION.Properties.F_FIN.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(VID_NOMBRE, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(VID_FECHA, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(VID_HOMOCLAVE, Declara_V2.MODELextended.USUARIO_SESION.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_SESIONs.Count > 0) query =  (NID_SESIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_SESIONs.Contains(p.NID_SESION)) : query.Where(p => !NID_SESIONs.Contains(p.NID_SESION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(NID_SESION, Declara_V2.MODELextended.USUARIO_SESION.Properties.NID_SESION.ToString(), query);

            if (V_IPs.Count > 0) query =  (V_IPs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_IPs.Contains(p.V_IP)) : query.Where(p => !V_IPs.Contains(p.V_IP));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(V_IP, Declara_V2.MODELextended.USUARIO_SESION.Properties.V_IP.ToString(), query);

            if (V_MAQUINA_USUARIOs.Count > 0) query =  (V_MAQUINA_USUARIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_MAQUINA_USUARIOs.Contains(p.V_MAQUINA_USUARIO)) : query.Where(p => !V_MAQUINA_USUARIOs.Contains(p.V_MAQUINA_USUARIO));
            query = StringFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(V_MAQUINA_USUARIO, Declara_V2.MODELextended.USUARIO_SESION.Properties.V_MAQUINA_USUARIO.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(F_INICIO, Declara_V2.MODELextended.USUARIO_SESION.Properties.F_INICIO.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.USUARIO_SESION>(F_FIN, Declara_V2.MODELextended.USUARIO_SESION.Properties.F_FIN.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_USUARIO_SESIONs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_USUARIO_SESIONs = new List<MODELDeclara_V2.USUARIO_SESION>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_USUARIO_SESIONs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_USUARIO_SESIONs = new List<Declara_V2.MODELextended.USUARIO_SESION>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.USUARIO_SESION> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.USUARIO_SESION> r;
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
