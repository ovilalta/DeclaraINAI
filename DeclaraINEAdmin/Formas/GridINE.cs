using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;

namespace Declara
{
    public class GridINE
    {
        List<ColumnaTexto> _ColumnasTexto { get; set; }
        List<ColumnaEstado> _ColumnasEstado { get; set; }
        List<ColumnaBoton> _ColumnasBoton { get; set; }
        List<ColumnaBotonImagen> _ColumnasBotonImagen { get; set; }
        List<ColumnaImagen> _ColumnasImagen { get; set; }

        internal List<ColumnaTexto> ColumnasTexto
        {
            get
            {
                if (_ColumnasTexto == null)
                {
                    _ColumnasTexto = new List<ColumnaTexto>();
                }
                return _ColumnasTexto;
            }
            set
            {
                _ColumnasTexto = value;
            }
        }

        internal List<ColumnaEstado> ColumnasEstado
        {
            get
            {
                if (_ColumnasEstado == null)
                {
                    _ColumnasEstado = new List<ColumnaEstado>();
                }
                return _ColumnasEstado;
            }
            set
            {
                _ColumnasEstado = value;
            }
        }

        internal void DefineGrid(ref AlanGridView grdInformesEjecutivos, List<ColumnaTexto> columns)
        {
            throw new NotImplementedException();
        }

        internal List<ColumnaBoton> ColumnasBoton
        {
            get
            {
                if (_ColumnasBoton == null)
                {
                    _ColumnasBoton = new List<ColumnaBoton>();
                }
                return _ColumnasBoton;
            }
            set
            {
                _ColumnasBoton = value;
            }
        }

        internal List<ColumnaBotonImagen> ColumnasBotonImagen
        {
            get
            {
                if (_ColumnasBotonImagen == null)
                {
                    _ColumnasBotonImagen = new List<ColumnaBotonImagen>();
                }
                return _ColumnasBotonImagen;
            }
            set
            {
                _ColumnasBotonImagen = value;
            }
        }

        internal List<ColumnaImagen> ColumnasImagen
        {
            get
            {
                if (_ColumnasImagen == null)
                {
                    _ColumnasImagen = new List<ColumnaImagen>();
                }
                return _ColumnasImagen;
            }
            set
            {
                _ColumnasImagen = value;
            }
        }


        public Boolean lBotonSelect { get; set; }
        private ColumnaBoton _BotonSelect;
        public ColumnaBoton BotonSelect
        {
            get
            {
                if (_BotonSelect == null)
                {
                    _BotonSelect = new ColumnaBoton();
                }
                return _BotonSelect;
            }
            set
            {
                _BotonSelect = value;
            }
        }
        public Boolean lBotonDelete;
        private ColumnaBoton _BotonDelete;
        public ColumnaBoton BotonDelete
        {
            get
            {
                if (_BotonDelete == null)
                {
                    _BotonDelete = new ColumnaBoton();
                }
                return _BotonDelete;
            }
            set
            {
                _BotonDelete = value;
            }
        }
        public Boolean lCheckBox { get; set; }
        public Boolean lAllowPaging { get; set; }
        public bool lBooleanEditable { get; set; }
        public bool lAlternatingRowStyle { get; set; }
        public String strFormatoFecha { get; set; }
        public String strFormatoNumero { get; set; }
        public String strFormatoMoneda { get; set; }


        public Boolean lChangeOnOver { get; set; }

        public const String Select = "Select";
        public const String Delete = "Delete";

        public GridINE()
            : this(true, false, false)
        {
        }

        public GridINE(Boolean lBotonSelect, Boolean lBotonDelete, Boolean lCheckBox)
        {
            this.lBotonSelect = lBotonSelect;
            this.lBotonDelete = lBotonDelete;
            this.lCheckBox = lCheckBox;
            this.lAllowPaging = true;
            this.lBooleanEditable = false;
            this.lChangeOnOver = true;
            this.lAlternatingRowStyle = true;
            this.strFormatoFecha = "dd/MM/yyyy";
            this.strFormatoNumero = "{0:0,0}";
            this.strFormatoMoneda = "C";
        }

