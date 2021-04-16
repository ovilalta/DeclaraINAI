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
    public  class blld__l_H_PATRIMONIO_INMUEBLE : bll__l_H_PATRIMONIO_INMUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO_INMUEBLE.PageSize;
            set => datos_H_PATRIMONIO_INMUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO_INMUEBLE.PageNumber;
            set => datos_H_PATRIMONIO_INMUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO_INMUEBLE.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO_INMUEBLE.TotalItems;

        private List<blld_H_PATRIMONIO_INMUEBLE> _H_PATRIMONIO_INMUEBLEs { get; set; }
        public List<blld_H_PATRIMONIO_INMUEBLE> H_PATRIMONIO_INMUEBLEs
        {
            get
            {
                if (_H_PATRIMONIO_INMUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIO_INMUEBLEs = new List<blld_H_PATRIMONIO_INMUEBLE>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO_INMUEBLE o in base_H_PATRIMONIO_INMUEBLEs)
                    {
                        _H_PATRIMONIO_INMUEBLEs.Add(new blld_H_PATRIMONIO_INMUEBLE(o));
                    }
                }
                return _H_PATRIMONIO_INMUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO_INMUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO_INMUEBLE.single_select();
        }

     #endregion

    }
}
