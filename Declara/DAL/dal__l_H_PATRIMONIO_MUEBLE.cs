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
    internal class dal__l_H_PATRIMONIO_MUEBLE : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE> lista_H_PATRIMONIO_MUEBLEs { get; set; }
        internal List<MODELDeclara_V2.H_PATRIMONIO_MUEBLE> base_H_PATRIMONIO_MUEBLEs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal IntegerFilter NID_HISTORICO { get; set; }
        internal ListFilter<Int32> NID_HISTORICOs { get; set; }

        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal StringFilter E_ESPECIFICACION { get; set; }
        internal ListFilter<String> E_ESPECIFICACIONs { get; set; }

        internal System.Nullable<Decimal> M_VALOR { get; set; }
        internal ListFilter<Decimal> M_VALORs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE> query { get; set; }
        protected IQueryable<MODELDeclara_V2.H_PATRIMONIO_MUEBLE> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_H_PATRIMONIO_MUEBLE()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_HISTORICOs = new ListFilter<Int32>();
            NID_TIPOs = new ListFilter<Int32>();
            E_ESPECIFICACIONs = new ListFilter<String>();
            M_VALORs = new ListFilter<Decimal>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.H_PATRIMONIO_MUEBLE
                           select p;
        }

        protected void Select()
        {

            query = from qH_PATRIMONIO_MUEBLE in db.H_PATRIMONIO_MUEBLE
                    join qCAT_TIPO_MUEBLE in db.CAT_TIPO_MUEBLE on qH_PATRIMONIO_MUEBLE.NID_TIPO
                                                            equals qCAT_TIPO_MUEBLE.NID_TIPO
                    join qH_PATRIMONIO in db.H_PATRIMONIO on new { qH_PATRIMONIO_MUEBLE.VID_NOMBRE, qH_PATRIMONIO_MUEBLE.VID_FECHA, qH_PATRIMONIO_MUEBLE.VID_HOMOCLAVE, qH_PATRIMONIO_MUEBLE.NID_PATRIMONIO, qH_PATRIMONIO_MUEBLE.NID_HISTORICO }
                                                      equals new { qH_PATRIMONIO.VID_NOMBRE, qH_PATRIMONIO.VID_FECHA, qH_PATRIMONIO.VID_HOMOCLAVE, qH_PATRIMONIO.NID_PATRIMONIO, qH_PATRIMONIO.NID_HISTORICO }
                    select new Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE
                    {
                        VID_NOMBRE = qH_PATRIMONIO_MUEBLE.VID_NOMBRE,
                        VID_FECHA = qH_PATRIMONIO_MUEBLE.VID_FECHA,
                        VID_HOMOCLAVE = qH_PATRIMONIO_MUEBLE.VID_HOMOCLAVE,
                        NID_PATRIMONIO = qH_PATRIMONIO_MUEBLE.NID_PATRIMONIO,
                        NID_HISTORICO = qH_PATRIMONIO_MUEBLE.NID_HISTORICO,
                        NID_TIPO = qH_PATRIMONIO_MUEBLE.NID_TIPO,
                        E_ESPECIFICACION = qH_PATRIMONIO_MUEBLE.E_ESPECIFICACION,
                        M_VALOR = qH_PATRIMONIO_MUEBLE.M_VALOR,
                        V_TIPO = qCAT_TIPO_MUEBLE.V_TIPO,
                        NID_DEC_INCOR = qH_PATRIMONIO.NID_DEC_INCOR,
                        F_INCORPORACION = qH_PATRIMONIO.F_INCORPORACION,
                        NID_DEC_ULT_MOD = qH_PATRIMONIO.NID_DEC_ULT_MOD,
                        F_MODIFICACION = qH_PATRIMONIO.F_MODIFICACION,
                        L_ACTIVO = qH_PATRIMONIO.L_ACTIVO,
                        F_REGISTRO = qH_PATRIMONIO.F_REGISTRO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_HISTORICOs.Count > 0) single_query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : single_query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_HISTORICO.ToString(), single_query);

            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_TIPO.ToString(), single_query);

            if (E_ESPECIFICACIONs.Count > 0) single_query =  (E_ESPECIFICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION)) : single_query.Where(p => !E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(E_ESPECIFICACION, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.E_ESPECIFICACION.ToString(), single_query);

            if (M_VALORs.Count > 0) single_query =  (M_VALORs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => M_VALORs.Contains(p.M_VALOR)) : single_query.Where(p => !M_VALORs.Contains(p.M_VALOR));
            if (M_VALOR.HasValue) single_query = single_query.Where<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>(p => p.M_VALOR == M_VALOR);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_HISTORICOs.Count > 0) query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_HISTORICO.ToString(), query);

            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.NID_TIPO.ToString(), query);

            if (E_ESPECIFICACIONs.Count > 0) query =  (E_ESPECIFICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION)) : query.Where(p => !E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(E_ESPECIFICACION, Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE.Properties.E_ESPECIFICACION.ToString(), query);

            if (M_VALORs.Count > 0) query =  (M_VALORs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => M_VALORs.Contains(p.M_VALOR)) : query.Where(p => !M_VALORs.Contains(p.M_VALOR));
            if (M_VALOR.HasValue) query = query.Where<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>(p => p.M_VALOR == M_VALOR);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_H_PATRIMONIO_MUEBLEs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_H_PATRIMONIO_MUEBLEs = new List<MODELDeclara_V2.H_PATRIMONIO_MUEBLE>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_H_PATRIMONIO_MUEBLEs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_H_PATRIMONIO_MUEBLEs = new List<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.H_PATRIMONIO_MUEBLE> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.H_PATRIMONIO_MUEBLE> r;
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
