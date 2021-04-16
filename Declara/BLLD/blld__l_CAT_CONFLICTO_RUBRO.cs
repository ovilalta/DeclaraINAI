using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public  class blld__l_CAT_CONFLICTO_RUBRO : bll__l_CAT_CONFLICTO_RUBRO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_CONFLICTO_RUBRO.PageSize;
            set => datos_CAT_CONFLICTO_RUBRO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_CONFLICTO_RUBRO.PageNumber;
            set => datos_CAT_CONFLICTO_RUBRO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_CONFLICTO_RUBRO.TotalPages;

        public Int32 TotalItems => datos_CAT_CONFLICTO_RUBRO.TotalItems;

        private List<blld_CAT_CONFLICTO_RUBRO> _CAT_CONFLICTO_RUBROs { get; set; }
        public List<blld_CAT_CONFLICTO_RUBRO> CAT_CONFLICTO_RUBROs
        {
            get
            {
                if (_CAT_CONFLICTO_RUBROs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_CONFLICTO_RUBROs = new List<blld_CAT_CONFLICTO_RUBRO>();
                    foreach (MODELDeclara_V2.CAT_CONFLICTO_RUBRO o in base_CAT_CONFLICTO_RUBROs)
                    {
                        _CAT_CONFLICTO_RUBROs.Add(new blld_CAT_CONFLICTO_RUBRO(o));
                    }
                }
                return _CAT_CONFLICTO_RUBROs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_CONFLICTO_RUBRO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_CONFLICTO_RUBRO.single_select();
        }

     #endregion

    }
}
