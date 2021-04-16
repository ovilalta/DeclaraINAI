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
    public class blld__l_CAT_DOCUMENTO_OBTENIDO : bll__l_CAT_DOCUMENTO_OBTENIDO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.PageSize;
            set => datos_CAT_DOCUMENTO_OBTENIDO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_CAT_DOCUMENTO_OBTENIDO.PageNumber;
            set => datos_CAT_DOCUMENTO_OBTENIDO.PageNumber = value;
        }
        public Int32 TotalPages => datos_CAT_DOCUMENTO_OBTENIDO.TotalPages;
        public Int32 TotalItems => datos_CAT_DOCUMENTO_OBTENIDO.TotalItems;
        private List<blld_CAT_DOCUMENTO_OBTENIDO> _CAT_DOCUMENTO_OBTENIDOs { get; set; }
        public List<blld_CAT_DOCUMENTO_OBTENIDO> CAT_DOCUMENTO_OBTENIDOs
        {
            get
            {
                if (_CAT_DOCUMENTO_OBTENIDOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_DOCUMENTO_OBTENIDOs = new List<blld_CAT_DOCUMENTO_OBTENIDO>();
                    foreach (MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO o in base_CAT_DOCUMENTO_OBTENIDOs)
                    {
                        _CAT_DOCUMENTO_OBTENIDOs.Add(new blld_CAT_DOCUMENTO_OBTENIDO(o));
                    }
                }
                return _CAT_DOCUMENTO_OBTENIDOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_CAT_DOCUMENTO_OBTENIDO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_DOCUMENTO_OBTENIDO.single_select();
        }

        #endregion

    }
}
