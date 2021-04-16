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
    internal class dal__l_ALTA_VEHICULO_ADEUDO : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO> lista_ALTA_VEHICULO_ADEUDOs { get; set; }
        internal List<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO> base_ALTA_VEHICULO_ADEUDOs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_DECLARACION { get; set; }
        internal ListFilter<Int32> NID_DECLARACIONs { get; set; }

        internal IntegerFilter NID_VEHICULO { get; set; }
        internal ListFilter<Int32> NID_VEHICULOs { get; set; }

        internal IntegerFilter NID_ADEUDO { get; set; }
        internal ListFilter<Int32> NID_ADEUDOs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO> query { get; set; }
        protected IQueryable<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_ALTA_VEHICULO_ADEUDO()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_DECLARACIONs = new ListFilter<Int32>();
            NID_VEHICULOs = new ListFilter<Int32>();
            NID_ADEUDOs = new ListFilter<Int32>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.ALTA_VEHICULO_ADEUDO
                           select p;
        }

        protected void Select()
        {

            query = from qALTA_VEHICULO_ADEUDO in db.ALTA_VEHICULO_ADEUDO
                    join qALTA_VEHICULO in db.ALTA_VEHICULO on new { qALTA_VEHICULO_ADEUDO.VID_NOMBRE, qALTA_VEHICULO_ADEUDO.VID_FECHA, qALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE, qALTA_VEHICULO_ADEUDO.NID_DECLARACION, qALTA_VEHICULO_ADEUDO.NID_VEHICULO }
                                                        equals new { qALTA_VEHICULO.VID_NOMBRE, qALTA_VEHICULO.VID_FECHA, qALTA_VEHICULO.VID_HOMOCLAVE, qALTA_VEHICULO.NID_DECLARACION, qALTA_VEHICULO.NID_VEHICULO }
                    select new Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO
                    {
                        VID_NOMBRE = qALTA_VEHICULO_ADEUDO.VID_NOMBRE,
                        VID_FECHA = qALTA_VEHICULO_ADEUDO.VID_FECHA,
                        VID_HOMOCLAVE = qALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE,
                        NID_DECLARACION = qALTA_VEHICULO_ADEUDO.NID_DECLARACION,
                        NID_VEHICULO = qALTA_VEHICULO_ADEUDO.NID_VEHICULO,
                        NID_ADEUDO = qALTA_VEHICULO_ADEUDO.NID_ADEUDO,
                        NID_MARCA = qALTA_VEHICULO.NID_MARCA,
                        C_MODELO = qALTA_VEHICULO.C_MODELO,
                        V_DESCRIPCION = qALTA_VEHICULO.V_DESCRIPCION,
                        F_ADQUISICION = qALTA_VEHICULO.F_ADQUISICION,
                        NID_USO = qALTA_VEHICULO.NID_USO,
                        M_VALOR_VEHICULO = qALTA_VEHICULO.M_VALOR_VEHICULO,
                        NID_PATRIMONIO = qALTA_VEHICULO.NID_PATRIMONIO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_DECLARACIONs.Count > 0) single_query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : single_query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_DECLARACION.ToString(), single_query);

            if (NID_VEHICULOs.Count > 0) single_query =  (NID_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_VEHICULOs.Contains(p.NID_VEHICULO)) : single_query.Where(p => !NID_VEHICULOs.Contains(p.NID_VEHICULO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(NID_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_VEHICULO.ToString(), single_query);

            if (NID_ADEUDOs.Count > 0) single_query =  (NID_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_ADEUDOs.Contains(p.NID_ADEUDO)) : single_query.Where(p => !NID_ADEUDOs.Contains(p.NID_ADEUDO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>(NID_ADEUDO, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_ADEUDO.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(VID_NOMBRE, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(VID_FECHA, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(VID_HOMOCLAVE, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_DECLARACIONs.Count > 0) query =  (NID_DECLARACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DECLARACIONs.Contains(p.NID_DECLARACION)) : query.Where(p => !NID_DECLARACIONs.Contains(p.NID_DECLARACION));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(NID_DECLARACION, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_DECLARACION.ToString(), query);

            if (NID_VEHICULOs.Count > 0) query =  (NID_VEHICULOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_VEHICULOs.Contains(p.NID_VEHICULO)) : query.Where(p => !NID_VEHICULOs.Contains(p.NID_VEHICULO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(NID_VEHICULO, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_VEHICULO.ToString(), query);

            if (NID_ADEUDOs.Count > 0) query =  (NID_ADEUDOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_ADEUDOs.Contains(p.NID_ADEUDO)) : query.Where(p => !NID_ADEUDOs.Contains(p.NID_ADEUDO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>(NID_ADEUDO, Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO.Properties.NID_ADEUDO.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_ALTA_VEHICULO_ADEUDOs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_ALTA_VEHICULO_ADEUDOs = new List<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_ALTA_VEHICULO_ADEUDOs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_ALTA_VEHICULO_ADEUDOs = new List<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.ALTA_VEHICULO_ADEUDO> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.ALTA_VEHICULO_ADEUDO> r;
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