        internal void DefineGrid(ref GridView Grid, List<ColumnaTexto> ColumnasTexto, List<ColumnaEstado> ColumnasEstado)
        {
            this.ColumnasTexto = ColumnasTexto;
            this.ColumnasEstado = ColumnasEstado;
            DefineGrid(ref Grid);
        }

        internal void DefineGrid(ref GridView Grid, List<ColumnaTexto> ColumnasTexto)
        {
            this.ColumnasTexto = ColumnasTexto;
            DefineGrid(ref Grid);
        }

        internal void DefineGrid(ref GridView Grid)
        {
            //if (this.ColumnasTexto.Count == 0 && this.ColumnasImagen.Count == 0) throw new Exception("No se establecio ninguna columna");

            Grid.Width = new Unit(100, UnitType.Percentage);
            if (lChangeOnOver) Grid.CssClass = "table table-bordered table-hover alanGrid-theme table-condensed";
            else Grid.CssClass = "table table-bordered alanGrid-theme table-condensed";
            Grid.RowStyle.CssClass = "data-row";
            if (lAlternatingRowStyle) Grid.AlternatingRowStyle.CssClass = "alt-data-row";
            Grid.PagerSettings.Position = System.Web.UI.WebControls.PagerPosition.Bottom;
            Grid.PagerStyle.CssClass = "pagination-ys";
            Grid.PagerStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
            Grid.AllowPaging = lAllowPaging;


            if (lCheckBox)
            {
                TemplateField temCheck = new TemplateField();
                temCheck.ItemTemplate = new GridViewCheckBoxSelectTemplate();
                Grid.Columns.Add(temCheck);
            }

            if (this.ColumnasTexto.Count > 0)
                Grid.AutoGenerateColumns = false;

            foreach (ColumnaTexto columna in this.ColumnasTexto)
            {
                String Campo = columna.Campo;
                String Encabezado = columna.Encabezado;

                TemplateField template = new TemplateField();
                template.HeaderTemplate = new GridViewHeaderTemplate(Encabezado);
                GridViewItemTemplate oTemplate;

                switch (Campo.Substring(0, 2))
                {
                    case "L_":
                        GridViewItemCheckBoxTemplate oTemplateCheck = new GridViewItemCheckBoxTemplate(Campo);
                        oTemplateCheck.Enabled = lBooleanEditable;
                        template.ItemTemplate = oTemplateCheck;
                        break;
                    case "F_":
                        oTemplate = new GridViewItemTemplate(Campo);
                        oTemplate.dataType = GridViewItemTemplate.type.DateTime;
                        oTemplate.format = strFormatoFecha;
                        template.ItemTemplate = oTemplate;
                        break;
                    case "M_":
                        oTemplate = new GridViewItemTemplate(Campo);
                        oTemplate.dataType = GridViewItemTemplate.type.Money;
                        oTemplate.format = strFormatoMoneda;
                        template.ItemTemplate = oTemplate;
                        break;
                    default:
                        oTemplate = new GridViewItemTemplate(Campo);
                        template.ItemTemplate = oTemplate;
                        break;
                }

                Grid.Columns.Add(template);
            }

            foreach (ColumnaEstado estado in this.ColumnasEstado)
            {
                TemplateField template = new TemplateField();
                template.HeaderTemplate = new GridViewHeaderTemplate(estado.Encabezado);
                template.ItemTemplate = new GridViewItemStateTemplate(estado.CampoIndex, estado.CampoTexto, estado.FolderEstados, estado.Extension, estado.ToolTip, estado.Texto);
                Grid.Columns.Add(template);
            }

            foreach (ColumnaBoton boton in this.ColumnasBoton)
            {
                TemplateField template = new TemplateField();

                template.HeaderTemplate = new GridViewHeaderTemplate(boton.Encabezado);
                GridViewItemButtonTemplate oButton = new GridViewItemButtonTemplate(boton);
           
                template.ItemTemplate = oButton;
                template.ItemStyle.Wrap = true;
                template.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                Grid.Columns.Add(template);
            }

            if (lBotonSelect)
            {
                TemplateField temSelect = new TemplateField();
                ColumnaBoton btn = BotonSelect;
                btn.CssClass = "btn btn-default btnImage-Discrete-Notext Image-Edit";
                btn.CommandName = Select;
                btn.ID = "btn" + Select;
                temSelect.ItemTemplate = new GridViewItemButtonTemplate(btn);
                //  temSelect.ItemTemplate = new GridViewItemSelectButtonTemplate("");
                temSelect.ItemStyle.Wrap = true;
                temSelect.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                Grid.Columns.Add(temSelect);

            }

            if (lBotonDelete)
            {
                TemplateField temDelete = new TemplateField();
                ColumnaBoton btn = _BotonDelete;
                try
                {
                    if (String.IsNullOrEmpty(btn.CssClass)) btn.CssClass = "btn btn-default btnImage-Discrete-Notext Image-Trash";
                }
                catch
                {
                    btn = new ColumnaBoton();
                    btn.CssClass = "btn btn-default btnImage-Discrete-Notext Image-Trash";
                }
                btn.CommandName = Delete;
                btn.ID = "btn" + Delete;
                temDelete.ItemTemplate = new GridViewItemButtonTemplate(btn);
                //temSelect.ItemTemplate = new GridViewItemDeleteButtonTemplate("");
                temDelete.ItemStyle.Wrap = true;
                temDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                Grid.Columns.Add(temDelete);
            }
        }
    }

