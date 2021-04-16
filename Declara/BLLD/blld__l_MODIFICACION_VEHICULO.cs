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
    public  class blld__l_MODIFICACION_VEHICULO : bll__l_MODIFICACION_VEHICULO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_VEHICULO.PageSize;
            set => datos_MODIFICACION_VEHICULO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_VEHICULO.PageNumber;
            set => datos_MODIFICACION_VEHICULO.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_VEHICULO.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_VEHICULO.TotalItems;

        private List<blld_MODIFICACION_VEHICULO> _MODIFICACION_VEHICULOs { get; set; }
        public List<blld_MODIFICACION_VEHICULO> MODIFICACION_VEHICULOs
        {
            get
            {
                if (_MODIFICACION_VEHICULOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_VEHICULOs = new List<blld_MODIFICACION_VEHICULO>();
                    foreach (MODELDeclara_V2.MODIFICACION_VEHICULO o in base_MODIFICACION_VEHICULOs)
                    {
                        _MODIFICACION_VEHICULOs.Add(new blld_MODIFICACION_VEHICULO(o));
                    }
                }
                return _MODIFICACION_VEHICULOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_VEHICULO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_VEHICULO.single_select();
        }

     #endregion

    }
}
