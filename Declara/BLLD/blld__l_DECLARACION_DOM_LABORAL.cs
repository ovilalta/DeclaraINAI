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
    public  class blld__l_DECLARACION_DOM_LABORAL : bll__l_DECLARACION_DOM_LABORAL
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_DECLARACION_DOM_LABORAL.PageSize;
            set => datos_DECLARACION_DOM_LABORAL.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_DECLARACION_DOM_LABORAL.PageNumber;
            set => datos_DECLARACION_DOM_LABORAL.PageNumber = value;
        }

        public Int32 TotalPages => datos_DECLARACION_DOM_LABORAL.TotalPages;

        public Int32 TotalItems => datos_DECLARACION_DOM_LABORAL.TotalItems;

        private List<blld_DECLARACION_DOM_LABORAL> _DECLARACION_DOM_LABORALs { get; set; }
        public List<blld_DECLARACION_DOM_LABORAL> DECLARACION_DOM_LABORALs
        {
            get
            {
                if (_DECLARACION_DOM_LABORALs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _DECLARACION_DOM_LABORALs = new List<blld_DECLARACION_DOM_LABORAL>();
                    foreach (MODELDeclara_V2.DECLARACION_DOM_LABORAL o in base_DECLARACION_DOM_LABORALs)
                    {
                        _DECLARACION_DOM_LABORALs.Add(new blld_DECLARACION_DOM_LABORAL(o));
                    }
                }
                return _DECLARACION_DOM_LABORALs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_DECLARACION_DOM_LABORAL() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_DECLARACION_DOM_LABORAL.single_select();
        }

     #endregion

    }
}
