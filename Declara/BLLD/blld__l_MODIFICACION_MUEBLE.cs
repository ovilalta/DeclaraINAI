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
    public  class blld__l_MODIFICACION_MUEBLE : bll__l_MODIFICACION_MUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_MUEBLE.PageSize;
            set => datos_MODIFICACION_MUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_MUEBLE.PageNumber;
            set => datos_MODIFICACION_MUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_MUEBLE.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_MUEBLE.TotalItems;

        private List<blld_MODIFICACION_MUEBLE> _MODIFICACION_MUEBLEs { get; set; }
        public List<blld_MODIFICACION_MUEBLE> MODIFICACION_MUEBLEs
        {
            get
            {
                if (_MODIFICACION_MUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_MUEBLEs = new List<blld_MODIFICACION_MUEBLE>();
                    foreach (MODELDeclara_V2.MODIFICACION_MUEBLE o in base_MODIFICACION_MUEBLEs)
                    {
                        _MODIFICACION_MUEBLEs.Add(new blld_MODIFICACION_MUEBLE(o));
                    }
                }
                return _MODIFICACION_MUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_MUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_MUEBLE.single_select();
        }

     #endregion

    }
}
