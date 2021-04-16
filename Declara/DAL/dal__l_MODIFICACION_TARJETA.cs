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
    internal class dal__l_MODIFICACION_TARJETA : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_TARJETA> lista_MODIFICACION_TARJETAs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_TARJETA> base_MODIFICACION_TARJETAs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal StringFilter E_NUMERO { get; set; }
        internal ListFilter<String> E_NUMEROs { get; set; }

        internal IntegerFilter NID_INSTITUCION { get; set; }
        internal ListFilter<Int32> NID_INSTITUCIONs { get; set; }

        internal StringFilter V_NUMERO_CORTO { get; set; }
        internal ListFilter<String> V_NUMERO_CORTOs { get; set; }

        internal DecimalFilter M_PAGOS { get; set; }
        internal ListFilter<Decimal> M_PAGOSs { get; set; }

        internal DecimalFilter M_SALDO { get; set; }
        internal ListFilter<Decimal> M_SALDOs { get; set; }

        internal StringFilter E_NUMERO_ASOCIACION { get; set; }
        internal ListFilter<String> E_NUMERO_ASOCIACIONs { get; set; }

        internal System.Nullable<Boolean> L_ACTIVA { get; set; }
        internal ListFilter<Boolean> L_ACTIVAs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_TARJETA> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_TARJETA> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_TARJETA()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            E_NUMEROs = new ListFilter<String>();
            NID_INSTITUCIONs = new ListFilter<Int32>();
            V_NUMERO_CORTOs = new ListFilter<String>();
            M_PAGOSs = new ListFilter<Decimal>();
            M_SALDOs = new ListFilter<Decimal>();
            E_NUMERO_ASOCIACIONs = new ListFilter<String>();
            L_ACTIVAs = new ListFilter<Boolean>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_TARJETA
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_TARJETA in db.MODIFICACION_TARJETA
                    join qCAT_INST_FINANCIERA in db.CAT_INST_FINANCIERA on qMODIFICACION_TARJETA.NID_INSTITUCION
                                                                    equals qCAT_INST_FINANCIERA.NID_INSTITUCION
                    select new Declara_V2.MODELextended.MODIFICACION_TARJETA
                    {
                        VID_NOMBRE = qMODIFICACION_TARJETA.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_TARJETA.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_TARJETA.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_TARJETA.NID_DECLARACION,
                        E_NUMERO = qMODIFICACION_TARJETA.E_NUMERO,
                        NID_INSTITUCION = qMODIFICACION_TARJETA.NID_INSTITUCION,
                        V_NUMERO_CORTO = qMODIFICACION_TARJETA.V_NUMERO_CORTO,
                        M_PAGOS = qMODIFICACION_TARJETA.M_PAGOS,
                        M_SALDO = qMODIFICACION_TARJETA.M_SALDO,
                        E_NUMERO_ASOCIACION = qMODIFICACION_TARJETA.E_NUMERO_ASOCIACION,
                        L_ACTIVA = qMODIFICACION_TARJETA.L_ACTIVA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.NID_DECLARACION.ToString(), single_query);

            if (E_NUMEROs.Count > 0) single_query =  (E_NUMEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NUMEROs.Contains(p.E_NUMERO)) : single_query.Where(p => !E_NUMEROs.Contains(p.E_NUMERO));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(E_NUMERO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.E_NUMERO.ToString(), single_query);

            if (NID_INSTITUCIONs.Count > 0) single_query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : single_query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(NID_INSTITUCION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.NID_INSTITUCION.ToString(), single_query);

            if (V_NUMERO_CORTOs.Count > 0) single_query =  (V_NUMERO_CORTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => V_NUMERO_CORTOs.Contains(p.V_NUMERO_CORTO)) : single_query.Where(p => !V_NUMERO_CORTOs.Contains(p.V_NUMERO_CORTO));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(V_NUMERO_CORTO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.V_NUMERO_CORTO.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(M_PAGOS, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.M_PAGOS.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(M_SALDO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.M_SALDO.ToString(), single_query);

            if (E_NUMERO_ASOCIACIONs.Count > 0) single_query =  (E_NUMERO_ASOCIACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NUMERO_ASOCIACIONs.Contains(p.E_NUMERO_ASOCIACION)) : single_query.Where(p => !E_NUMERO_ASOCIACIONs.Contains(p.E_NUMERO_ASOCIACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_TARJETA>(E_NUMERO_ASOCIACION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.E_NUMERO_ASOCIACION.ToString(), single_query);

            if (L_ACTIVA.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_TARJETA>(p => p.L_ACTIVA == L_ACTIVA );

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.NID_DECLARACION.ToString(), query);

            if (E_NUMEROs.Count > 0) query =  (E_NUMEROs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NUMEROs.Contains(p.E_NUMERO)) : query.Where(p => !E_NUMEROs.Contains(p.E_NUMERO));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(E_NUMERO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.E_NUMERO.ToString(), query);

            if (NID_INSTITUCIONs.Count > 0) query =  (NID_INSTITUCIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_INSTITUCIONs.Contains(p.NID_INSTITUCION)) : query.Where(p => !NID_INSTITUCIONs.Contains(p.NID_INSTITUCION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(NID_INSTITUCION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.NID_INSTITUCION.ToString(), query);

            if (V_NUMERO_CORTOs.Count > 0) query =  (V_NUMERO_CORTOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => V_NUMERO_CORTOs.Contains(p.V_NUMERO_CORTO)) : query.Where(p => !V_NUMERO_CORTOs.Contains(p.V_NUMERO_CORTO));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(V_NUMERO_CORTO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.V_NUMERO_CORTO.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(M_PAGOS, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.M_PAGOS.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(M_SALDO, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.M_SALDO.ToString(), query);

            if (E_NUMERO_ASOCIACIONs.Count > 0) query =  (E_NUMERO_ASOCIACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NUMERO_ASOCIACIONs.Contains(p.E_NUMERO_ASOCIACION)) : query.Where(p => !E_NUMERO_ASOCIACIONs.Contains(p.E_NUMERO_ASOCIACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_TARJETA>(E_NUMERO_ASOCIACION, Declara_V2.MODELextended.MODIFICACION_TARJETA.Properties.E_NUMERO_ASOCIACION.ToString(), query);

            if (L_ACTIVA.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_TARJETA>(p => p.L_ACTIVA == L_ACTIVA );

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_TARJETAs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_TARJETAs = new List<MODELDeclara_V2.MODIFICACION_TARJETA>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_TARJETAs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_TARJETAs = new List<Declara_V2.MODELextended.MODIFICACION_TARJETA>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_TARJETA> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_TARJETA> r;
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
