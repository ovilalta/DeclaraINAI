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
    public  class blld__l_CAT_ESTADO_CONFLICTO : bll__l_CAT_ESTADO_CONFLICTO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_ESTADO_CONFLICTO.PageSize;
            set => datos_CAT_ESTADO_CONFLICTO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_ESTADO_CONFLICTO.PageNumber;
            set => datos_CAT_ESTADO_CONFLICTO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_ESTADO_CONFLICTO.TotalPages;

        public Int32 TotalItems => datos_CAT_ESTADO_CONFLICTO.TotalItems;

        private List<blld_CAT_ESTADO_CONFLICTO> _CAT_ESTADO_CONFLICTOs { get; set; }
        public List<blld_CAT_ESTADO_CONFLICTO> CAT_ESTADO_CONFLICTOs
        {
            get
            {
                if (_CAT_ESTADO_CONFLICTOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_ESTADO_CONFLICTOs = new List<blld_CAT_ESTADO_CONFLICTO>();
                    foreach (MODELDeclara_V2.CAT_ESTADO_CONFLICTO o in base_CAT_ESTADO_CONFLICTOs)
                    {
                        _CAT_ESTADO_CONFLICTOs.Add(new blld_CAT_ESTADO_CONFLICTO(o));
                    }
                }
                return _CAT_ESTADO_CONFLICTOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_ESTADO_CONFLICTO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_ESTADO_CONFLICTO.single_select();
        }

     #endregion

    }
}
