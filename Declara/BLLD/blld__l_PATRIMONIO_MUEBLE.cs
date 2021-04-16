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
    public  class blld__l_PATRIMONIO_MUEBLE : bll__l_PATRIMONIO_MUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_MUEBLE.PageSize;
            set => datos_PATRIMONIO_MUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_MUEBLE.PageNumber;
            set => datos_PATRIMONIO_MUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_MUEBLE.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_MUEBLE.TotalItems;

        private List<blld_PATRIMONIO_MUEBLE> _PATRIMONIO_MUEBLEs { get; set; }
        public List<blld_PATRIMONIO_MUEBLE> PATRIMONIO_MUEBLEs
        {
            get
            {
                if (_PATRIMONIO_MUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_MUEBLEs = new List<blld_PATRIMONIO_MUEBLE>();
                    foreach (MODELDeclara_V2.PATRIMONIO_MUEBLE o in base_PATRIMONIO_MUEBLEs)
                    {
                        _PATRIMONIO_MUEBLEs.Add(new blld_PATRIMONIO_MUEBLE(o));
                    }
                }
                return _PATRIMONIO_MUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_MUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_MUEBLE.single_select();
        }

     #endregion

    }
}