    #region Templates

    public class GridViewHeaderTemplate : ITemplate
    {
        string text;

        public GridViewHeaderTemplate(string text)
        {
            this.text = text;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Literal lc = new Literal();
            lc.Text = text;

            container.Controls.Add(lc);

        }
    }

    public class GridViewItemTemplate : ITemplate
    {
        private String columnName;
        internal String format;
        internal type dataType;

        internal enum type
        {
            String,
            DateTime,
            Int32,
            Money,
        }

        public GridViewItemTemplate(String columnName)
        {
            this.columnName = columnName;
            dataType = type.String;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Literal lc = new Literal();
            lc.ID = columnName;
            lc.DataBinding += new EventHandler(lc_DataBinding);

            container.Controls.Add(lc);
        }

        void lc_DataBinding(object sender, EventArgs e)
        {
            Literal l = (Literal)sender;

            GridViewRow row = (GridViewRow)l.NamingContainer;
            String RawValue = String.Empty;
            try
            {
                switch (dataType)
                {
                    case type.String:
                        RawValue = DataBinder.Eval(row.DataItem, columnName).ToString();
                        break;
                    case type.DateTime:
                        RawValue = Convert.ToDateTime(DataBinder.Eval(row.DataItem, columnName).ToString()).ToString(format);
                        break;
                    case type.Int32:
                        RawValue = Convert.ToInt32(DataBinder.Eval(row.DataItem, columnName).ToString()).ToString(format);
                        break;
                    case type.Money:
                        RawValue = Convert.ToDecimal(DataBinder.Eval(row.DataItem, columnName).ToString()).ToString(format);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                try { RawValue = DataBinder.Eval(row.DataItem, columnName).ToString(); }
                catch { }
            }

            l.Text = RawValue;
        }
    }

    public class GridViewItemStateTemplate : ITemplate
    {
        private String CampoIndex;
        private String CampoTexto;
        private String FolderEstados;
        private String Extension;
        private Boolean ToolTip;
        private Boolean Texto;

