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
    public  class blld__l_CAT_USO_INMUEBLE : bll__l_CAT_USO_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_USO_INMUEBLE.PageSize;
            set => datos_CAT_USO_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_USO_INMUEBLE.PageNumber;
            set => datos_CAT_USO_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_USO_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_CAT_USO_INMUEBLE.TotalItems;

        private List<blld_CAT_USO_INMUEBLE> _CAT_USO_INMUEBLEs { get; set; }
        public List<blld_CAT_USO_INMUEBLE> CAT_USO_INMUEBLEs
        {
            get
            {
                if (_CAT_USO_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_USO_INMUEBLEs = new List<blld_CAT_USO_INMUEBLE>();
                    foreach (MODELDeclara_V2.CAT_USO_INMUEBLE o in base_CAT_USO_INMUEBLEs)
                    {
                        _CAT_USO_INMUEBLEs.Add(new blld_CAT_USO_INMUEBLE(o));
                    }
                }
                return _CAT_USO_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_USO_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_USO_INMUEBLE.single_select();
        }

     #endregion

    }
}
