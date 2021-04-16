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
  //  internal class dal__l_H_PATRIMONIO_DEPENDIENTES : _dal_base_Declara
  //  {

  //   #region *** Atributos ***

  //      internal List<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES> lista_H_PATRIMONIO_DEPENDIENTESs { get; set; }
  //      internal List<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES> base_H_PATRIMONIO_DEPENDIENTESs { get; set; }


  //      internal StringFilter VID_NOMBRE { get; set; }
  //      internal ListFilter<String> VID_NOMBREs { get; set; }

  //      internal StringFilter VID_FECHA { get; set; }
  //      internal ListFilter<String> VID_FECHAs { get; set; }

  //      internal StringFilter VID_HOMOCLAVE { get; set; }
  //      internal ListFilter<String> VID_HOMOCLAVEs { get; set; }

  //      internal IntegerFilter NID_DEPENDIENTE { get; set; }
  //      internal ListFilter<Int32> NID_DEPENDIENTEs { get; set; }

  //      internal IntegerFilter NID_TIPO_DEPENDIENTE { get; set; }
  //      internal ListFilter<Int32> NID_TIPO_DEPENDIENTEs { get; set; }

  //      internal StringFilter E_NOMBRE { get; set; }
  //      internal ListFilter<String> E_NOMBREs { get; set; }

  //      internal StringFilter E_PRIMER_A { get; set; }
  //      internal ListFilter<String> E_PRIMER_As { get; set; }

  //      internal StringFilter E_SEGUNDO_A { get; set; }
  //      internal ListFilter<String> E_SEGUNDO_As { get; set; }

  //      internal DateTimeFilter F_NACIMIENTO { get; set; }
  //      internal ListFilter<DateTime> F_NACIMIENTOs { get; set; }

  //      internal StringFilter E_RFC { get; set; }
  //      internal ListFilter<String> E_RFCs { get; set; }

  //      internal IntegerFilter NID_HISTORICO { get; set; }
  //      internal ListFilter<Int32> NID_HISTORICOs { get; set; }


  //      private List<Order> _OrderByCriterios;
  //      internal List<Order> OrderByCriterios
  //      {
  //          get 
  //          {
  //              if (_OrderByCriterios == null) _OrderByCriterios = new List<Order>();
  //              return _OrderByCriterios; 
  //          }
  //          set { _OrderByCriterios = value; }
  //      }


  //      protected IQueryable<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES> query { get; set; }
  //      protected IQueryable<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES> single_query { get; set; }


  //   #endregion


  //   #region *** Constructores ***

  //      internal dal__l_H_PATRIMONIO_DEPENDIENTES()
  //      {
  //          VID_NOMBREs = new ListFilter<String>();
  //          VID_FECHAs = new ListFilter<String>();
  //          VID_HOMOCLAVEs = new ListFilter<String>();
  //          NID_DEPENDIENTEs = new ListFilter<Int32>();
  //          NID_TIPO_DEPENDIENTEs = new ListFilter<Int32>();
  //          E_NOMBREs = new ListFilter<String>();
  //          E_PRIMER_As = new ListFilter<String>();
  //          E_SEGUNDO_As = new ListFilter<String>();
  //          F_NACIMIENTOs = new ListFilter<DateTime>();
  //          E_RFCs = new ListFilter<String>();
  //          NID_HISTORICOs = new ListFilter<Int32>();
  //          query = null;
  //          single_query = null;
  //      }


  //   #endregion


  //   #region *** Metodos ***

  //    protected void Single_Select()
  //      {
  //          single_query = from p in db.H_PATRIMONIO_DEPENDIENTES
  //                         select p;
  //      }

  //      protected void Select()
  //      {

  //          query = from qH_PATRIMONIO_DEPENDIENTES in db.H_PATRIMONIO_DEPENDIENTES
  //                  join qCAT_TIPO_DEPENDIENTES in db.CAT_TIPO_DEPENDIENTES on qH_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE
  //                                                                      equals qCAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE
  //                  select new Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES
  //                  {
  //                      VID_NOMBRE = qH_PATRIMONIO_DEPENDIENTES.VID_NOMBRE,
  //                      VID_FECHA = qH_PATRIMONIO_DEPENDIENTES.VID_FECHA,
  //                      VID_HOMOCLAVE = qH_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE,
  //                      NID_DEPENDIENTE = qH_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE,
  //                      NID_TIPO_DEPENDIENTE = qH_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE,
  //                      E_NOMBRE = qH_PATRIMONIO_DEPENDIENTES.E_NOMBRE,
  //                      E_PRIMER_A = qH_PATRIMONIO_DEPENDIENTES.E_PRIMER_A,
  //                      E_SEGUNDO_A = qH_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A,
  //                      F_NACIMIENTO = qH_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO,
  //                      E_RFC = qH_PATRIMONIO_DEPENDIENTES.E_RFC,
  //                      NID_HISTORICO = qH_PATRIMONIO_DEPENDIENTES.NID_HISTORICO,
  //                      V_TIPO_DEPENDIENTE = qCAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE,
  //                  };
  //      }

  //      protected void Single_Where()
  //      {
  //          if (VID_NOMBREs.Count > 0) single_query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : single_query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_NOMBRE.ToString(), single_query);

  //          if (VID_FECHAs.Count > 0) single_query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : single_query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_FECHA.ToString(), single_query);

  //          if (VID_HOMOCLAVEs.Count > 0) single_query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : single_query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_HOMOCLAVE.ToString(), single_query);

  //          if (NID_DEPENDIENTEs.Count > 0) single_query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : single_query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
  //          single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(NID_DEPENDIENTE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString(), single_query);

  //          if (NID_TIPO_DEPENDIENTEs.Count > 0) single_query =  (NID_TIPO_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE)) : single_query.Where(p => !NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE));
  //          single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(NID_TIPO_DEPENDIENTE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE.ToString(), single_query);

  //          if (E_NOMBREs.Count > 0) single_query =  (E_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_NOMBREs.Contains(p.E_NOMBRE)) : single_query.Where(p => !E_NOMBREs.Contains(p.E_NOMBRE));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(E_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_NOMBRE.ToString(), single_query);

  //          if (E_PRIMER_As.Count > 0) single_query =  (E_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_PRIMER_As.Contains(p.E_PRIMER_A)) : single_query.Where(p => !E_PRIMER_As.Contains(p.E_PRIMER_A));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(E_PRIMER_A, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_PRIMER_A.ToString(), single_query);

  //          if (E_SEGUNDO_As.Count > 0) single_query =  (E_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_SEGUNDO_As.Contains(p.E_SEGUNDO_A)) : single_query.Where(p => !E_SEGUNDO_As.Contains(p.E_SEGUNDO_A));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(E_SEGUNDO_A, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_SEGUNDO_A.ToString(), single_query);

  //          single_query = DateTimeFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(F_NACIMIENTO, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.F_NACIMIENTO.ToString(), single_query);

  //          if (E_RFCs.Count > 0) single_query =  (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => E_RFCs.Contains(p.E_RFC)) : single_query.Where(p => !E_RFCs.Contains(p.E_RFC));
  //          single_query = StringFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(E_RFC, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_RFC.ToString(), single_query);

  //          if (NID_HISTORICOs.Count > 0) single_query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? single_query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : single_query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
  //          single_query = IntegerFilterBuilder<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_HISTORICO.ToString(), single_query);

  //      }

  //      protected void Where()
  //      {
  //          if (VID_NOMBREs.Count > 0) query =  (VID_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_NOMBREs.Contains(p.VID_NOMBRE)) : query.Where(p => !VID_NOMBREs.Contains(p.VID_NOMBRE));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(VID_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_NOMBRE.ToString(), query);

  //          if (VID_FECHAs.Count > 0) query =  (VID_FECHAs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_FECHAs.Contains(p.VID_FECHA)) : query.Where(p => !VID_FECHAs.Contains(p.VID_FECHA));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(VID_FECHA, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_FECHA.ToString(), query);

  //          if (VID_HOMOCLAVEs.Count > 0) query =  (VID_HOMOCLAVEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE)) : query.Where(p => !VID_HOMOCLAVEs.Contains(p.VID_HOMOCLAVE));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(VID_HOMOCLAVE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.VID_HOMOCLAVE.ToString(), query);

  //          if (NID_DEPENDIENTEs.Count > 0) query =  (NID_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE)) : query.Where(p => !NID_DEPENDIENTEs.Contains(p.NID_DEPENDIENTE));
  //          query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(NID_DEPENDIENTE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString(), query);

  //          if (NID_TIPO_DEPENDIENTEs.Count > 0) query =  (NID_TIPO_DEPENDIENTEs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE)) : query.Where(p => !NID_TIPO_DEPENDIENTEs.Contains(p.NID_TIPO_DEPENDIENTE));
  //          query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(NID_TIPO_DEPENDIENTE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE.ToString(), query);

  //          if (E_NOMBREs.Count > 0) query =  (E_NOMBREs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_NOMBREs.Contains(p.E_NOMBRE)) : query.Where(p => !E_NOMBREs.Contains(p.E_NOMBRE));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(E_NOMBRE, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_NOMBRE.ToString(), query);

  //          if (E_PRIMER_As.Count > 0) query =  (E_PRIMER_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_PRIMER_As.Contains(p.E_PRIMER_A)) : query.Where(p => !E_PRIMER_As.Contains(p.E_PRIMER_A));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(E_PRIMER_A, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_PRIMER_A.ToString(), query);

  //          if (E_SEGUNDO_As.Count > 0) query =  (E_SEGUNDO_As.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_SEGUNDO_As.Contains(p.E_SEGUNDO_A)) : query.Where(p => !E_SEGUNDO_As.Contains(p.E_SEGUNDO_A));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(E_SEGUNDO_A, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_SEGUNDO_A.ToString(), query);

  //          query = DateTimeFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(F_NACIMIENTO, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.F_NACIMIENTO.ToString(), query);

  //          if (E_RFCs.Count > 0) query =  (E_RFCs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => E_RFCs.Contains(p.E_RFC)) : query.Where(p => !E_RFCs.Contains(p.E_RFC));
  //          query = StringFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(E_RFC, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.E_RFC.ToString(), query);

  //          if (NID_HISTORICOs.Count > 0) query =  (NID_HISTORICOs.FilterCondition == ListFilter.FilterConditions.Normal) ? query.Where(p => NID_HISTORICOs.Contains(p.NID_HISTORICO)) : query.Where(p => !NID_HISTORICOs.Contains(p.NID_HISTORICO));
  //          query = IntegerFilterBuilder<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>(NID_HISTORICO, Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES.Properties.NID_HISTORICO.ToString(), query);

  //      }

  //      protected void Single_Exec()
  //      {
  //          if (single_query.Any())
  //          {
  //              base_H_PATRIMONIO_DEPENDIENTESs = single_query.AsNoTracking().ToList();
  //          }
  //          else
  //          {
  //              base_H_PATRIMONIO_DEPENDIENTESs = new List<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES>();
  //          }
  //      }

  //      protected void Exec()
  //      {
  //          if (query.Any())
  //          {
  //              lista_H_PATRIMONIO_DEPENDIENTESs = query.AsNoTracking().ToList();
  //          }
  //          else
  //          {
  //              lista_H_PATRIMONIO_DEPENDIENTESs = new List<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES>();
  //          }
  //      }

  //internal void Single_OrderBy()
  //      {
  //          if (OrderByCriterios.Count() > 0)
  //          {
  //              IOrderedQueryable<MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES> r;
  //              if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
  //                  r = single_query.OrderBy(OrderByCriterios[0].Field.ToString());
  //              else
  //                  r = single_query.OrderByDescending(OrderByCriterios[0].Field.ToString());
  //              for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
  //              {
  //                  if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
  //                      r.ThenBy(OrderByCriterios[x].Field.ToString());
  //                  else
  //                      r.ThenByDescending(OrderByCriterios[x].Field.ToString());
  //              }
  //              single_query = r;
  //          }
  //      }

  //      internal void orderBy()
  //      {
  //          if (OrderByCriterios.Count() > 0)
  //          {
  //              IOrderedQueryable<Declara_V2.MODELextended.H_PATRIMONIO_DEPENDIENTES> r;
  //              if (OrderByCriterios[0].OrderDirection == Order.OrderDirections.asc)
  //                  r = query.OrderBy(OrderByCriterios[0].Field.ToString());
  //              else
  //                  r = query.OrderByDescending(OrderByCriterios[0].Field.ToString());
  //              for (Int32 x = 1; x <= OrderByCriterios.Count(); x++)
  //              {
  //                  if (OrderByCriterios[x].OrderDirection == Order.OrderDirections.asc)
  //                      r.ThenBy(OrderByCriterios[x].Field.ToString());
  //                  else
  //                      r.ThenByDescending(OrderByCriterios[x].Field.ToString());
  //              }
  //              query = r;
  //          }
  //      }


  //      internal void clearOrderBy()
  //      {
  //          _OrderByCriterios = null;
  //      }

  //   #endregion

  //  }
}
