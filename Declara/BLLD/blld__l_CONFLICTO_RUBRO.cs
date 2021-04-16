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
    public  class blld__l_CONFLICTO_RUBRO : bll__l_CONFLICTO_RUBRO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CONFLICTO_RUBRO.PageSize;
            set => datos_CONFLICTO_RUBRO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CONFLICTO_RUBRO.PageNumber;
            set => datos_CONFLICTO_RUBRO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CONFLICTO_RUBRO.TotalPages;

        public Int32 TotalItems => datos_CONFLICTO_RUBRO.TotalItems;

        private List<blld_CONFLICTO_RUBRO> _CONFLICTO_RUBROs { get; set; }
        public List<blld_CONFLICTO_RUBRO> CONFLICTO_RUBROs
        {
            get
            {
                if (_CONFLICTO_RUBROs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CONFLICTO_RUBROs = new List<blld_CONFLICTO_RUBRO>();
                    foreach (MODELDeclara_V2.CONFLICTO_RUBRO o in base_CONFLICTO_RUBROs)
                    {
                        _CONFLICTO_RUBROs.Add(new blld_CONFLICTO_RUBRO(o));
                    }
                }
                return _CONFLICTO_RUBROs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CONFLICTO_RUBRO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CONFLICTO_RUBRO.single_select();
        }

     #endregion

    }
}
