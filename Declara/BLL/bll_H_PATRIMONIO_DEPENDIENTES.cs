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
    //public  class bll_H_PATRIMONIO_DEPENDIENTES : _bllSistema
    //{

    //    internal dald_H_PATRIMONIO_DEPENDIENTES datos_H_PATRIMONIO_DEPENDIENTES;

    // #region *** Atributos ***

    //    [Key]
    //    [StringLength(4)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String VID_NOMBRE => datos_H_PATRIMONIO_DEPENDIENTES.VID_NOMBRE;

    //    [Key]
    //    [StringLength(6)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String VID_FECHA => datos_H_PATRIMONIO_DEPENDIENTES.VID_FECHA;

    //    [Key]
    //    [StringLength(3)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String VID_HOMOCLAVE => datos_H_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE;

    //    [Key]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public Int32 NID_DEPENDIENTE => datos_H_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE;

    //    [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
    //    [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public Int32 NID_TIPO_DEPENDIENTE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
    //    }

    //    [StringLength(127)]
    //    [DataType(DataType.Text)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String E_NOMBRE
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBRE;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_NOMBRE = value;
    //    }

    //    [StringLength(127)]
    //    [DataType(DataType.Text)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String E_PRIMER_A
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_A;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_PRIMER_A = value;
    //    }

    //    [StringLength(127)]
    //    [DataType(DataType.Text)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public String E_SEGUNDO_A
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A = value;
    //    }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
    //    [DataType(DataType.DateTime)]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public DateTime F_NACIMIENTO
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO = value;
    //    }

    //    [StringLength(13)]
    //    [DataType(DataType.Text)]
    //    [DisplayName("")]
    //    public String E_RFC
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.E_RFC;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.E_RFC = value;
    //    }

    //    [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
    //    [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
    //    [Required(ErrorMessage = "El campo  es requerido ")]
    //    [DisplayName("")]
    //    public Int32 NID_HISTORICO
    //    {
    //      get => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICO;
    //      set => datos_H_PATRIMONIO_DEPENDIENTES.NID_HISTORICO = value;
    //    }


    //    #region aux

    //    public System.Nullable<Boolean> lEsNuevoRegistro
    //    {
    //        get { return datos_H_PATRIMONIO_DEPENDIENTES.lEsNuevoRegistro; }
    //    }

    //    #endregion 



    // #endregion


    // #region *** Constructores ***

    //    public bll_H_PATRIMONIO_DEPENDIENTES() => datos_H_PATRIMONIO_DEPENDIENTES = new dald_H_PATRIMONIO_DEPENDIENTES();

    //    public bll_H_PATRIMONIO_DEPENDIENTES(MODELDeclara_V2.H_PATRIMONIO_DEPENDIENTES H_PATRIMONIO_DEPENDIENTES) => datos_H_PATRIMONIO_DEPENDIENTES = new dald_H_PATRIMONIO_DEPENDIENTES(H_PATRIMONIO_DEPENDIENTES);

    //    public bll_H_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE) => datos_H_PATRIMONIO_DEPENDIENTES = new dald_H_PATRIMONIO_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE);

    //    public bll_H_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Int32 NID_HISTORICO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_H_PATRIMONIO_DEPENDIENTES = new dald_H_PATRIMONIO_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, NID_HISTORICO, lOpcionesRegistroExistente);

    // #endregion


    // #region *** Metodos ***

    //    public void update()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.update();
    //    }

    //    public void delete()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.delete();
    //    }

    //    public void reload()
    //    {
    //        datos_H_PATRIMONIO_DEPENDIENTES.reload();
    //    }

    // #endregion

    //}
}
