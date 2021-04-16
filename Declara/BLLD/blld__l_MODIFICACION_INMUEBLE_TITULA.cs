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
    public  class blld__l_MODIFICACION_INMUEBLE_TITULA : bll__l_MODIFICACION_INMUEBLE_TITULA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_INMUEBLE_TITULA.PageSize;
            set => datos_MODIFICACION_INMUEBLE_TITULA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_INMUEBLE_TITULA.PageNumber;
            set => datos_MODIFICACION_INMUEBLE_TITULA.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_INMUEBLE_TITULA.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_INMUEBLE_TITULA.TotalItems;

        private List<blld_MODIFICACION_INMUEBLE_TITULA> _MODIFICACION_INMUEBLE_TITULAs { get; set; }
        public List<blld_MODIFICACION_INMUEBLE_TITULA> MODIFICACION_INMUEBLE_TITULAs
        {
            get
            {
                if (_MODIFICACION_INMUEBLE_TITULAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_INMUEBLE_TITULAs = new List<blld_MODIFICACION_INMUEBLE_TITULA>();
                    foreach (MODELDeclara_V2.MODIFICACION_INMUEBLE_TITULA o in base_MODIFICACION_INMUEBLE_TITULAs)
                    {
                        _MODIFICACION_INMUEBLE_TITULAs.Add(new blld_MODIFICACION_INMUEBLE_TITULA(o));
                    }
                }
                return _MODIFICACION_INMUEBLE_TITULAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_INMUEBLE_TITULA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_INMUEBLE_TITULA.single_select();
        }

     #endregion

    }
}
