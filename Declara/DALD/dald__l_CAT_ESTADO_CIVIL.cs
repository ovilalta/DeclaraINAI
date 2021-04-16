using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using MODELDeclara_V2;
using Declara_V2;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal class dald__l_CAT_ESTADO_CIVIL : dal__l_CAT_ESTADO_CIVIL
    {

     #region *** Atributos ***

        private Int32 _PageSize;
        internal  Int32 PageSize
        {
            get { return _PageSize; }
            set 
            {
                if (value >= 0)
                    _PageSize = value;
                else
                    _PageSize = 0;

                if (_PageSize == 0)
                    _PageNumber = 0;
                else
                    _PageNumber = 1;
            }
        }

        private Int32 _PageNumber;
        internal  Int32 PageNumber
        {
            get 
            {
                if (_PageNumber > TotalPages)
                    _PageNumber = TotalPages;
                return _PageNumber; 
            }
            set 
            {
                if (_PageSize != 0)
                    if (value <= TotalPages)
                        _PageNumber = value;
                    else
                        _PageNumber = TotalPages;
                else
                    _PageNumber = 0;
            }
        }   
        
        private Int32 _TotalPages;
        internal  Int32 TotalPages
        {
            get { return _TotalPages; }
        }

        private Int32 _TotalItems;
    internal Int32 TotalItems
        {
            get 
            {
                if (PageSize > 0)
                {
                    return _TotalItems;
                }
                else
                {
                    if (lista_CAT_ESTADO_CIVILs != null)
                    {
                        return lista_CAT_ESTADO_CIVILs.Count;
                    }
                    else
                    {
                        return base_CAT_ESTADO_CIVILs.Count;
                    }
                }
            }
        }

     #endregion


     #region *** Constructores ***

        internal dald__l_CAT_ESTADO_CIVIL()
        : base()
        {
		      _PageSize = 0;
            _PageNumber = 0;
            _TotalPages = 1;
        }

     #endregion


     #region *** Metodos ***

  private void Single_WhereExtended()
        {
        }

        private void WhereExtended()
        {
        }

        public void single_select()
        {
            query = null;
            lista_CAT_ESTADO_CIVILs = null;
            base.Single_Select();
            base.Single_Where();
            Single_WhereExtended();
            base.Single_OrderBy();
            if (PageSize > 0)
            {
                _TotalItems = single_query.Count();
                _TotalPages = (Int32)Math.Ceiling((Double)TotalItems / (Double)PageSize);
                if (TotalPages > 1)
                {
                    single_query.Skip(PageSize * (PageNumber - 1));
                    single_query.Take(PageSize);
                }
            }
            base.Single_Exec();
        }

        public void select()
        {
            single_query = null;
            base_CAT_ESTADO_CIVILs = null;
            base.Select();
            base.Where();
            WhereExtended();
            base.orderBy();
            if (PageSize > 0)
            {
                _TotalItems = query.Count();
                _TotalPages = (Int32)Math.Ceiling((Double)TotalItems / (Double)PageSize);
                if (TotalPages > 1)
                {
                    query.Skip(PageSize * (PageNumber - 1));
                    query.Take(PageSize);
                }
            }
            base.Exec();
        }

     #endregion

    }
}
