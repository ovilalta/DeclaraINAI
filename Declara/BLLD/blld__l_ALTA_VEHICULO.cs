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
    public  class blld__l_ALTA_VEHICULO : bll__l_ALTA_VEHICULO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_ALTA_VEHICULO.PageSize;
            set => datos_ALTA_VEHICULO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_ALTA_VEHICULO.PageNumber;
            set => datos_ALTA_VEHICULO.PageNumber = value;
        }

        public Int32 TotalPages => datos_ALTA_VEHICULO.TotalPages;

        public Int32 TotalItems => datos_ALTA_VEHICULO.TotalItems;

        private List<blld_ALTA_VEHICULO> _ALTA_VEHICULOs { get; set; }
        public List<blld_ALTA_VEHICULO> ALTA_VEHICULOs
        {
            get
            {
                if (_ALTA_VEHICULOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _ALTA_VEHICULOs = new List<blld_ALTA_VEHICULO>();
                    foreach (MODELDeclara_V2.ALTA_VEHICULO o in base_ALTA_VEHICULOs)
                    {
                        _ALTA_VEHICULOs.Add(new blld_ALTA_VEHICULO(o));
                    }
                }
                return _ALTA_VEHICULOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_ALTA_VEHICULO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_ALTA_VEHICULO.single_select();
        }

     #endregion

    }
}
