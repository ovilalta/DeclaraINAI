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
    public class blld__l_CAT_AMBITO_SECTOR : bll__l_CAT_AMBITO_SECTOR
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_AMBITO_SECTOR.PageSize;
            set => datos_CAT_AMBITO_SECTOR.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_AMBITO_SECTOR.PageNumber;
            set => datos_CAT_AMBITO_SECTOR.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_AMBITO_SECTOR.TotalPages;
        public Int32 TotalItems => datos_CAT_AMBITO_SECTOR.TotalItems;
        private List<blld_CAT_AMBITO_SECTOR> _CAT_AMBITO_SECTORs { get; set; }
        public List<blld_CAT_AMBITO_SECTOR> CAT_AMBITO_SECTORs
        {
            get
            {
                if (_CAT_AMBITO_SECTORs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_AMBITO_SECTORs = new List<blld_CAT_AMBITO_SECTOR>();
                    foreach (MODELDeclara_V2.CAT_AMBITO_SECTOR o in base_CAT_AMBITO_SECTORs)
                    {
                        _CAT_AMBITO_SECTORs.Add(new blld_CAT_AMBITO_SECTOR(o));
                    }
                }
                return _CAT_AMBITO_SECTORs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_AMBITO_SECTOR() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_AMBITO_SECTOR.single_select();
        }

        #endregion

    }
}
