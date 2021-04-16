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
    public  class blld__l_CONFLICTO : bll__l_CONFLICTO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CONFLICTO.PageSize;
            set => datos_CONFLICTO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CONFLICTO.PageNumber;
            set => datos_CONFLICTO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CONFLICTO.TotalPages;

        public Int32 TotalItems => datos_CONFLICTO.TotalItems;

        private List<blld_CONFLICTO> _CONFLICTOs { get; set; }
        public List<blld_CONFLICTO> CONFLICTOs
        {
            get
            {
                if (_CONFLICTOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CONFLICTOs = new List<blld_CONFLICTO>();
                    foreach (MODELDeclara_V2.CONFLICTO o in base_CONFLICTOs)
                    {
                        _CONFLICTOs.Add(new blld_CONFLICTO(o));
                    }
                }
                return _CONFLICTOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CONFLICTO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CONFLICTO.single_select();
        }

     #endregion

    }
}
