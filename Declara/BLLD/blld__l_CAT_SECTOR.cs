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
    public class blld__l_CAT_SECTOR : bll__l_CAT_SECTOR
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_SECTOR.PageSize;
            set => datos_CAT_SECTOR.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_SECTOR.PageNumber;
            set => datos_CAT_SECTOR.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_SECTOR.TotalPages;
        public Int32 TotalItems => datos_CAT_SECTOR.TotalItems;
        private List<blld_CAT_SECTOR> _CAT_SECTORs { get; set; }
        public List<blld_CAT_SECTOR> CAT_SECTORs
        {
            get
            {
                if (_CAT_SECTORs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_SECTORs = new List<blld_CAT_SECTOR>();
                    foreach (MODELDeclara_V2.CAT_SECTOR o in base_CAT_SECTORs)
                    {
                        _CAT_SECTORs.Add(new blld_CAT_SECTOR(o));
                    }
                }
                return _CAT_SECTORs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_SECTOR() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_SECTOR.single_select();
        }

        #endregion

    }
}
