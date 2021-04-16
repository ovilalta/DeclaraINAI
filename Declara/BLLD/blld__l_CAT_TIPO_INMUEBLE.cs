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
    public  class blld__l_CAT_TIPO_INMUEBLE : bll__l_CAT_TIPO_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_INMUEBLE.PageSize;
            set => datos_CAT_TIPO_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_INMUEBLE.PageNumber;
            set => datos_CAT_TIPO_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_INMUEBLE.TotalItems;

        private List<blld_CAT_TIPO_INMUEBLE> _CAT_TIPO_INMUEBLEs { get; set; }
        public List<blld_CAT_TIPO_INMUEBLE> CAT_TIPO_INMUEBLEs
        {
            get
            {
                if (_CAT_TIPO_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_INMUEBLEs = new List<blld_CAT_TIPO_INMUEBLE>();
                    foreach (MODELDeclara_V2.CAT_TIPO_INMUEBLE o in base_CAT_TIPO_INMUEBLEs)
                    {
                        _CAT_TIPO_INMUEBLEs.Add(new blld_CAT_TIPO_INMUEBLE(o));
                    }
                }
                return _CAT_TIPO_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_INMUEBLE.single_select();
        }

     #endregion

    }
}
