using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll_CAT_MUNICIPIO : _bllSistema
    {

        internal dald_CAT_MUNICIPIO datos_CAT_MUNICIPIO;

     #region *** Atributos ***

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS => datos_CAT_MUNICIPIO.NID_PAIS;

        [Key]
        [StringLength(2)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA => datos_CAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_MUNICIPIO => datos_CAT_MUNICIPIO.CID_MUNICIPIO;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MUNICIPIO
        {
          get => datos_CAT_MUNICIPIO.V_MUNICIPIO;
          set => datos_CAT_MUNICIPIO.V_MUNICIPIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_MUNICIPIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_CAT_MUNICIPIO() => datos_CAT_MUNICIPIO = new dald_CAT_MUNICIPIO();

        public bll_CAT_MUNICIPIO(MODELDeclara_V2.CAT_MUNICIPIO CAT_MUNICIPIO) => datos_CAT_MUNICIPIO = new dald_CAT_MUNICIPIO(CAT_MUNICIPIO);

        public bll_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO) => datos_CAT_MUNICIPIO = new dald_CAT_MUNICIPIO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO);

        public bll_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_CAT_MUNICIPIO = new dald_CAT_MUNICIPIO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_MUNICIPIO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_CAT_MUNICIPIO.update();
        }

        public void delete()
        {
            datos_CAT_MUNICIPIO.delete();
        }

        public void reload()
        {
            datos_CAT_MUNICIPIO.reload();
        }

     #endregion

    }
}
