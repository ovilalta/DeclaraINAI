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
    public  class blld__l_CAT_USO_VEHICULO : bll__l_CAT_USO_VEHICULO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_CAT_USO_VEHICULO.PageSize;
            set => datos_CAT_USO_VEHICULO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_CAT_USO_VEHICULO.PageNumber;
            set => datos_CAT_USO_VEHICULO.PageNumber = value;
        }

        public Int32 TotalPages => datos_CAT_USO_VEHICULO.TotalPages;

        public Int32 TotalItems => datos_CAT_USO_VEHICULO.TotalItems;

        private List<blld_CAT_USO_VEHICULO> _CAT_USO_VEHICULOs { get; set; }
        public List<blld_CAT_USO_VEHICULO> CAT_USO_VEHICULOs
        {
            get
            {
                if (_CAT_USO_VEHICULOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _CAT_USO_VEHICULOs = new List<blld_CAT_USO_VEHICULO>();
                    foreach (MODELDeclara_V2.CAT_USO_VEHICULO o in base_CAT_USO_VEHICULOs)
                    {
                        _CAT_USO_VEHICULOs.Add(new blld_CAT_USO_VEHICULO(o));
                    }
                }
                return _CAT_USO_VEHICULOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_CAT_USO_VEHICULO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_CAT_USO_VEHICULO.single_select();
        }

     #endregion

    }
}
