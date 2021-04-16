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
    public  class blld__l_ALTA_MUEBLE : bll__l_ALTA_MUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_MUEBLE.PageSize;
            set => datos_ALTA_MUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_MUEBLE.PageNumber;
            set => datos_ALTA_MUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_MUEBLE.TotalPages;

        public Int32 TotalItems => datos_ALTA_MUEBLE.TotalItems;

        private List<blld_ALTA_MUEBLE> _ALTA_MUEBLEs { get; set; }
        public List<blld_ALTA_MUEBLE> ALTA_MUEBLEs
        {
            get
            {
                if (_ALTA_MUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_MUEBLEs = new List<blld_ALTA_MUEBLE>();
                    foreach (MODELDeclara_V2.ALTA_MUEBLE o in base_ALTA_MUEBLEs)
                    {
                        _ALTA_MUEBLEs.Add(new blld_ALTA_MUEBLE(o));
                    }
                }
                return _ALTA_MUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_MUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_MUEBLE.single_select();
        }

     #endregion

    }
}
