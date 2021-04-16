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
    public  class blld__l_PATRIMONIO_INMUEBLE : bll__l_PATRIMONIO_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_INMUEBLE.PageSize;
            set => datos_PATRIMONIO_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_INMUEBLE.PageNumber;
            set => datos_PATRIMONIO_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_INMUEBLE.TotalItems;

        private List<blld_PATRIMONIO_INMUEBLE> _PATRIMONIO_INMUEBLEs { get; set; }
        public List<blld_PATRIMONIO_INMUEBLE> PATRIMONIO_INMUEBLEs
        {
            get
            {
                if (_PATRIMONIO_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_INMUEBLEs = new List<blld_PATRIMONIO_INMUEBLE>();
                    foreach (MODELDeclara_V2.PATRIMONIO_INMUEBLE o in base_PATRIMONIO_INMUEBLEs)
                    {
                        _PATRIMONIO_INMUEBLEs.Add(new blld_PATRIMONIO_INMUEBLE(o));
                    }
                }
                return _PATRIMONIO_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_INMUEBLE.single_select();
        }

     #endregion

    }
}
