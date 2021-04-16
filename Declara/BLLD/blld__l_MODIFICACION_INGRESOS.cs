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
    public  class blld__l_MODIFICACION_INGRESOS : bll__l_MODIFICACION_INGRESOS
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_MODIFICACION_INGRESOS.PageSize;
            set => datos_MODIFICACION_INGRESOS.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_MODIFICACION_INGRESOS.PageNumber;
            set => datos_MODIFICACION_INGRESOS.PageNumber = value;
        }

        public Int32 TotalPages => datos_MODIFICACION_INGRESOS.TotalPages;

        public Int32 TotalItems => datos_MODIFICACION_INGRESOS.TotalItems;

        private List<blld_MODIFICACION_INGRESOS> _MODIFICACION_INGRESOSs { get; set; }
        public List<blld_MODIFICACION_INGRESOS> MODIFICACION_INGRESOSs
        {
            get
            {
                if (_MODIFICACION_INGRESOSs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _MODIFICACION_INGRESOSs = new List<blld_MODIFICACION_INGRESOS>();
                    foreach (MODELDeclara_V2.MODIFICACION_INGRESOS o in base_MODIFICACION_INGRESOSs)
                    {
                        _MODIFICACION_INGRESOSs.Add(new blld_MODIFICACION_INGRESOS(o));
                    }
                }
                return _MODIFICACION_INGRESOSs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_MODIFICACION_INGRESOS() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_MODIFICACION_INGRESOS.single_select();
        }

     #endregion

    }
}
