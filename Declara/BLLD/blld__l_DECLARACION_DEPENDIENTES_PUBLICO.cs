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
    public class blld__l_DECLARACION_DEPENDIENTES_PUBLICO : bll__l_DECLARACION_DEPENDIENTES_PUBLICO
    {

        #region *** Propiedades ***
        public Int32 PageIndex { get; set; }
        public Int32 PageSize
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.PageSize;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.PageSize = value;
        }
        public Int32 PageNumber
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.PageNumber;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.PageNumber = value;
        }
        public Int32 TotalPages => datos_DECLARACION_DEPENDIENTES_PUBLICO.TotalPages;
        public Int32 TotalItems => datos_DECLARACION_DEPENDIENTES_PUBLICO.TotalItems;
        private List<blld_DECLARACION_DEPENDIENTES_PUBLICO> _DECLARACION_DEPENDIENTES_PUBLICOs { get; set; }
        public List<blld_DECLARACION_DEPENDIENTES_PUBLICO> DECLARACION_DEPENDIENTES_PUBLICOs
        {
            get
            {
                if (_DECLARACION_DEPENDIENTES_PUBLICOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_DEPENDIENTES_PUBLICOs = new List<blld_DECLARACION_DEPENDIENTES_PUBLICO>();
                    foreach (MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO o in base_DECLARACION_DEPENDIENTES_PUBLICOs)
                    {
                        _DECLARACION_DEPENDIENTES_PUBLICOs.Add(new blld_DECLARACION_DEPENDIENTES_PUBLICO(o));
                    }
                }
                return _DECLARACION_DEPENDIENTES_PUBLICOs;
            }
        }

        #endregion

        #region *** Constructores ***
        public blld__l_DECLARACION_DEPENDIENTES_PUBLICO() : base() { } 

        #endregion

        #region *** Metodos ***
        public void single_select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_DEPENDIENTES_PUBLICO.single_select();
        }

        #endregion

    }
}
