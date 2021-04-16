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
    public  class blld__l_MODIFICACION_BAJA_VENTA : bll__l_MODIFICACION_BAJA_VENTA
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_BAJA_VENTA.PageSize;
            set => datos_MODIFICACION_BAJA_VENTA.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_BAJA_VENTA.PageNumber;
            set => datos_MODIFICACION_BAJA_VENTA.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_BAJA_VENTA.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_BAJA_VENTA.TotalItems;

        private List<blld_MODIFICACION_BAJA_VENTA> _MODIFICACION_BAJA_VENTAs { get; set; }
        public List<blld_MODIFICACION_BAJA_VENTA> MODIFICACION_BAJA_VENTAs
        {
            get
            {
                if (_MODIFICACION_BAJA_VENTAs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_BAJA_VENTAs = new List<blld_MODIFICACION_BAJA_VENTA>();
                    foreach (MODELDeclara_V2.MODIFICACION_BAJA_VENTA o in base_MODIFICACION_BAJA_VENTAs)
                    {
                        _MODIFICACION_BAJA_VENTAs.Add(new blld_MODIFICACION_BAJA_VENTA(o));
                    }
                }
                return _MODIFICACION_BAJA_VENTAs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_BAJA_VENTA() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_BAJA_VENTA.single_select();
        }

     #endregion

    }
}
