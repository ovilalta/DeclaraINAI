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
    public  class blld__l_CAT_TIPO_MUEBLE : bll__l_CAT_TIPO_MUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_TIPO_MUEBLE.PageSize;
            set => datos_CAT_TIPO_MUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_TIPO_MUEBLE.PageNumber;
            set => datos_CAT_TIPO_MUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_TIPO_MUEBLE.TotalPages;

        public Int32 TotalItems => datos_CAT_TIPO_MUEBLE.TotalItems;

        private List<blld_CAT_TIPO_MUEBLE> _CAT_TIPO_MUEBLEs { get; set; }
        public List<blld_CAT_TIPO_MUEBLE> CAT_TIPO_MUEBLEs
        {
            get
            {
                if (_CAT_TIPO_MUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_TIPO_MUEBLEs = new List<blld_CAT_TIPO_MUEBLE>();
                    foreach (MODELDeclara_V2.CAT_TIPO_MUEBLE o in base_CAT_TIPO_MUEBLEs)
                    {
                        _CAT_TIPO_MUEBLEs.Add(new blld_CAT_TIPO_MUEBLE(o));
                    }
                }
                return _CAT_TIPO_MUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_TIPO_MUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_TIPO_MUEBLE.single_select();
        }

     #endregion

    }
}
