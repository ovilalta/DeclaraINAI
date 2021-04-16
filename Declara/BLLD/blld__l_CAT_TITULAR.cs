using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public class blld__l_CAT_TITULAR : bll__l_CAT_TITULAR
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_TITULAR.PageSize;
            set => datos_CAT_TITULAR.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_TITULAR.PageNumber;
            set => datos_CAT_TITULAR.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_TITULAR.TotalPages;
        public Int32 TotalItems => datos_CAT_TITULAR.TotalItems;
        private List<blld_CAT_TITULAR> _CAT_TITULARs { get; set; }
        public List<blld_CAT_TITULAR> CAT_TITULARs
        {
            get
            {
                if (_CAT_TITULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TITULARs = new List<blld_CAT_TITULAR>();
                    foreach (MODELDeclara_V2.CAT_TITULAR o in base_CAT_TITULARs)
                    {
                        _CAT_TITULARs.Add(new blld_CAT_TITULAR(o));
                    }
                }
                return _CAT_TITULARs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_TITULAR() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TITULAR.single_select();
        }

        #endregion

    }
}
