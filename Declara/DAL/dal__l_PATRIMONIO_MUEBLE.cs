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
    internal class dal__l_PATRIMONIO_MUEBLE : _dal_base_Declara
    {

     #region *** Atributos ***

        internal List<Declara_V2.MODELextended.PATRIMONIO_MUEBLE> lista_PATRIMONIO_MUEBLEs { get; set; }
        internal List<MODELDeclara_V2.PATRIMONIO_MUEBLE> base_PATRIMONIO_MUEBLEs { get; set; }


        internal StringFilter VID_NOMBRE { get; set; }
        internal ListFilter<String> VID_NOMBREs { get; set; }

        internal StringFilter VID_FECHA { get; set; }
        internal ListFilter<String> VID_FECHAs { get; set; }

        internal StringFilter VID_HOMOCLAVE { get; set; }
        internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

        internal IntegerFilter NID_PATRIMONIO { get; set; }
        internal ListFilter<Int32> NID_PATRIMONIOs { get; set; }

        internal IntegerFilter NID_TIPO { get; set; }
        internal ListFilter<Int32> NID_TIPOs { get; set; }

        internal StringFilter E_ESPECIFICACION { get; set; }
        internal ListFilter<String> E_ESPECIFICACIONs { get; set; }

        internal DecimalFilter M_VALOR { get; set; }
        internal ListFilter<Decimal> M_VALORs { get; set; }

        internal DateTimeFilter F_ADQUISICION { get; set; }
        internal ListFilter<DateTime> F_ADQUISICIONs { get; set; }


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


        protected IQueryable<Declara_V2.MODELextended.PATRIMONIO_MUEBLE> query { get; set; }
        protected IQueryable<MODELDeclara_V2.PATRIMONIO_MUEBLE> single_query { get; set; }


     #endregion


     #region *** Constructores ***

        internal dal__l_PATRIMONIO_MUEBLE()
        {
            VID_NOMBREs = new ListFilter<String>();
            VID_FECHAs = new ListFilter<String>();
            VID_HOMOCLAVEs = new ListFilter<String>();
            NID_PATRIMONIOs = new ListFilter<Int32>();
            NID_TIPOs = new ListFilter<Int32>();
            E_ESPECIFICACIONs = new ListFilter<String>();
            M_VALORs = new ListFilter<Decimal>();
            F_ADQUISICIONs = new ListFilter<DateTime>();
            query = null;
            single_query = null;
        }


     #endregion


     #region *** Metodos ***

      protected void Single_Select()
        {
            single_query = from p in db.PATRIMONIO_MUEBLE
                           select p;
        }

        protected void Select()
        {

            query = from qPATRIMONIO_MUEBLE in db.PATRIMONIO_MUEBLE
                    join qCAT_TIPO_MUEBLE in db.CAT_TIPO_MUEBLE on qPATRIMONIO_MUEBLE.NID_TIPO
                                                            equals qCAT_TIPO_MUEBLE.NID_TIPO
                    join qPATRIMONIO in db.PATRIMONIO on new { qPATRIMONIO_MUEBLE.VID_NOMBRE, qPATRIMONIO_MUEBLE.VID_FECHA, qPATRIMONIO_MUEBLE.VID_HOMOCLAVE, qPATRIMONIO_MUEBLE.NID_PATRIMONIO }
                                                  equals new { qPATRIMONIO.VID_NOMBRE, qPATRIMONIO.VID_FECHA, qPATRIMONIO.VID_HOMOCLAVE, qPATRIMONIO.NID_PATRIMONIO }
                    select new Declara_V2.MODELextended.PATRIMONIO_MUEBLE
                    {
                        VID_NOMBRE = qPATRIMONIO_MUEBLE.VID_NOMBRE,
                        VID_FECHA = qPATRIMONIO_MUEBLE.VID_FECHA,
                        VID_HOMOCLAVE = qPATRIMONIO_MUEBLE.VID_HOMOCLAVE,
                        NID_PATRIMONIO = qPATRIMONIO_MUEBLE.NID_PATRIMONIO,
                        NID_TIPO = qPATRIMONIO_MUEBLE.NID_TIPO,
                        E_ESPECIFICACION = qPATRIMONIO_MUEBLE.E_ESPECIFICACION,
                        M_VALOR = qPATRIMONIO_MUEBLE.M_VALOR,
                        F_ADQUISICION = qPATRIMONIO_MUEBLE.F_ADQUISICION,
                        V_TIPO = qCAT_TIPO_MUEBLE.V_TIPO,
                        L_ACTIVO = qCAT_TIPO_MUEBLE.L_ACTIVO,
                        NID_DEC_INCOR = qPATRIMONIO.NID_DEC_INCOR,
                        F_INCORPORACION = qPATRIMONIO.F_INCORPORACION,
                        NID_DEC_ULT_MOD = qPATRIMONIO.NID_DEC_ULT_MOD,
                        F_MODIFICACION = qPATRIMONIO.F_MODIFICACION,
 
                        F_REGISTRO = qPATRIMONIO.F_REGISTRO,
                    };
        }

        protected void Single_Where()
        {
            if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_NOMBRE.ToString(), single_query);

            if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_FECHA.ToString(), single_query);

            if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_HOMOCLAVE.ToString(), single_query);

            if (NID_PATRIMONIOs.Count > 0) single_query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : single_query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.NID_PATRIMONIO.ToString(), single_query);

            if (NID_TIPOs.Count > 0) single_query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : single_query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            single_query = IntegerFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.NID_TIPO.ToString(), single_query);

            if (E_ESPECIFICACIONs.Count > 0) single_query =  (E_ESPECIFICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION)) : single_query.Where(p => !E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION));
            single_query = StringFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(E_ESPECIFICACION, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.E_ESPECIFICACION.ToString(), single_query);

            single_query = DecimalFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(M_VALOR, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.M_VALOR.ToString(), single_query);

            single_query = DateTimeFilterBuilder<MODELDeclara_V2.PATRIMONIO_MUEBLE>(F_ADQUISICION, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.F_ADQUISICION.ToString(), single_query);

        }

        protected void Where()
        {
            if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(VID_NOMBRE, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_NOMBRE.ToString(), query);

            if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(VID_FECHA, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_FECHA.ToString(), query);

            if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(VID_HOMOCLAVE, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.VID_HOMOCLAVE.ToString(), query);

            if (NID_PATRIMONIOs.Count > 0) query =  (NID_PATRIMONIOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO)) : query.Where(p => !NID_PATRIMONIOs.Contains(p.NID_PATRIMONIO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(NID_PATRIMONIO, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.NID_PATRIMONIO.ToString(), query);

            if (NID_TIPOs.Count > 0) query =  (NID_TIPOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPOs.Contains(p.NID_TIPO)) : query.Where(p => !NID_TIPOs.Contains(p.NID_TIPO));
            query = IntegerFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(NID_TIPO, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.NID_TIPO.ToString(), query);

            if (E_ESPECIFICACIONs.Count > 0) query =  (E_ESPECIFICACIONs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION)) : query.Where(p => !E_ESPECIFICACIONs.Contains(p.E_ESPECIFICACION));
            query = StringFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(E_ESPECIFICACION, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.E_ESPECIFICACION.ToString(), query);

            query = DecimalFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(M_VALOR, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.M_VALOR.ToString(), query);

            query = DateTimeFilterBuilder<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>(F_ADQUISICION, Declara_V2.MODELextended.PATRIMONIO_MUEBLE.Properties.F_ADQUISICION.ToString(), query);

        }

        protected void Single_Exec()
        {
            if (single_query.Any())
            {
                base_PATRIMONIO_MUEBLEs = single_query.AsNoTracking().ToList();
            }
            else
            {
                base_PATRIMONIO_MUEBLEs = new List<MODELDeclara_V2.PATRIMONIO_MUEBLE>();
            }
        }

        protected void Exec()
        {
            if (query.Any())
            {
                lista_PATRIMONIO_MUEBLEs = query.AsNoTracking().ToList();
            }
            else
            {
                lista_PATRIMONIO_MUEBLEs = new List<Declara_V2.MODELextended.PATRIMONIO_MUEBLE>();
            }
        }

  internal void Single_OrderBy()
        {
            if (OrderByCriterios.Count() > 0)
            {
                IOrderedQueryable<MODELDeclara_V2.PATRIMONIO_MUEBLE> r;
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
                IOrderedQueryable<Declara_V2.MODELextended.PATRIMONIO_MUEBLE> r;
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
