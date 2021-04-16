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
    internal class dal__l_MODIFICACION_BAJA_SINIESTRO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO> lista_MODIFICACION_BAJA_SINIESTROs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO> base_MODIFICACION_BAJA_SINIESTROs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal System.Nullable<Boolean> L_POLIZA { get; set; }
        internal ListFilter<Boolean> L_POLIZAs { get; set; }

        internal DecimalFilter M_RECUPERADO { get; set; }
        internal ListFilter<Decimal> M_RECUPERADOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_BAJA_SINIESTRO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            L_POLIZAs = new ListFilter<Boolean>();
            M_RECUPERADOs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_BAJA_SINIESTRO
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_BAJA_SINIESTRO in db.MODIFICACION_BAJA_SINIESTRO
                    join qMODIFICACION_BAJA in db.MODIFICACION_BAJA on new { qMODIFICACION_BAJA_SINIESTRO.VID_NOMBRE, qMODIFICACION_BAJA_SINIESTRO.VID_FECHA, qMODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE, qMODIFICACION_BAJA_SINIESTRO.NID_DECLARACION, qMODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO }
                                                                equals new { qMODIFICACION_BAJA.VID_NOMBRE, qMODIFICACION_BAJA.VID_FECHA, qMODIFICACION_BAJA.VID_HOMOCLAVE, qMODIFICACION_BAJA.NID_DECLARACION, qMODIFICACION_BAJA.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO
                    {
                        VID_NOMBRE = qMODIFICACION_BAJA_SINIESTRO.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_BAJA_SINIESTRO.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_BAJA_SINIESTRO.NID_DECLARACION,
                        NID_PATRIMONIO = qMODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO,
                        L_POLIZA = qMODIFICACION_BAJA_SINIESTRO.L_POLIZA,
                        M_RECUPERADO = qMODIFICACION_BAJA_SINIESTRO.M_RECUPERADO,
                        NID_TIPO_BAJA = qMODIFICACION_BAJA.NID_TIPO_BAJA,
                        F_BAJA = qMODIFICACION_BAJA.F_BAJA,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (L_POLIZA.HasValue) single_query = single_query.Where<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(p => p.L_POLIZA == L_POLIZA );

            single_query = DecimalFilterBuilder<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>(M_RECUPERADO, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.M_RECUPERADO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.NID_PATRIMONIO.ToString(), query);

            if (L_POLIZA.HasValue) query = query.Where<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(p => p.L_POLIZA == L_POLIZA );

            query = DecimalFilterBuilder<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>(M_RECUPERADO, Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO.Properties.M_RECUPERADO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_BAJA_SINIESTROs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_BAJA_SINIESTROs = new List<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_BAJA_SINIESTROs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_BAJA_SINIESTROs = new List<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_BAJA_SINIESTRO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_BAJA_SINIESTRO> r;
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
