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
    public  class blld__l_PATRIMONIO_VEHICULO : bll__l_PATRIMONIO_VEHICULO
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_PATRIMONIO_VEHICULO.PageSize;
            set => datos_PATRIMONIO_VEHICULO.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_PATRIMONIO_VEHICULO.PageNumber;
            set => datos_PATRIMONIO_VEHICULO.PageNumber = value;
        }

        public Int32 TotalPages => datos_PATRIMONIO_VEHICULO.TotalPages;

        public Int32 TotalItems => datos_PATRIMONIO_VEHICULO.TotalItems;

        private List<blld_PATRIMONIO_VEHICULO> _PATRIMONIO_VEHICULOs { get; set; }
        public List<blld_PATRIMONIO_VEHICULO> PATRIMONIO_VEHICULOs
        {
            get
            {
                if (_PATRIMONIO_VEHICULOs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _PATRIMONIO_VEHICULOs = new List<blld_PATRIMONIO_VEHICULO>();
                    foreach (MODELDeclara_V2.PATRIMONIO_VEHICULO o in base_PATRIMONIO_VEHICULOs)
                    {
                        _PATRIMONIO_VEHICULOs.Add(new blld_PATRIMONIO_VEHICULO(o));
                    }
                }
                return _PATRIMONIO_VEHICULOs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_PATRIMONIO_VEHICULO() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_PATRIMONIO_VEHICULO.single_select();
        }

     #endregion

    }
}
