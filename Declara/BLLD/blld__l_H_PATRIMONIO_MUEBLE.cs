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
    public  class blld__l_H_PATRIMONIO_MUEBLE : bll__l_H_PATRIMONIO_MUEBLE
    {

     #region *** Atributos ***

        public Int32 PageIndex { get; set; }

        public Int32 PageSize
        {
            get => datos_H_PATRIMONIO_MUEBLE.PageSize;
            set => datos_H_PATRIMONIO_MUEBLE.PageSize = value;
        }

        public Int32 PageNumber
        {
            get => datos_H_PATRIMONIO_MUEBLE.PageNumber;
            set => datos_H_PATRIMONIO_MUEBLE.PageNumber = value;
        }

        public Int32 TotalPages => datos_H_PATRIMONIO_MUEBLE.TotalPages;

        public Int32 TotalItems => datos_H_PATRIMONIO_MUEBLE.TotalItems;

        private List<blld_H_PATRIMONIO_MUEBLE> _H_PATRIMONIO_MUEBLEs { get; set; }
        public List<blld_H_PATRIMONIO_MUEBLE> H_PATRIMONIO_MUEBLEs
        {
            get
            {
                if (_H_PATRIMONIO_MUEBLEs == null)
                {
                    if (PageSize <= 0) throw new NonPaginatedException();
                    _H_PATRIMONIO_MUEBLEs = new List<blld_H_PATRIMONIO_MUEBLE>();
                    foreach (MODELDeclara_V2.H_PATRIMONIO_MUEBLE o in base_H_PATRIMONIO_MUEBLEs)
                    {
                        _H_PATRIMONIO_MUEBLEs.Add(new blld_H_PATRIMONIO_MUEBLE(o));
                    }
                }
                return _H_PATRIMONIO_MUEBLEs;
            }
        }


     #endregion


     #region *** Constructores ***

        public blld__l_H_PATRIMONIO_MUEBLE() : base() { } 


     #endregion


     #region *** Metodos ***

        public void Select(Int32 PageSize)
        {
            this.PageSize = PageSize;
            datos_H_PATRIMONIO_MUEBLE.single_select();
        }

     #endregion

    }
}