        public GridViewItemStateTemplate(String CampoIndex, String CampoTexto, String FolderEstados, String Extension, Boolean ToolTip, Boolean Texto)
        {
            this.CampoIndex = CampoIndex;
            this.CampoTexto = CampoTexto.Trim();
            this.FolderEstados = FolderEstados;
            this.Extension = Extension;
            this.ToolTip = ToolTip;
            this.Texto = Texto;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Image imc = new Image();
            imc.ID = CampoIndex;
            imc.DataBinding += new EventHandler(imc_DataBinding);
            container.Controls.Add(imc);

            if (Texto)
            {
                Label lc = new Label();
                lc.ID = CampoTexto;
                lc.DataBinding += new EventHandler(lbl_DataBinding);
                container.Controls.Add(lc);
            }
        }

        void lbl_DataBinding(object sender, EventArgs e)
        {
            Label l = (Label)sender;

            GridViewRow row = (GridViewRow)l.NamingContainer;
            string RawValue;
            RawValue = DataBinder.Eval(row.DataItem, CampoTexto).ToString();

            l.Text = RawValue;
        }

        void imc_DataBinding(object sender, EventArgs e)
        {
            Image im = (Image)sender;

            GridViewRow row = (GridViewRow)im.NamingContainer;
            String ImageUrl;
            ImageUrl = FolderEstados + DataBinder.Eval(row.DataItem, CampoIndex).ToString() + Extension;
            im.Attributes.Add("data-toggle", "tooltip");
            im.ImageUrl = ImageUrl;
            if (ToolTip && !String.IsNullOrEmpty(CampoTexto)) im.ToolTip = DataBinder.Eval(row.DataItem, CampoTexto).ToString();
        }
    }

    public class GridViewItemTextBoxTemplate : ITemplate
    {
        private String columnName;

        public GridViewItemTextBoxTemplate(String columnName)
        {
            this.columnName = columnName;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            TextBox tb = new TextBox();
            tb.ID = String.Format("txt", columnName);
            tb.EnableViewState = false;
            tb.DataBinding += new EventHandler(tb_DataBinding);

            container.Controls.Add(tb);
        }

        void tb_DataBinding(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            GridViewRow row = (GridViewRow)t.NamingContainer;

            String RawValue = DataBinder.Eval(row.DataItem, columnName).ToString();

            t.Text = RawValue;
        }
    }

    public class GridViewItemCheckBoxTemplate : ITemplate
    {
        private string columnName;

        public GridViewItemCheckBoxTemplate(string columnName)
        {
            this.columnName = columnName;
        }

        public bool Enabled { get; set; }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            CheckBox check = new CheckBox();
            check.ID = columnName;
            check.Enabled = this.Enabled;
            check.CssClass = "BigCheckBox";
            check.DataBinding += new EventHandler(check_DataBinding);

            container.Controls.Add(check);

        }

        void check_DataBinding(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            GridViewRow row = (GridViewRow)check.NamingContainer;

            string value = DataBinder.Eval(row.DataItem, columnName).ToString();
            try
            {
                check.Checked = bool.Parse(value);
            }
            catch
            {
                check.Checked = Convert.ToBoolean(Convert.ToInt16(value));
            }
        }
    }

    public class GridViewCheckBoxSelectTemplate : ITemplate
    {
        public GridViewCheckBoxSelectTemplate()
        {
            this.Enabled = true;
        }

