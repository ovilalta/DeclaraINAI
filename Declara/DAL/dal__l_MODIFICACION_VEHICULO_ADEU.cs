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
    internal class dal__l_MODIFICACION_VEHICULO_ADEU : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU> lista_MODIFICACION_VEHICULO_ADEUs { get; set; }
        internal List<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU> base_MODIFICACION_VEHICULO_ADEUs { get; set; }


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

        internal IntegerFilter NID_PATRIMONIO_ADEUDO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIO_ADEUDOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU> query { get; set; }
        protected IQueryable<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_MODIFICACION_VEHICULO_ADEU()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_PATRIMONIO_ADEUDOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.MODIFICACION_VEHICULO_ADEU
                           select p;
        }

        protected void Select()
        {

            query = from qMODIFICACION_VEHICULO_ADEU in db.MODIFICACION_VEHICULO_ADEU
                    select new Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU
                    {
                        VID_NOMBRE = qMODIFICACION_VEHICULO_ADEU.VID_NOMBRE,
                        VID_FECHA = qMODIFICACION_VEHICULO_ADEU.VID_FECHA,
                        VID_HOMOCLAVE = qMODIFICACION_VEHICULO_ADEU.VID_HOMOCLAVE,
                        NID_DECLARACION = qMODIFICACION_VEHICULO_ADEU.NID_DECLARACION,
                        NID_PATRIMONIO = qMODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO,
                        NID_PATRIMONIO_ADEUDO = qMODIFICACION_VEHICULO_ADEU.NID_PATRIMONIO_ADEUDO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_PATRIMONIO_ADEUDOs.Count > 0) single_query =  (NID_PATRIMONIO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIO_ADEUDOs.Contains(p.NID_PATRIMONIO_ADEUDO)) : single_query.Where(p => !NID_PATRIMONIO_ADEUDOs.Contains(p.NID_PATRIMONIO_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>(NID_PATRIMONIO_ADEUDO, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_PATRIMONIO_ADEUDO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(VID_NOMBRE, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(VID_FECHA, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(VID_HOMOCLAVE, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(NID_DECLARACION, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_DECLARACION.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(NID_PATRIMONIO, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_PATRIMONIO_ADEUDOs.Count > 0) query =  (NID_PATRIMONIO_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIO_ADEUDOs.Contains(p.NID_PATRIMONIO_ADEUDO)) : query.Where(p => !NID_PATRIMONIO_ADEUDOs.Contains(p.NID_PATRIMONIO_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>(NID_PATRIMONIO_ADEUDO, Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU.Properties.NID_PATRIMONIO_ADEUDO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_MODIFICACION_VEHICULO_ADEUs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_MODIFICACION_VEHICULO_ADEUs = new List<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_MODIFICACION_VEHICULO_ADEUs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_MODIFICACION_VEHICULO_ADEUs = new List<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.MODIFICACION_VEHICULO_ADEU> r;
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
