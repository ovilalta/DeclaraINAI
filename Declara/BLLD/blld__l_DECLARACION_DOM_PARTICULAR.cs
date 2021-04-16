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
    public  class blld__l_DECLARACION_DOM_PARTICULAR : bll__l_DECLARACION_DOM_PARTICULAR
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_DOM_PARTICULAR.PageSize;
            set => datos_DECLARACION_DOM_PARTICULAR.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_DOM_PARTICULAR.PageNumber;
            set => datos_DECLARACION_DOM_PARTICULAR.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_DOM_PARTICULAR.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_DOM_PARTICULAR.TotalItems;

        private List<blld_DECLARACION_DOM_PARTICULAR> _DECLARACION_DOM_PARTICULARs { get; set; }
        public List<blld_DECLARACION_DOM_PARTICULAR> DECLARACION_DOM_PARTICULARs
        {
            get
            {
                if (_DECLARACION_DOM_PARTICULARs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_DOM_PARTICULARs = new List<blld_DECLARACION_DOM_PARTICULAR>();
                    foreach (MODELDeclara_V2.DECLARACION_DOM_PARTICULAR o in base_DECLARACION_DOM_PARTICULARs)
                    {
                        _DECLARACION_DOM_PARTICULARs.Add(new blld_DECLARACION_DOM_PARTICULAR(o));
                    }
                }
                return _DECLARACION_DOM_PARTICULARs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_DOM_PARTICULAR() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_DOM_PARTICULAR.single_select();
        }

     #endregion

    }
}
