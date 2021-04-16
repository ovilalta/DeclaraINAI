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
    public  class blld__l_ALTA_INMUEBLE : bll__l_ALTA_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_INMUEBLE.PageSize;
            set => datos_ALTA_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_INMUEBLE.PageNumber;
            set => datos_ALTA_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_ALTA_INMUEBLE.TotalItems;

        private List<blld_ALTA_INMUEBLE> _ALTA_INMUEBLEs { get; set; }
        public List<blld_ALTA_INMUEBLE> ALTA_INMUEBLEs
        {
            get
            {
                if (_ALTA_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_INMUEBLEs = new List<blld_ALTA_INMUEBLE>();
                    foreach (MODELDeclara_V2.ALTA_INMUEBLE o in base_ALTA_INMUEBLEs)
                    {
                        _ALTA_INMUEBLEs.Add(new blld_ALTA_INMUEBLE(o));
                    }
                }
                return _ALTA_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_INMUEBLE.single_select();
        }

     #endregion

    }
}