        public bool Enabled { get; set; }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            CheckBox check = new CheckBox();
            check.ID = "cbx";
            check.Width = System.Web.UI.WebControls.Unit.Pixel(24);
            check.Height = System.Web.UI.WebControls.Unit.Pixel(24);
            check.CssClass = "BigCheckBox";
            check.Enabled = this.Enabled;
            container.Controls.Add(check);

        }
    }

    public class GridViewItemButtonTemplate : ITemplate
    {
        private String CommandName { get; set; }
        private String CssClass { get; set; }
        internal String columnName { get; set; }
        internal String ID { get; set; }
        internal String Text { get; set; }
        internal Boolean Visible { get; set; }
        internal Boolean Enabled { get; set; }

        public GridViewItemButtonTemplate(ColumnaBoton button)
        {
            this.CommandName = button.CommandName;
            this.CssClass = button.CssClass;
            this.columnName = columnName;
            this.columnName = button.Campo;
            this.ID = button.ID;
            this.Text = button.Text;
            this.Visible = button.Visible;
            this.Enabled = button.Enabled;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Button iButton = new Button();
            iButton.ClientIDMode = ClientIDMode.AutoID;
            iButton.CommandName = CommandName;
            iButton.CssClass = CssClass;
            iButton.ID = ID;
            iButton.Text = Text;
            iButton.Visible = Visible;
            iButton.Enabled = Enabled;
            iButton.DataBinding += new EventHandler(button_DataBinding);
            container.Controls.Add(iButton);
        }

        void button_DataBinding(object sender, EventArgs e)
        {
            Button iButton = (Button)sender;
            GridViewRow row = (GridViewRow)iButton.NamingContainer;
            iButton.CommandArgument = row.DataItemIndex.ToString();
            if (!String.IsNullOrEmpty(columnName))
                try { iButton.Text = DataBinder.Eval(row.DataItem, columnName).ToString(); }
                catch { iButton.Text = String.Empty; }
        }
    }

    public class GridViewItemImageButtonTemplate : ITemplate
    {
        private String CommandName { get; set; }
        private String CssClass { get; set; }
        internal String columnName { get; set; }
        internal String directory { get; set; }
        internal String extension { get; set; }
        internal String ID { get; set; }
        internal String ImageUrl { get; set; }
        internal Boolean Visible { get; set; }
        internal Boolean Enabled { get; set; }

        public GridViewItemImageButtonTemplate(ColumnaBotonImagen imageButton)
        {
            this.CommandName = imageButton.CommandName;
            this.CssClass = imageButton.CssClass;
            this.columnName = imageButton.Campo;
            this.directory = imageButton.directory;
            this.extension = imageButton.extension;
            this.ID = imageButton.ID;
            this.ImageUrl = imageButton.ImageUrl;
            this.Visible = imageButton.Visible;
            this.Enabled = imageButton.Enabled;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            ImageButton imageButton = new ImageButton();
            imageButton.CommandName = CommandName;
            imageButton.CssClass = CssClass;
            imageButton.ID = ID;
            imageButton.Visible = Visible;
            imageButton.Enabled = Enabled;
            imageButton.ImageUrl = ImageUrl;
            imageButton.DataBinding += new EventHandler(imageButton_DataBinding);
            container.Controls.Add(imageButton);
        }

        void imageButton_DataBinding(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imageButton.NamingContainer;
            imageButton.CommandArgument = row.DataItemIndex.ToString();
            if (!String.IsNullOrEmpty(columnName))
            {
                if (!String.IsNullOrEmpty(directory) && !String.IsNullOrEmpty(extension))
                    try { imageButton.ImageUrl = directory + DataBinder.Eval(row.DataItem, columnName).ToString() + extension; }
                    catch { imageButton.ImageUrl = String.Empty; }
                else
                    try { imageButton.ImageUrl = DataBinder.Eval(row.DataItem, columnName).ToString(); }
                    catch { imageButton.ImageUrl = String.Empty; }
            }
        }
    }

    public class GridViewItemImageTemplate : ITemplate
    {
        internal String ImageUrl { get; set; }
        internal String columnName { get; set; }
        internal String directory { get; set; }
        internal String extension { get; set; }
        internal String ID { get; set; }
        internal Boolean Visible { get; set; }
        internal Boolean Enabled { get; set; }

        public GridViewItemImageTemplate(ColumnaImagen image)
        {
            this.ImageUrl = image.ImageUrl;
            this.columnName = image.Campo;
            this.directory = image.directory;
            this.extension = image.extension;
            this.ImageUrl = image.ImageUrl;
            this.ID = image.ID;
            this.Visible = image.Visible;
            this.Enabled = image.Enabled;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            Image image = new Image();
            image.ImageUrl = ImageUrl;
            image.ID = ID;
            image.ImageUrl = ImageUrl;
            image.Enabled = Enabled;
            image.ImageUrl = ImageUrl;
            image.DataBinding += new EventHandler(Image_DataBinding);
            container.Controls.Add(image);
        }

        void Image_DataBinding(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            GridViewRow row = (GridViewRow)image.NamingContainer;
            if (!String.IsNullOrEmpty(columnName))
            {
                if (!String.IsNullOrEmpty(directory) && !String.IsNullOrEmpty(extension))
                    try { image.ImageUrl = directory + DataBinder.Eval(row.DataItem, columnName).ToString() + extension; }
                    catch { image.ImageUrl = String.Empty; }
                else
                    try { image.ImageUrl = DataBinder.Eval(row.DataItem, columnName).ToString(); }
                    catch { image.ImageUrl = String.Empty; }
            }
        }
    }

    #endregion

    #region **** Clases Auxiliares ****

    internal class ColumnaTexto
    {
        internal String Campo { get; set; }
        internal String Encabezado { get; set; }
        internal System.Nullable<Int32> Orden { get; set; }

        internal ColumnaTexto(Object Campo, String Encabezado, System.Nullable<Int32> Orden)
        {
            this.Campo = Campo.ToString();
            this.Encabezado = Encabezado;
            this.Orden = Orden;
            if (String.IsNullOrEmpty(this.Campo.Trim())) throw new Exception("Indica un campo");
        }

        internal ColumnaTexto(Object Campo, String Encabezado)
            : this(Campo, Encabezado, null) { }

        internal ColumnaTexto(Object Campo, Int32 Orden)
            : this(Campo, String.Empty, Orden) { }

        internal ColumnaTexto(Object Campo)
            : this(Campo, String.Empty, null) { }

    }

    internal class ColumnaEstado
    {
        internal String CampoIndex { get; set; }
        internal String CampoTexto { get; set; }
        internal String Encabezado { get; set; }
        internal System.Nullable<Int32> Orden { get; set; }
        internal String FolderEstados { get; set; }
        internal String Extension { get; set; }
        private Boolean _ToolTip;
        internal Boolean ToolTip
        {
            get
            {
                if (!String.IsNullOrEmpty(this.CampoTexto.Trim())) return _ToolTip;
                else return false;
            }
            set { _ToolTip = value; }
        }

        private Boolean _Texto;
        internal Boolean Texto
        {
            get
            {
                if (!String.IsNullOrEmpty(CampoTexto.Trim())) return _Texto;
                else return false;
            }
            set { _Texto = value; }
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String Encabezado, System.Nullable<Int32> Orden, String FolderEstados, String Extension, Boolean ToolTip, Boolean Texto)
        {
            this.CampoIndex = CampoIndex.ToString();
            this.CampoTexto = CampoTexto.ToString();
            this.Encabezado = Encabezado;
            this.Orden = Orden;
            this.FolderEstados = FolderEstados;
            this.Extension = Extension;
            this.ToolTip = ToolTip;
            this.Texto = Texto;

            if (String.IsNullOrEmpty(FolderEstados.Trim())) throw new Exception("Indica una carpeta de iconos de estados");
            if (String.IsNullOrEmpty(Extension.Trim())) throw new Exception("Indica una extensión de iconos de estados");
            if (String.IsNullOrEmpty(CampoIndex.ToString().Trim())) throw new Exception("Indica campo de indice de estado");
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String Encabezado, System.Nullable<Int32> Orden, String FolderEstados, String Extension)
            : this(CampoIndex, CampoTexto, Encabezado, Orden, FolderEstados, Extension, true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String Encabezado, System.Nullable<Int32> Orden, String FolderEstados)
            : this(CampoIndex, CampoTexto, Encabezado, Orden, FolderEstados, ".png", true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String Encabezado, String FolderEstados, String Extension)
            : this(CampoIndex, CampoTexto, Encabezado, null, FolderEstados, Extension, true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String Encabezado, String FolderEstados)
            : this(CampoIndex, CampoTexto, Encabezado, null, FolderEstados, ".png", true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, System.Nullable<Int32> Orden, String FolderEstados)
            : this(CampoIndex, CampoTexto, String.Empty, Orden, FolderEstados, ".png", true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, Object CampoTexto, String FolderEstados)
            : this(CampoIndex, CampoTexto, String.Empty, null, FolderEstados, ".png", true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, System.Nullable<Int32> Orden, String FolderEstados)
            : this(CampoIndex, String.Empty, String.Empty, Orden, FolderEstados, ".png", true, false)
        {
        }

        internal ColumnaEstado(Object CampoIndex, String FolderEstados)
            : this(CampoIndex, String.Empty, String.Empty, null, FolderEstados, ".png", true, false)
        {
        }



        //internal ColumnaEstado(String Campo, String Encabezado)
        //    : this(Campo, Encabezado, 0) { }

        //internal ColumnaEstado(String Campo)
        //    : this(Campo, String.Empty, 0) { }

        //internal ColumnaEstado(String Campo, Int32 Orden)
        //    : this(Campo, String.Empty, Orden) { }
    }

    public class ColumnaBoton
    {
        public String CssClass { get; set; }
        public String CommandName { get; set; }
        public String ID { get; set; }
        public String Text { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Enabled { get; set; }

        internal String Encabezado { get; set; }
        internal String Campo { get; set; }

        internal ColumnaBoton()
        {
            Visible = true;
            Enabled = true;
        }

        internal ColumnaBoton(Button button)
        {
            this.CssClass = button.CssClass;
            this.CommandName = button.CommandName;
            this.ID = button.ID;
            this.Visible = button.Visible;
            this.Enabled = button.Enabled;
        }
    }

    public class ColumnaBotonImagen
    {
        public String CssClass { get; set; }
        public String CommandName { get; set; }
        public String ID { get; set; }
        public String ImageUrl { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Enabled { get; set; }

        public String Encabezado { get; set; }
        public String Campo { get; set; }
        public string directory { get; set; }
        public string extension { get; set; }

        public ColumnaBotonImagen()
        {
            Visible = true;
            Enabled = true;
        }

        public ColumnaBotonImagen(ImageButton imageButton)
        {
            this.CssClass = imageButton.CssClass;
            this.CommandName = imageButton.CommandName;
            this.ID = imageButton.ID;
            this.ImageUrl = imageButton.ImageUrl;
            this.Visible = imageButton.Visible;
            this.Enabled = imageButton.Enabled;
        }

    }

    public class ColumnaImagen
    {
        public String CssClass { get; set; }
        public String ID { get; set; }
        public String ImageUrl { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Enabled { get; set; }

        public String Encabezado { get; set; }
        public String Campo { get; set; }
        public string directory { get; set; }
        public string extension { get; set; }

        public ColumnaImagen()
        {
            Visible = true;
            Enabled = true;
        }

        public ColumnaImagen(Image image)
        {
            this.CssClass = image.CssClass;
            this.ID = image.ID;
            this.ImageUrl = image.ImageUrl;
            this.Visible = image.Visible;
            this.Enabled = image.Enabled;
        }
    }

    public static class ControlCloneEngine
    {
        public static Control Copy(Control ctrlSource)
        {
            int m_instanceCount = 1;
            Type t = ctrlSource.GetType();
            Control ctrlDest = (Control)t.InvokeMember("", BindingFlags.CreateInstance, null, null, null);

            foreach (PropertyInfo prop in t.GetProperties())
            {
                if (prop.CanWrite)
                {
                    //if (prop.Name == "ID")
                    //{
                    //    ctrlDest.ID = ctrlSource.ID + "c" + m_instanceCount;
                    //}
                    //else
                    //{
                    prop.SetValue(ctrlDest, prop.GetValue(ctrlSource, null), null);
                    //}
                }
            }
            m_instanceCount++;
            return ctrlDest;
        }
    }

    #endregion

}