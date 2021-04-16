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
    public  class blld__l_MODIFICACION_INMUEBLE : bll__l_MODIFICACION_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_INMUEBLE.PageSize;
            set => datos_MODIFICACION_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_INMUEBLE.PageNumber;
            set => datos_MODIFICACION_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_INMUEBLE.TotalItems;

        private List<blld_MODIFICACION_INMUEBLE> _MODIFICACION_INMUEBLEs { get; set; }
        public List<blld_MODIFICACION_INMUEBLE> MODIFICACION_INMUEBLEs
        {
            get
            {
                if (_MODIFICACION_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_INMUEBLEs = new List<blld_MODIFICACION_INMUEBLE>();
                    foreach (MODELDeclara_V2.MODIFICACION_INMUEBLE o in base_MODIFICACION_INMUEBLEs)
                    {
                        _MODIFICACION_INMUEBLEs.Add(new blld_MODIFICACION_INMUEBLE(o));
                    }
                }
                return _MODIFICACION_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_INMUEBLE.single_select();
        }

     #endregion

    }
}
